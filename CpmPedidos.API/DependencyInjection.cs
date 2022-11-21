using CpmPedidos.Interface;
using CpmPedidos.Repository;

namespace CpmPedidos.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            RepositoryDependecies(services);
        }

        public static void RepositoryDependecies(IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}
