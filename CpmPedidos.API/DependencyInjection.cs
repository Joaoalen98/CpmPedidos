﻿using CpmPedidos.Interface;
using CpmPedidos.Repository.Repositories;

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
            services.AddScoped<IPedidoRepository, PedidoReposiroty>();
        }
    }
}
