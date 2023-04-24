using HM5.Server.Controllers;
using HM5.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using HM5.Server.Json;

namespace HM5.Test
{
    public class BaseControllerTests
    {
        public class TestClass
        {
            public int Id { get; set; }
            public string Value { get; set; }
            public bool IsImportant { get; set; }
            public float Percentage { get; set; }
        }

        public class TestEntity : IEdmEntity
        {
            public string StringValue { get; set; }
            public int IntegerValue { get; set; }
            public bool BooleanValue { get; set; }
            public float FloatValue { get; set; }

            [JsonConverter(typeof(AnyToJsonStringConverter<List<TestClass>>))]
            public List<TestClass> JsonStringValue { get; set; }
        }

        public class TestController : BaseController
        {
            public TestController() 
                : base(null)
            {
                //Do nothing
            }

            public IActionResult TestGenericResponse<T>(T data)
            {
                return JsonGenericResponse(data);
            }

            public IActionResult TestOperationValueResponse<T>(T data)
            {
                return JsonOperationValueResponse(data);
            }

            public IActionResult TestOperationListResponse<T>(List<T> data)
            {
                return JsonOperationListResponse(data);
            }

            public IActionResult TestEntryResponse<T>(T data)
                where T : IEdmEntity
            {
                return JsonEntryResponse(data);
            }

            public IActionResult TestFeedResponse<T>(List<T> data)
                where T : IEdmEntity
            {
                return JsonFeedResponse(data);
            }
        }

        //NOTE: This should FULLY mimic the options used by the server!
        private readonly JsonSerializerOptions _defaultJsonSerializerOptions = new()
        {
            PropertyNamingPolicy = null,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters =
            {
                new BooleanToStringConverter(),
                new FloatToStringConverter(),
                new IntegerToStringConverter()
            }
        };

        private readonly TestController _testController;

        public BaseControllerTests()
        {
            _testController = new TestController();
        }

        [Fact]
        public void JsonGenericResponse_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestGenericResponse(new TestClass
            {
                Id = 47,
                Value = "Test",
                IsImportant = true,
                Percentage = 0.47f
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal(
                "{\"d\":{\"Id\":\"47\",\"Value\":\"Test\",\"IsImportant\":\"true\",\"Percentage\":\"0.47\"}}",
                actual
            );
        }

        [Fact]
        public void JsonOperationValueResponse_WithInteger_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationValueResponse(47);

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":{\"Key\":\"47\"}}", actual);
        }

        [Fact]
        public void JsonOperationValueResponse_WithFloat_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationValueResponse(4.7f);

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":{\"Key\":\"4.7\"}}", actual);
        }

        [Fact]
        public void JsonOperationValueResponse_WithString_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationValueResponse("Test");

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":{\"Key\":\"Test\"}}", actual);
        }

        [Fact]
        public void JsonOperationListResponse_WithIntegers_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationListResponse(new List<int>
            {
                1,
                2,
                3
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":[\"1\",\"2\",\"3\"]}", actual);
        }

        [Fact]
        public void JsonOperationListResponse_WithFloats_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationListResponse(new List<float>
            {
                1,
                -2.1f,
                3.4f
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":[\"1\",\"-2.1\",\"3.4\"]}", actual);
        }

        [Fact]
        public void JsonOperationListResponse_WithStrings_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestOperationListResponse(new List<string>
            {
                "Test 1",
                "Test 2",
                "Test 3"
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal("{\"d\":[\"Test 1\",\"Test 2\",\"Test 3\"]}", actual);
        }

        [Fact]
        public void JsonEntryResponse_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestEntryResponse(new TestEntity
            {
                StringValue = "Test",
                IntegerValue = 47,
                BooleanValue = true,
                FloatValue = 4.7f,
                JsonStringValue = new List<TestClass>
                {
                    new()
                    {
                        Id = 47,
                        Value = "Test",
                        IsImportant = true,
                        Percentage = 0.47f
                    }
                }
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal(
                "{\"d\":{" +
                "\"results\":{" +
                "\"StringValue\":\"Test\"," +
                "\"IntegerValue\":\"47\"," +
                "\"BooleanValue\":\"true\"," +
                "\"FloatValue\":\"4.7\"," +
                "\"JsonStringValue\":\"[" +
                "{\\\"Id\\\":47,\\\"Value\\\":\\\"Test\\\",\\\"IsImportant\\\":true,\\\"Percentage\\\":0.47}" +
                "]\"}}}",
                actual
            );
        }

        [Fact]
        public void JsonFeedResponse_ProducesCorrectResult()
        {
            var actionResult = (JsonResult)_testController.TestFeedResponse(new List<TestEntity>
            {
                new()
                {
                    StringValue = "Test 1"
                },
                new()
                {
                    StringValue = "Test 2"
                },
                new()
                {
                    StringValue = "Test 3"
                }
            });

            var actual = JsonSerializer.Serialize(actionResult.Value, _defaultJsonSerializerOptions);

            Assert.Equal(
                "{\"d\":{" +
                "\"results\":[" +
                "{\"StringValue\":\"Test 1\",\"IntegerValue\":\"0\",\"BooleanValue\":\"false\",\"FloatValue\":\"0\"}," +
                "{\"StringValue\":\"Test 2\",\"IntegerValue\":\"0\",\"BooleanValue\":\"false\",\"FloatValue\":\"0\"}," +
                "{\"StringValue\":\"Test 3\",\"IntegerValue\":\"0\",\"BooleanValue\":\"false\",\"FloatValue\":\"0\"}]," +
                "\"__count\":\"3\"}}", 
                actual
            );
        }
    }
}