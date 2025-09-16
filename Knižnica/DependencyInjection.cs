using Application;

namespace Knižnica;

public class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
     services.AddControllers();
     services.AddAutoMapper(typeof(BookMapProfile).Assembly);
     initializeServices(services);
    }
    
    public static void initializeServices(IServiceCollection services)
    {
        services.AddScoped<IBookRepository, IBookRepository>();
    }
}