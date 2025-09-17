using ManagerPeople.Repository;
using ManagerPeople.Service;

namespace ManagerPeople.DependencyInjection;

public static class DependencyInjectionConfig
{
    public static void AddCustomService(this IServiceCollection services)
    {
        // Register application services
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IPersonRepository, PersonRepository>();
    }
    
    
}