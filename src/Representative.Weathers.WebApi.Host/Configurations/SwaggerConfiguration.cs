using Microsoft.OpenApi.Models;
using Representative.Weathers.WebApi.Contracts;
using Representative.Weathers.WebApi.Host.Filters;
using System.Reflection;

namespace Representative.Weathers.WebApi.Host.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //Following code to avoid swagger generation error 
                //due to same method name in different versions.
                c.ResolveConflictingActions(descriptions =>
                {
                    return descriptions.First();
                });

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Weathers API",
                    Version = "1"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                var xmlContractsFile = $"{typeof(Station).Assembly.GetName().Name}.xml";
                var xmlContractsPath = Path.Combine(AppContext.BaseDirectory, xmlContractsFile);
                c.IncludeXmlComments(xmlContractsPath);

                c.OperationFilter<RemoveVersionFromParameter>();
                c.DocumentFilter<ReplaceVersionWithExactValueInPath>();
            });
        }
    }
}
