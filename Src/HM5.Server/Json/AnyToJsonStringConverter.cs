using System.Text.Json;
using System.Text.Json.Serialization;

namespace HM5.Server.Json
{
    public class AnyToJsonStringConverter<T> : JsonConverter<T>
    {
        public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            //NOTE: options is purposely not passed on to the Serialize method, since the in-game JSON parser used to Deserialize this actually works fine with the default options.
            writer.WriteStringValue(JsonSerializer.Serialize(value));
        }
    }
}
