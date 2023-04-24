using System.Text.Json.Serialization;

namespace HM5.Server.Models.Response
{
    public class EntryObject<T>
    {
        [JsonPropertyName("results")]
        public T Results { get; set; }
    }
}