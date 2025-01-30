namespace ERC.UserManagement.API;

public static class LayerDependencies
{
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.UseInlineDefinitionsForEnums();

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Ingresa el token de autenticación",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            string[] xmlsPaths = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");

            foreach (var xmlPath in xmlsPaths)
            {
                options.IncludeXmlComments(xmlPath);
            }
        });
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.AddExceptionHandler<CustomExceptionHandler>();

        return services;
    }
}