using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using HM5.Server.Json;
using HM5.Server.Models;
using Nullable = HM5.Server.Enums.Nullable;

namespace HM5.Test
{
    public class JsonConverterTests
    {
        //NOTE: This should mimic the options used by the server!
        private readonly JsonSerializerOptions _defaultJsonSerializerOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        [Theory]
        [InlineData(true, $"\"{Nullable.True}\"")]
        [InlineData(false, $"\"{Nullable.False}\"")]
        public void Boolean_IsConvertedToString(bool input, string expected)
        {
            using var memoryStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memoryStream);

            new BooleanToStringConverter().Write(
                jsonWriter,
                input,
                null
            );

            jsonWriter.Flush();

            var actual = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(47, "\"47\"")]
        [InlineData(101, "\"101\"")]
        [InlineData(1337, "\"1337\"")]
        [InlineData(-47, "\"-47\"")]
        public void Integer_IsConvertedToString(int input, string expected)
        {
            using var memoryStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memoryStream);

            new IntegerToStringConverter().Write(
                jsonWriter,
                input,
                null
            );

            jsonWriter.Flush();

            var actual = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4.7, "\"4.7\"")]
        [InlineData(10.1, "\"10.1\"")]
        [InlineData(13.37, "\"13.37\"")]
        [InlineData(-4.7, "\"-4.7\"")]
        public void Float_IsConvertedToString(float input, string expected)
        {
            using var memoryStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memoryStream);

            new FloatToStringConverter().Write(
                jsonWriter,
                input,
                null
            );

            jsonWriter.Flush();

            var actual = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.Equal(expected, actual);
        }

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<object[]> Any_IsConvertedToJsonString_Data =>
            new List<object[]>
            {
                new object[] { 47, "\"47\"" },
                new object[] { "47", "\"\\\"47\\\"\"" },
                new object[] { true, "\"true\"" },
                new object[] { false, "\"false\"" },
                new object[] { 4.7f, "\"4.7\"" },
                new object[]
                {
                    new Competition
                    {
                        Id = 47,
                        EndTimeUTC = DateTime.Parse("2023-1-1"),
                        AllowInvites = false,
                        CompetitionCreator = "Test",
                        DaysRemaining = 47
                    },
                    "\"{" +
                    "\\\"_id\\\":\\\"47\\\"," +
                    "\\\"EndTimeUTC\\\":\\\"2023-01-01T00:00:00\\\"," +
                    "\\\"AllowInvites\\\":false," +
                    "\\\"CompetitionCreator\\\":\\\"Test\\\"," +
                    "\\\"DaysRemaining\\\":47" +
                    "}\""
                }
            };

        [Theory]
        [MemberData(nameof(Any_IsConvertedToJsonString_Data))]
        public void Any_IsConvertedToJsonString(object input, string expected)
        {
            using var memoryStream = new MemoryStream();
            var jsonWriter = new Utf8JsonWriter(memoryStream, new JsonWriterOptions
            {
                Encoder = _defaultJsonSerializerOptions.Encoder
            });

            new AnyToJsonStringConverter<object>().Write(
                jsonWriter,
                input,
                null
            );

            jsonWriter.Flush();

            var actual = Encoding.UTF8.GetString(memoryStream.ToArray());

            Assert.Equal(expected, actual);
        }
    }
}