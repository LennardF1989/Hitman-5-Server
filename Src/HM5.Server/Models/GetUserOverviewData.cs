using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;

namespace HM5.Server.Models
{
    [EdmEntity("GetUserOverviewData")]
    public class GetUserOverviewData : IEdmEntity
    {
        [EdmProperty("WalletAmount", EdmTypes.Int32, false)]
        public int WalletAmount { get; set; }

        [EdmProperty("ContractPlays", EdmTypes.Int32, false)]
        public int ContractPlays { get; set; }

        [EdmProperty("RichestRank", EdmTypes.Int32, false)]
        public int RichestRank { get; set; }

        [EdmProperty("RichestAverage", EdmTypes.Int32, false)]
        public int RichestAverage { get; set; }

        [EdmProperty("TrophiesEarned", EdmTypes.Int32, false)]
        public int TrophiesEarned { get; set; }

        [EdmProperty("CompetitionPlays", EdmTypes.Int32, false)]
        public int CompetitionPlays { get; set; }

        [EdmProperty("DeadliestRank", EdmTypes.Int32, false)]
        public int DeadliestRank { get; set; }

        [EdmProperty("DeadliestAverage", EdmTypes.Int32, false)]
        public int DeadliestAverage { get; set; }

        [EdmProperty("ContractsCreated", EdmTypes.Int32, false)]
        public int ContractsCreated { get; set; }

        [EdmProperty("ContractsCreatedLikes", EdmTypes.Int32, false)]
        public int ContractsCreatedLikes { get; set; }

        [EdmProperty("PopularRank", EdmTypes.Int32, false)]
        public int PopularRank { get; set; }

        [EdmProperty("PopularAverage", EdmTypes.Int32, false)]
        public int PopularAverage { get; set; }
    }
}
