var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiDependencies();
builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.MapTestEndPoints();

app.Run();