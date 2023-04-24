using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HM5.Server.Mvc
{
    public class ModelStateFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            await next();

            if (context.ModelState.IsValid)
            {
                return;
            }

            var errors = context.ModelState
                .Where(x => x.Value.ValidationState == ModelValidationState.Invalid)
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.RawValue?.ToString() ?? "null"
                );

            throw new ModelStateException(errors);
        }
    }
}
