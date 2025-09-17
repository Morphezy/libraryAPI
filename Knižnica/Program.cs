using Knižnica;
using Knižnica.Middlewares;

var builder = WebApplication.CreateBuilder(args);


DependencyInjection.ConfigureServices(builder.Services);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();
app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/OpenAPI/v1.json", "OpenAPI v1");
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

