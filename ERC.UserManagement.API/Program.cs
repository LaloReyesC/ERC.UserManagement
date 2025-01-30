var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
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
builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

var testGroup = app.MapGroup("Test").WithTags("Test");

testGroup.MapGet("Connection", () =>
{
    return Results.Ok(new
    {
        message = "Prueba de conexión exitosa."
    });
});

testGroup.MapGet("DataBase", async (ApplicationDbContext dbContext) =>
{
    int currentUsersNumber = await dbContext.UserAccounts.CountAsync();

    return Results.Ok(new
    {
        message = $"Actualmente se encuentran registrados '{currentUsersNumber}' usuarios."
    });
});

app.Run();