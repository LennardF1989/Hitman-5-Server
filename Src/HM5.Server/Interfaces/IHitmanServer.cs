using HM5.Server.Controllers.Hitman;
using HM5.Server.Models;

namespace HM5.Server.Interfaces
{
    public interface IHitmanServer
    {
        void Initialize();
        int ExecuteWalletTransaction(HitmanController.ExecuteWalletTransactionRequest request);
        List<int> GetAverageScores(HitmanController.BaseGetAverageScoresRequest request);
        List<ScoreEntry> GetScores(HitmanController.BaseGetScoresRequest request);
        List<Message> GetMessages(HitmanController.GetMessagesRequest request);
        Contract GetFeaturedContract(HitmanController.GetFeaturedContractRequest request);
        int GetNewMessageCount(HitmanController.GetNewMessageCountRequest request);
        GetUserOverviewData GetUserOverviewData(HitmanController.GetUserOverviewDataRequest request);
        int GetUserWallet(HitmanController.GetUserWalletRequest request);
        void MarkContractAsPlayed(HitmanController.MarkContractAsPlayedRequest request);
        int PutScore(HitmanController.PutScoreRequest request);
        void QueueAddContract(HitmanController.QueueAddContractRequest request);
        void QueueRemoveContract(HitmanController.QueueRemoveContractRequest request);
        List<Contract> SearchForContracts2(HitmanController.SearchForContracts2Request request);
        void UpdateUserInfo(HitmanController.UpdateUserInfoRequest request);
        void UploadContract(HitmanController.UploadContractRequest request);
        ScoreComparison GetScoreComparison(HitmanController.GetScoreComparisonRequest request);
    }
}
