using Microsoft.Extensions.DependencyInjection;

namespace Entities.DependencyResolver
{
    public static class EntitiesModule
    {
        public static void Load(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(EntitiesModule));
        }
    }
}
