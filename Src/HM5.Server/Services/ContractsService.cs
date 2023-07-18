using System.Collections.Concurrent;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using HM5.Server.Controllers.Hitman;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace HM5.Server.Services
{
    public class ContractsService : IContractsService
    {
        public class SimpleContract
        {
            public string Title { get; init; }
            public string UserId { get; init; }
            public string Description { get; init; }
            public List<Target> Targets { get; init; }
            public List<ERestrictionType> Restrictions { get; init; }
            public int ExitId { get; init; }
            public int Difficulty { get; init; }
            public int LevelIndex { get; init; }
            public int CheckpointIndex { get; init; }
            public int StartingOutfitToken { get; init; }
            public int StartingWeaponToken { get; init; }
            public int Score { get; init; }
        }

        public const string CONTRACTS_PATH = "Contracts";

        private readonly ConcurrentDictionary<string, Contract> _contractCache;

        public ContractsService()
        {
            _contractCache = new ConcurrentDictionary<string, Contract>();
        }

        public void RebuildCache()
        {
            var contracts = Directory
                .GetFiles(CONTRACTS_PATH, "*.json")
                .Select(x =>
                {
                    var contractId = Path.GetFileNameWithoutExtension(x);

                    return (
                        key: contractId,
                        value: MapSimpleContractToContract(
                            contractId,
                            JsonSerializer.Deserialize<SimpleContract>(File.ReadAllText(x))
                        )
                    );
                });

            foreach (var (key, value) in contracts)
            {
                _contractCache.TryAdd(key, value);
            }
        }

        public string CreateContract(HitmanController.UploadContractRequest request)
        {
            var simpleContract = new SimpleContract
            {
                Title = request.Title,
                UserId = request.UserId,
                Description = request.Description,
                Targets = request.Targets,
                Restrictions = request.Restrictions,
                ExitId = request.ExitId,
                Difficulty = request.Difficulty,
                LevelIndex = request.LevelIndex,
                CheckpointIndex = request.CheckpointIndex,
                StartingOutfitToken = request.StartingOutfitToken,
                StartingWeaponToken = request.StartingWeaponToken,
                Score = request.Score
            };

            return CreateContract(simpleContract);
        }

        public string CreateContract(string compressedBase64Contract)
        {
            using var inputStream = new MemoryStream(
                Base64UrlTextEncoder.Decode(compressedBase64Contract)
            );
            using var outputStream = new MemoryStream();
            using (var compressedStream = new BrotliStream(inputStream, CompressionMode.Decompress))
            {
                compressedStream.CopyTo(outputStream);
            }
            
            var simpleContract = JsonSerializer.Deserialize<SimpleContract>(outputStream.ToArray());

            return CreateContract(simpleContract);
        }

        public void RemoveContract(string contractId)
        {
            _contractCache.TryRemove(contractId, out _);

            var contractsPath = Path.Combine(CONTRACTS_PATH, $"{contractId}.json");

            if (File.Exists(contractsPath))
            {
                File.Delete(contractsPath);
            }
        }

        public IEnumerable<Contract> GetContracts(HitmanController.SearchForContracts2Request request, Func<Contract, bool> additionalFilter = null)
        {
            return _contractCache
                .Values
                .Where(x =>
                    (request.LevelIndex == -1 || x.LevelIndex == request.LevelIndex) &&
                    (request.CheckpointId == -1 || x.CheckpointIndex == request.CheckpointId) &&
                    (request.Difficulty == -1 || x.Difficulty == request.Difficulty) &&
                    (
                        string.IsNullOrWhiteSpace(request.ContractName) ||
                        x.DisplayId.Contains(request.ContractName) ||
                        x.Title.Contains(request.ContractName, StringComparison.InvariantCultureIgnoreCase)
                    ) &&
                    (additionalFilter == null || additionalFilter(x))
                )
                .OrderBy(x => x.DisplayId)
                .Skip(request.StartIndex)
                .Take(request.Range);
        }

        public string GetShareableContractLink(string contractId)
        {
            if (!_contractCache.TryGetValue(contractId, out var contract))
            {
                return null;
            }

            var simpleContract = MapContractToSimpleContract(contract);

            var buffer = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(simpleContract));

            using var memoryStream = new MemoryStream();
            using (var compressedStream = new BrotliStream(memoryStream, CompressionLevel.Optimal))
            {
                compressedStream.Write(buffer, 0, buffer.Length);
            }

            return Base64UrlTextEncoder.Encode(memoryStream.ToArray());
        }

        public  string GetLevelName(Contract contract)
        {
            var levelIndex = contract.LevelIndex;
            var checkpointIndex = contract.CheckpointIndex;

            return levelIndex switch
            {
                0 when checkpointIndex == 40 => "Mansion Ground Floor",
                1 when checkpointIndex == 10 => "Chinatown Square",
                2 when checkpointIndex == 10 => "Terminus Hotel",
                2 when checkpointIndex == 20 => "Upper Floors",
                3 when checkpointIndex == 10 => "The Library",
                3 when checkpointIndex == 20 => "Shangri-La",
                3 when checkpointIndex == 30 => "Trainstation",
                4 when checkpointIndex == 10 => "Courtyard",
                4 when checkpointIndex == 20 => "The Vixen Club",
                4 when checkpointIndex == 30 => "Dressing Rooms",
                4 when checkpointIndex == 40 => "Derelict Building",
                4 when checkpointIndex == 50 => "Convenience Store",
                4 when checkpointIndex == 60 => "Loading Area",
                4 when checkpointIndex == 70 => "Chinese New Year",
                6 when checkpointIndex == 10 => "Orphanage Halls",
                8 when checkpointIndex == 10 => "Gun Shop",
                9 when checkpointIndex == 10 => "Streets of Hope",
                9 when checkpointIndex == 20 => "Barbershop",
                11 when checkpointIndex == 10 => "Dead End",
                11 when checkpointIndex == 20 => "Old Mill",
                11 when checkpointIndex == 30 => "Descent",
                11 when checkpointIndex == 40 => "Factory Compound",
                12 when checkpointIndex == 10 => "Test Facility",
                12 when checkpointIndex == 20 => "Decontamination",
                12 when checkpointIndex == 30 => "R&D",
                13 when checkpointIndex == 10 => "Patriot's Hangar",
                13 when checkpointIndex == 20 => "The Arena",
                14 when checkpointIndex == 10 => "Parking",
                14 when checkpointIndex == 20 => "Reception",
                14 when checkpointIndex == 30 => "Cornfield",
                17 when checkpointIndex == 10 => "Courthouse",
                17 when checkpointIndex == 20 => "Prison",
                18 when checkpointIndex == 10 => "County Jail",
                18 when checkpointIndex == 20 => "Outgunned",
                18 when checkpointIndex == 30 => "Burn",
                18 when checkpointIndex == 40 => "Hope Fair",
                22 when checkpointIndex == 10 => "Blackwater Park",
                22 when checkpointIndex == 20 => "The Penthouse",
                25 when checkpointIndex == 10 => "Cemetery Entrance",
                25 when checkpointIndex == 20 => "Burnwood Family Tomb",
                _ => "Unknown"
            };
        }

        public string GetDifficultyName(Contract contract)
        {
            return contract.Difficulty switch
            {
                0 => "Easy",
                1 => "Normal",
                2 => "Hard",
                3 => "Expert",
                4 => "Purist",
                _ => "Unknown"
            };
        }

        private string CreateContract(SimpleContract simpleContract)
        {
            var requestBytes = JsonSerializer.SerializeToUtf8Bytes(simpleContract);
            using var sha1 = SHA1.Create();
            var hashBytes = sha1.ComputeHash(requestBytes);
            var contractId = string.Join(string.Empty, hashBytes.Select(x => x.ToString("X2"))).ToLower();

            var contractsPath = Path.Combine(CONTRACTS_PATH, $"{contractId}.json");

            if (File.Exists(contractsPath))
            {
                return contractId;
            }

            var contract = MapSimpleContractToContract(contractId, simpleContract);
            _contractCache.TryAdd(contractId, contract);

            var contractJson = JsonSerializer.Serialize(simpleContract);

            File.WriteAllTextAsync(contractsPath, contractJson);

            return contractId;
        }

        private Contract MapSimpleContractToContract(string contractId, SimpleContract simpleContract)
        {
            return new Contract
            {
                Id = contractId,
                DisplayId = simpleContract.Title,
                UserId = simpleContract.UserId,
                UserName = simpleContract.UserId,
                Title = simpleContract.Title,
                Description = simpleContract.Description,
                Targets = new TargetsWrapper
                {
                    Targets = simpleContract.Targets
                },
                Restrictions = new RestrictionsWrapper
                {
                    Restrictions = simpleContract.Restrictions
                },
                ExitId = simpleContract.ExitId,
                Difficulty = simpleContract.Difficulty,
                LevelIndex = simpleContract.LevelIndex,
                CheckpointIndex = simpleContract.CheckpointIndex,
                StartingOutfitToken = simpleContract.StartingOutfitToken,
                StartingWeaponToken = simpleContract.StartingWeaponToken,
                HighestScoringFriendName = simpleContract.UserId,
                HighestScoringFriendScore = simpleContract.Score
            };
        }

        private SimpleContract MapContractToSimpleContract(Contract contract)
        {
            return new SimpleContract
            {
                Title = contract.Title,
                UserId = contract.UserId,
                Description = contract.Description,
                Targets = contract.Targets.Targets,
                Restrictions = contract.Restrictions.Restrictions,
                ExitId = contract.ExitId,
                Difficulty = contract.Difficulty,
                LevelIndex = contract.LevelIndex,
                CheckpointIndex = contract.CheckpointIndex,
                StartingOutfitToken = contract.StartingOutfitToken,
                StartingWeaponToken = contract.StartingWeaponToken,
                Score = contract.UserScore
            };
        }
    }
}
