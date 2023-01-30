using Open.Business.Services.Interfaces;
using Open.Business.Services;
using Open.Infra.Data.Repositories.Interfaces;
using Open.Infra.Data.Repositories;

namespace Open.Application.Helpers
{
    public static class DependencyInjection
    {
        public static WebApplicationBuilder Inject(this WebApplicationBuilder builder)
        {
            //Repositories
            builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
                   
            //Services
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            return builder;
        }
    }
}