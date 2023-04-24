using System.Text.Json.Serialization;

namespace HM5.Server.Models.Response
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("d")]
        public T Data { get; set; }
    }
}
