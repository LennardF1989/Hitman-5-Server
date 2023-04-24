using System.Text.Json;
using System.Text.Json.Serialization;
using Nullable = HM5.Server.Enums.Nullable;

namespace HM5.Server.Json
{
    public class BooleanToStringConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? Nullable.True : Nullable.False);
        }
    }
}
