using System.Reflection;
using HM5.Server.Attributes;
using HM5.Server.Interfaces;
using HM5.Server.Models;
using HM5.Server.Models.Base;

namespace HM5.Server.Services
{
    public class MetadataService : IMetadataServiceForHitman, IMetadataServiceForSniper
    {
        private readonly OSMetadata _metadata;

        public MetadataService(
            string schemaNamespace, 
            List<Type> edmEntityTypes, 
            List<EdmFunctionImport> edmFunctionImports
        )
        {
            _metadata = BuildMetadata(
                schemaNamespace,
                edmEntityTypes, 
                edmFunctionImports
            );
        }

        private OSMetadata BuildMetadata(
            string schemaNamespace,
            List<Type> edmEntityTypes, 
            List<EdmFunctionImport> edmImportFunctions
        )
        {
            var entityTypes = BuildEdmEntityTypes(edmEntityTypes);
            var importFunctions = BuildEdmImportFunctions();
            importFunctions.AddRange(edmImportFunctions);

            return new OSMetadata
            {
                ClientConfiguration = new EdmClientConfiguration
                {
                    UsageTrackingEnabled = false
                    //UsageTrackingSamplingInterval = 60_000,
                    //UsageTrackingMetricsInterval = 60_000,
                    //MetricsThreshold = 0,
                    //MetricsPriorityThreshold = 0
                },
                Schemas = new List<OSMetadata.Schema>
                {
                    new()
                    {
                        Namespace = schemaNamespace,
                        EntityTypes = entityTypes,
                        //ComplexTypes = null,
                        //Associations = null,
                        EntityContainers = new List<OSMetadata.EntityContainer>
                        {
                            new()
                            {
                                FunctionImports = importFunctions
                            }
                        }
                    }
                }
            };
        }

        private List<EdmFunctionImport> BuildEdmImportFunctions()
        {
            //NOTE: Most likely unused
            var functionNames = new List<string>
            {
                "DecreaseConsumables",
                "IncreaseConsumables",
                "consumables", //EntitySet
                "transactions" //EntitySet
            };

            var functions = functionNames.Select(x => new EdmFunctionImport
            {
                Name = x,
                HttpMethod = HttpMethods.POST
            }).ToList();

            return functions;
        }

        private List<EdmEntityType> BuildEdmEntityTypes(List<Type> edmEntityTypes)
        {
            return edmEntityTypes
                .Where(x =>
                    typeof(IEdmEntity).IsAssignableFrom(x) &&
                    x.IsDefined(typeof(EdmEntityAttribute))
                )
                .Select(entityType =>
                {
                    var entityTypeAttribute = entityType.GetCustomAttribute<EdmEntityAttribute>()!;

                    var propertyAttributes = entityType.GetProperties()
                        .Where(x => x.IsDefined(typeof(EdmPropertyAttribute)))
                        .Select(x => x.GetCustomAttribute<EdmPropertyAttribute>())
                        .ToList();

                    return new EdmEntityType
                    {
                        Name = entityTypeAttribute.Name,
                        Properties = propertyAttributes.Select(x => new EdmProperty
                        {
                            Name = x.Name,
                            Type = x.Type,
                            Nullable = x.Nullable
                        }).ToList()
                    };
                })
                .ToList();
        }

        public OSMetadata GetMetadata()
        {
            return _metadata;
        }
    }
}
