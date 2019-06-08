using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using TesteDDD.NetCORE.Repository.Interfaces;
using TesteDDD.NetCORE.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using TesteDDD.NetCORE.Service.Services;
using TesteDDD.NetCORE.Service.Interfaces;

namespace TesteDDD.NetCORE.IoC
{
    public class NativeInjectorBootStrapper
    {
        /// <summary>
        /// Inversão de controle e injeção de dependência nativa do ASP.Net CORE 2.0+
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();

            services.AddTransient<ICargoService, CargoService>();
            services.AddTransient<ICargoRepository, CargoRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}
