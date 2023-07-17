using HM5.Server.Controllers.Hitman;
using HM5.Server.Interfaces;
using HM5.Server.Models;

namespace HM5.Server.Services
{
    public class LocalHitmanServer : IHitmanServer
    {
        private static readonly List<int> _mockedGetAverageScoresResponse = new()
        {
            0, //World Average
            0, //Country Average
            0, //Friends Average
            0 //Score: Deadliest / Richest / Most Popular Assassin
        };

        private static readonly List<ScoreEntry> _mockedGetScoresResponse = new();

        private readonly IContractsService _contractsService;

        private GetUserOverviewData _userOverviewData;

        public LocalHitmanServer(IContractsService contractsService)
        {
            _contractsService = contractsService;
        }

        public void Initialize()
        {
            Directory.CreateDirectory("Contracts");

            _contractsService.RebuildCache();

            _userOverviewData = new GetUserOverviewData
            {
                WalletAmount = 0
            };
        }

        public int ExecuteWalletTransaction(HitmanController.ExecuteWalletTransactionRequest request)
        {
            return 0;
        }

        public List<int> GetAverageScores(HitmanController.BaseGetAverageScoresRequest request)
        {
            return _mockedGetAverageScoresResponse;
        }

        public List<ScoreEntry> GetScores(HitmanController.BaseGetScoresRequest request)
        {
            return _mockedGetScoresResponse;
        }

        public List<Message> GetMessages(HitmanController.GetMessagesRequest request)
        {
            return new List<Message>();
        }

        public Contract GetFeaturedContract(HitmanController.GetFeaturedContractRequest request)
        {
            return null;
        }

        public int GetNewMessageCount(HitmanController.GetNewMessageCountRequest request)
        {
            return 0;
        }

        public GetUserOverviewData GetUserOverviewData(HitmanController.GetUserOverviewDataRequest request)
        {
            return _userOverviewData;
        }

        public int GetUserWallet(HitmanController.GetUserWalletRequest request)
        {
            return _userOverviewData.WalletAmount;
        }

        public void MarkContractAsPlayed(HitmanController.MarkContractAsPlayedRequest request)
        {
            //Do nothing
        }

        public int PutScore(HitmanController.PutScoreRequest request)
        {
            return 0;
        }

        public void QueueAddContract(HitmanController.QueueAddContractRequest request)
        {
            //Do nothing
        }

        public void QueueRemoveContract(HitmanController.QueueRemoveContractRequest request)
        {
            //Do nothing
        }

        public List<Contract> SearchForContracts2(HitmanController.SearchForContracts2Request request)
        {
            var contracts = _contractsService.GetContracts(request);

            return contracts.ToList();
        }

        public void UpdateUserInfo(HitmanController.UpdateUserInfoRequest request)
        {
            //Do nothing
        }

        public void UploadContract(HitmanController.UploadContractRequest request)
        {
            _contractsService.CreateContract(request);
        }
    }
}
