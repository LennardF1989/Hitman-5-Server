using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;

namespace HM5.Server.Models
{
    [EdmEntity("ScoreEntry")]
    public class ScoreEntry : IEdmEntity
    {
        [EdmProperty("Rank", EdmTypes.Int32, false)]
        public int Rank { get; set; }

        [EdmProperty("UserId", EdmTypes.String, false)]
        public string UserId { get; set; }

        [EdmProperty("Score", EdmTypes.Int32, false)]
        public int Score { get; set; }

        [EdmProperty("Rating", EdmTypes.Int32, false)]
        public int Rating { get; set; }
    }
}
