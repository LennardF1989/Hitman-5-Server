using System.Globalization;
using System.Text.Json.Serialization;
using HM5.Server.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Primitives;

namespace HM5.Test
{
    public class ModelBinderTests
    {
        public class TestModel
        {
            [JsonPropertyName("_id")]
            public int Id { get; set; }
        }

        // ReSharper disable UnassignedGetOnlyAutoProperty
        public class TestModelMetadata : ModelMetadata
        {
            public override IReadOnlyDictionary<object, object> AdditionalValues { get; }
            public override ModelPropertyCollection Properties { get; }
            public override string BinderModelName { get; }
            public override Type BinderType { get; }
            public override BindingSource BindingSource { get; }
            public override bool ConvertEmptyStringToNull { get; }
            public override string DataTypeName { get; }
            public override string Description { get; }
            public override string DisplayFormatString { get; }
            public override string DisplayName { get; }
            public override string EditFormatString { get; }
            public override ModelMetadata ElementMetadata { get; }
            public override IEnumerable<KeyValuePair<EnumGroupAndName, string>> EnumGroupedDisplayNamesAndValues { get; }
            public override IReadOnlyDictionary<string, string> EnumNamesAndValues { get; }
            public override bool HasNonDefaultEditFormat { get; }
            public override bool HtmlEncode { get; }
            public override bool HideSurroundingHtml { get; }
            public override bool IsBindingAllowed { get; }
            public override bool IsBindingRequired { get; }
            public override bool IsEnum { get; }
            public override bool IsFlagsEnum { get; }
            public override bool IsReadOnly { get; }
            public override bool IsRequired { get; }
            public override ModelBindingMessageProvider ModelBindingMessageProvider { get; }
            public override int Order { get; }
            public override string Placeholder { get; }
            public override string NullDisplayText { get; }
            public override IPropertyFilterProvider PropertyFilterProvider { get; }
            public override bool ShowForDisplay { get; }
            public override bool ShowForEdit { get; }
            public override string SimpleDisplayProperty { get; }
            public override string TemplateHint { get; }
            public override bool ValidateChildren { get; }
            public override IReadOnlyList<object> ValidatorMetadata { get; }
            public override Func<object, object> PropertyGetter { get; }
            public override Action<object, object> PropertySetter { get; }

            public TestModelMetadata(Type modelType)
                : base(ModelMetadataIdentity.ForType(modelType))
            {
                //Do nothing
            }
        }
        // ReSharper enable UnassignedGetOnlyAutoProperty

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("''", "")]
        [InlineData("' '", " ")]
        [InlineData("'47'", "47")]
        [InlineData("''47''", "47")]
        [InlineData("47'", "47")]
        [InlineData("'47", "47")]
        [InlineData("47", "47")]
        public async Task String_Is_Normalized(string input, string expected)
        {
            var modelBinder = new NormalizedStringModelBinder();

            var context = new DefaultModelBindingContext
            {
                ModelName = "_stringValue",
                ValueProvider = new QueryStringValueProvider(
                    BindingSource.Query,
                    new QueryCollection(
                        new Dictionary<string, StringValues>
                        {
                            { "_stringValue", new StringValues(input) }
                        }
                    ),
                    CultureInfo.InvariantCulture
                )
            };

            await modelBinder.BindModelAsync(context);

            Assert.Equal(expected, context.Result.Model);
        }

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<object[]> String_Is_NormalizedAndSplitted_Data =>
            new List<object[]>
            {
                new object[] { null, null },
                new object[] { "", new List<string>() },
                new object[] { "''", new List<string>() },
                new object[] { "' '", new List<string>() },
                new object[] { "'47'", new List<string> { "47" } },
                new object[] { "'47,'", new List<string> { "47" } },
                new object[] { "'47, '", new List<string> { "47" } },
                new object[] { "'47,47'", new List<string> { "47", "47" } },
                new object[] { "'47 , 47'", new List<string> { "47", "47" } },
                new object[] { "',47'", new List<string> { "47" } },
                new object[] { "'47;'", new List<string> { "47" } },
                new object[] { "'47;47'", new List<string> { "47", "47" } },
                new object[] { "';47'", new List<string> { "47" } }
            };

        [Theory]
        [MemberData(nameof(String_Is_NormalizedAndSplitted_Data))]
        public async Task String_Is_NormalizedAndSplitted(string input, List<string> expected)
        {
            var modelBinder = new SplitNormalizedStringModelBinder();

            var context = new DefaultModelBindingContext
            {
                ModelName = "_stringValue",
                ValueProvider = new QueryStringValueProvider(
                    BindingSource.Query,
                    new QueryCollection(
                        new Dictionary<string, StringValues>
                        {
                            { "_stringValue", new StringValues(input) }
                        }
                    ),
                    CultureInfo.InvariantCulture
                )
            };

            await modelBinder.BindModelAsync(context);

            Assert.Equal(expected, context.Result.Model);
        }

        // ReSharper disable once InconsistentNaming
        public static IEnumerable<object[]> String_Is_NormalizedAndJsonDeserialized_Data =>
            new List<object[]>
            {
                new object[] { null, null },
                new object[] { "", null },
                new object[] { "''", null },
                new object[] { "' '", null },
                new object[] { "'\"47\"'", "47" },
                new object[] { "'47'", 47 },
                new object[] { "'4.7'", 4.7f },
                new object[] { "'[]'", new List<TestModel>() },
                new object[]
                {
                    "'[{\"_id\":47},{\"_id\":47}]'", 
                    new List<TestModel> { new() { Id = 47 }, new() { Id = 47 } }
                },
                new object[] { "'{\"_id\":47}'", new TestModel { Id = 47 } }
            };

        [Theory]
        [MemberData(nameof(String_Is_NormalizedAndJsonDeserialized_Data))]
        public async Task String_Is_NormalizedAndJsonDeserialized(string input, object expectedValue)
        {
            var modelBinder = new NormalizedJsonStringModelBinder();

            var context = new DefaultModelBindingContext
            {
                ModelName = "_stringValue",
                ModelMetadata = new TestModelMetadata(expectedValue?.GetType() ?? typeof(string)),
                ValueProvider = new QueryStringValueProvider(
                    BindingSource.Query,
                    new QueryCollection(
                        new Dictionary<string, StringValues>
                        {
                            { "_stringValue", new StringValues(input) }
                        }
                    ),
                    CultureInfo.InvariantCulture
                )
            };

            await modelBinder.BindModelAsync(context);

            Assert.Equivalent(expectedValue, context.Result.Model);
        }
    }
}
