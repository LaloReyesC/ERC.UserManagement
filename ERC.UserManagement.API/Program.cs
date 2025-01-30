var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies(builder.Configuration);
builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment() || 
    app.Environment.EnvironmentName == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.UseExceptionHandler(options => { });
app.MapTestEndPoints();
app.MapAccountEndPoints();
app.MapAuthEndPoints();

app.Run();