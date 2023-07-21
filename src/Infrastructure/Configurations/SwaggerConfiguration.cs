using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Excallibur.Infrastructure.Configurations
{
    public static class SwaggerConfiguration
    {
        private static SwaggerUIOptions SetupAction(SwaggerUIOptions options, IApiVersionDescriptionProvider provider)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
            }
            return options;
        }
        internal static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app,
            IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => SetupAction(options, provider));
            return app;
        }

    }
}
