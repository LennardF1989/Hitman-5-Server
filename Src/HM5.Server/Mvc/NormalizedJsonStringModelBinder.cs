using System.Text.Json;
using HM5.Server.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HM5.Server.Mvc
{
    public class NormalizedJsonStringModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var stringValue = bindingContext.NormalizeString();

            var value = string.IsNullOrWhiteSpace(stringValue)
                ? null 
                : JsonSerializer.Deserialize(stringValue, bindingContext.ModelType);

            bindingContext.Result = ModelBindingResult.Success(value);

            return Task.CompletedTask;
        }
    }
}