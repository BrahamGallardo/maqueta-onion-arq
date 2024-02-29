using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Onion.Arq.API.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Onion Architecture API",
                    Version = "v1",
                    Description = "API of the Onion Architecture with Authentication and Authorization.",
                    Contact = new OpenApiContact
                    {
                        Name = "Abraham Gallardo",
                        Email = "braham.gc@gmail.com"
                    },
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Name = "Token",
                            Type = SecuritySchemeType.ApiKey,
                            In = ParameterLocation.Header,
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Token",
                            },
                        },
                        Array.Empty<string>()
                     }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            });

            return services;
        }
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, SwaggerConfiguration swaggerConfig)
        {
            app.UseSwagger(options => { options.RouteTemplate = swaggerConfig.RouteTemplate; });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerConfig.Endpoint, $"{swaggerConfig.Description} v{swaggerConfig.BuildVersion}");
                options.DefaultModelsExpandDepth(-1);
            });

            return app;
        }
    }
}
