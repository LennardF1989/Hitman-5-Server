using HM5.Server.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HM5.Server.Mvc
{
    public class SplitNormalizedStringModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //NOTE: Split by comma or semicolon
            var value = bindingContext
                .NormalizeString()?
                .Split(
                    new []{ ',', ';' }, 
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries
                )
                .ToList();

            bindingContext.Result = ModelBindingResult.Success(value);

            return Task.CompletedTask;
        }
    }
}