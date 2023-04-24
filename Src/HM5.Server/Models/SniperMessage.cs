using System.Text.Json.Serialization;
using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;

namespace HM5.Server.Models
{
    [EdmEntity("Message")]
    public class SniperMessage : IEdmEntity
    {
        //NOTE: Even though this is treated as a String in-game, we always assign an Integer.
        [JsonPropertyName("_id")]
        [EdmProperty("_id", EdmTypes.String, false)]
        public int Id { get; set; }

        [EdmProperty("FromId", EdmTypes.String, false)]
        public string FromId { get; set; }

        [EdmProperty("Category", EdmTypes.Int32, false)]
        public int Category { get; set; }

        [EdmProperty("TimestampUTC", EdmTypes.Int64, false)]
        public long TimestampUTC { get; set; }

        [EdmProperty("TextTemplateId", EdmTypes.Int32, false)]
        public int TextTemplateId { get; set; }

        [EdmProperty("TemplateData", EdmTypes.String, false)]
        public string TemplateData { get; set; }
    }
}