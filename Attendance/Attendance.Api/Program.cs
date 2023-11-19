using Attendance.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureSwagger();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = "swagger";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "attendance-api");
    });
}

app.UsePathBase("/api");
app.Use((context, next) =>
{
    context.Request.PathBase = "/api";
    return next();
});

app.UseForwardedHeaders();

app.UseAuthorization();
app.MapControllers();
app.Run();
