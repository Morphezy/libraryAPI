using Application;
using Application.Repositories;

namespace Knižnica;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
     services.AddControllers();
     services.AddHostedService<DatabaseInitializer>();
     InitializeServices(services);
    }
    
    public static void InitializeServices(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}