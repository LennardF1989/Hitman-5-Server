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

        [EdmFunctionImport("FunctionImportTest", HttpMethods.GET, "Test.EntityTest")]
        public class TestFunctionImportValid : IEdmFunctionImport
        {
            [SFunctionParameter("_stringValue", EdmTypes.String)]
            public string StringValue { get; set; }
        }

        public class TestFunctionImportInvalid1
        {
            //Do nothing
        }

        [EdmFunctionImport("FunctionImportTest", HttpMethods.GET, "Test.EntityTest")]
        public class TestFunctionImportInvalid2
        {
            //Do nothing
        }

        public class TestFunctionImportInvalid3 : IEdmFunctionImport
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
                new List<Type>()
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
                new List<Type>()
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();
            var entityType = schema.EntityTypes.Single();

            var entityExpected = new EdmEntityType
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
            };

            Assert.Equivalent(entityExpected, entityType);
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
                new List<Type>()
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();

            Assert.Empty(schema.EntityTypes);
        }

        [Fact]
        public void SingleSchema_HasSingleFunctionImport()
        {
            var metadataService = new MetadataService(
                "Test",
                new List<Type>(),
                new List<Type>
                {
                    typeof(TestFunctionImportValid)
                }
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();
            var entityContainer = schema.EntityContainers.Single();
            var functionImport = entityContainer.FunctionImports.Last();

            var functionImportExpected = new EdmFunctionImport
            {
                Name = "FunctionImportTest",
                HttpMethod = HttpMethods.GET,
                ReturnType = "Test.EntityTest",
                Parameters = new List<SFunctionParameter>
                {
                    new()
                    {
                        Name = "_stringValue",
                        Type = EdmTypes.String
                    }
                }
            };
            
            Assert.Equivalent(functionImportExpected, functionImport);
        }

        [Fact]
        public void SingleSchema_DoesNotContain_FunctionImportWithoutAttributeAndOrInterface()
        {
            var metadataService = new MetadataService(
                "Test",
                new List<Type>(),
                new List<Type>
                {
                    typeof(TestFunctionImportInvalid1),
                    typeof(TestFunctionImportInvalid2),
                    typeof(TestFunctionImportInvalid3)
                }
            );

            var metadata = metadataService.GetMetadata();
            var schema = metadata.Schemas.Single();
            var entityContainer = schema.EntityContainers.Single();

            //NOTE: Skip the four default functions
            Assert.Empty(entityContainer.FunctionImports.Skip(4));
        }
    }
}