using CRUD_Produto.ADO_NET.UnidadeTerra.AppDbContext;
using CRUD_Produto.ADO_NET.UnidadeTerra.Repositories;
using CRUD_Produto.ADO_NET.UnidadeTerra.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CRUD_Produto.ADO_NET.UnidadeTerra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection  = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();
            app!.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSingleton<App>()
                .AddScoped<AppDBContext>()
                .AddTransient<IProductRepository, ProductRepository>();
                
        }
    }
}
