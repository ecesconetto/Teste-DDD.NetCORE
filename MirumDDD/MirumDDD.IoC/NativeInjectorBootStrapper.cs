using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MirumDDD.Repository.Interfaces;
using MirumDDD.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using MirumDDD.Service.Services;
using MirumDDD.Service.Interfaces;

namespace MirumDDD.IoC
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