using System.Text.Json;
using HM5.Server.Attributes;
using HM5.Server.Enums;
using HM5.Server.Interfaces;
using HM5.Server.Models.Base;
using HM5.Server.Services;

namespace HM5.Test
{
    public class MetadataServiceTests
    {
        [EdmEntity("EntityTest")]
        public class TestEntityValid : IEdmEntity
        {
            [EdmProperty("_stringValue", EdmTypes.String, true)]
            public string StringValue { get; set; }
        }

        public class TestEntityInvalid1
        {
            //Do nothing
        }

        [EdmEntity("EntityTest")]
        public class TestEntityInvalid2
        {
            //Do nothing
        }

        public class TestEntityInvalid3 : IEdmEntity
        {
            //Do nothing
        }

        [Fact]
        public void SingleSchema_HasNamespace()
        {
            var expectedNamespace = "Test";

            var metadataService = new MetadataService(
                expectedNamespace, 
                new List<Type>(), 
                new List<EdmFunctionImport>()
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();

            Assert.Equal(expectedNamespace, schema.Namespace);
        }

        [Fact]
        public void SingleSchema_HasSingleEntityType()
        {
            var metadataService = new MetadataService(
                "Test",
                new List<Type>
                {
                    typeof(TestEntityValid)
                },
                new List<EdmFunctionImport>()
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();
            var entityType = schema.EntityTypes.Single();

            var entityExpected = JsonSerializer.Serialize(new EdmEntityType
            {
                Name = "EntityTest",
                Properties = new List<EdmProperty>
                {
                    new()
                    {
                        Name = "_stringValue",
                        Type = EdmTypes.String,
                        Nullable = true
                    }
                }
            });

            var entityActual = JsonSerializer.Serialize(entityType);

            Assert.Equal(entityExpected, entityActual);
        }

        [Fact]
        public void SingleSchema_DoesNotContain_EntityTypeWithoutAttributeAndOrInterface()
        {
            var metadataService = new MetadataService(
                "Test",
                new List<Type>
                {
                    typeof(TestEntityInvalid1),
                    typeof(TestEntityInvalid2),
                    typeof(TestEntityInvalid3)
                },
                new List<EdmFunctionImport>()
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();

            Assert.Empty(schema.EntityTypes);
        }

        [Fact]
        public void SingleSchema_HasSingleEntityContainer_ContainsFunctionImport()
        {
            var functionImport = new EdmFunctionImport
            {
                HttpMethod = HttpMethods.GET,
                Name = "Test",
                ReturnType = "Test",
                Parameters = new List<SFunctionParameter>
                {
                    new()
                    {
                        Name = "Test",
                        Type = "Test"
                    }
                }
            };

            var metadataService = new MetadataService(
                "Test",
                new List<Type>(),
                new List<EdmFunctionImport>
                {
                    functionImport
                }
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();
            var entityContainer = schema.EntityContainers.Single();

            Assert.Contains(functionImport, entityContainer.FunctionImports);
        }
    }
}