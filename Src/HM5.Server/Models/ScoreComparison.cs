using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;

namespace HM5.Server.Models
{
    [EdmEntity("ScoreComparison")]
    public class ScoreComparison : IEdmEntity
    {
        [EdmProperty("FriendName", EdmTypes.String, false)]
        public string FriendName { get; set; }

        [EdmProperty("FriendScore", EdmTypes.Int32, false)]
        public int FriendScore { get; set; }

        [EdmProperty("CountryAverage", EdmTypes.Int32, false)]
        public int CountryAverage { get; set; }

        [EdmProperty("WorldAverage", EdmTypes.Int32, false)]
        public int WorldAverage { get; set; }
    }
}
