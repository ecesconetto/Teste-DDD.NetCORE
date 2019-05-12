using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MirumDDD.Repository.Interfaces;
using MirumDDD.Repository.Repositories;
using Microsoft.AspNetCore.Http;

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
            //Base
            services.AddTransient<IBaseRepository, BaseRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
        }
    }
}