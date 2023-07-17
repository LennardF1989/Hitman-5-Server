using HM5.Server.Controllers.Hitman;
using HM5.Server.Models;

namespace HM5.Server.Interfaces
{
    public interface IContractsService
    {
        void RebuildCache();
        void CreateContract(HitmanController.UploadContractRequest request);
        void CreateContract(string compressedBase64Contract);
        void RemoveContract(string contractId);
        IEnumerable<Contract> GetContracts(HitmanController.SearchForContracts2Request request);
        string GetShareableContractLink(string contractId);
        string GetLevelName(Contract contract);
        string GetDifficultyName(Contract contract);
    }
}