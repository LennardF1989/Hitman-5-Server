using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using System.Text.Json.Serialization;

namespace HM5.Server.Models
{
    [EdmEntity("Message")]
    public class Message : IEdmEntity
    {
        //NOTE: Even though this is treated as a String in-game, we always assign an Integer.
        [JsonPropertyName("_id")]
        [EdmProperty("_id", EdmTypes.String, false)]
        public int Id { get; set; }

        [EdmProperty("FromId", EdmTypes.String, false)]
        public string FromId { get; set; }

        [EdmProperty("TimestampUTC", EdmTypes.Int64, false)]
        public long TimestampUTC { get; set; }

        [EdmProperty("IsRead", EdmTypes.Boolean, false)]
        public bool IsRead { get; set; }

        [EdmProperty("TextTemplateId", EdmTypes.Int32, false)]
        public int TextTemplateId { get; set; }

        [EdmProperty("TemplateData", EdmTypes.String, false)]
        public string TemplateData { get; set; }
    }
}
