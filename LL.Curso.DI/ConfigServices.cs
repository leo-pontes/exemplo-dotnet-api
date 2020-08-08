using LL.Curso.Data.EF;
using LL.Curso.Data.EF.Repositories;
using LL.Curso.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LL.Curso.DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            //services.AddSingleton<StoreDataContext>(); // Instancia unica
            services.AddScoped<StoreDataContext>(); // novo por requisicao  
            //services.AddTransient<StoreDataContext>(); // por chamada. sempre novo
            
            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryEF>();
        }
    }
}
