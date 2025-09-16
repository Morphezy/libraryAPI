using Application;
using Application.Repositories;

namespace Knižnica;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
     services.AddControllers();
     services.AddAutoMapper(typeof(BookMapProfile).Assembly);
     services.AddHostedService<DatabaseInitializer>();
     initializeServices(services);
    }
    
    public static void initializeServices(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
    }
}