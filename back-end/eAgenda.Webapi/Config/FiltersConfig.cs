using eAgenda.Webapi.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace eAgenda.Webapi.Config
{
    public static class FiltersConfig
    {
        public static void ConfigurarFiltros(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                config.Filters.Add(new ValidarViewModelActionFilter());
            });
        }
    }
}
