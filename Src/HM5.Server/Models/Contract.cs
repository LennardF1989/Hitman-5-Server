using System.Text.Json.Serialization;
using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Json;

namespace HM5.Server.Models
{
    [EdmEntity("Contract")]
    public class Contract : IEdmEntity
    {
        [JsonPropertyName("_id")]
        [EdmProperty("_id", EdmTypes.String, false)]
        public string Id { get; set; }

        [EdmProperty("DisplayId", EdmTypes.String, false)]
        public string DisplayId { get; set; }

        [EdmProperty("LevelIndex", EdmTypes.Int32, false)]
        public int LevelIndex { get; set; }

        [EdmProperty("CheckpointIndex", EdmTypes.Int32, false)]
        public int CheckpointIndex { get; set; }

        [EdmProperty("Difficulty", EdmTypes.Int32, false)]
        public int Difficulty { get; set; }

        [EdmProperty("ExitId", EdmTypes.Int32, false)]
        public int ExitId { get; set; }

        [EdmProperty("UserId", EdmTypes.String, false)]
        public string UserId { get; set; }

        [EdmProperty("UserName", EdmTypes.String, false)]
        public string UserName { get; set; }

        [EdmProperty("Likes", EdmTypes.Int32, false)]
        public int Likes { get; set; }

        [EdmProperty("Dislikes", EdmTypes.Int32, false)]
        public int Dislikes { get; set; }

        [EdmProperty("Plays", EdmTypes.Int32, false)]
        public int Plays { get; set; }

        [EdmProperty("UserScore", EdmTypes.Int32, false)]
        public int UserScore { get; set; }

        [EdmProperty("Title", EdmTypes.String, false)]
        public string Title { get; set; }

        [EdmProperty("Description", EdmTypes.String, false)]
        public string Description { get; set; }

        [EdmProperty("CompetitionLeader", EdmTypes.String, false)]
        public string CompetitionLeader { get; set; }

        [EdmProperty("CompetitionHighestScore", EdmTypes.Int32, false)]
        public int CompetitionHighestScore { get; set; }

        [EdmProperty("HighestScoringFriendName", EdmTypes.String, false)]
        public string HighestScoringFriendName { get; set; }

        [EdmProperty("HighestScoringFriendScore", EdmTypes.Int32, false)]
        public int HighestScoringFriendScore { get; set; }

        [EdmProperty("StartingWeaponToken", EdmTypes.Int32, false)]
        public int StartingWeaponToken { get; set; }

        [EdmProperty("StartingOutfitToken", EdmTypes.Int32, false)]
        public int StartingOutfitToken { get; set; }

        [JsonConverter(typeof(AnyToJsonStringConverter<TargetsWrapper>))]
        [EdmProperty("Targets", EdmTypes.String, false)]
        public TargetsWrapper Targets { get; set; }

        [JsonConverter(typeof(AnyToJsonStringConverter<RestrictionsWrapper>))]
        [EdmProperty("Restrictions", EdmTypes.String, false)]
        public RestrictionsWrapper Restrictions { get; set; }

        [JsonConverter(typeof(AnyToJsonStringConverter<CompetitionWrapper>))]
        [EdmProperty("Competition", EdmTypes.String, false)]
        public CompetitionWrapper Competition { get; set; }
    }
}
