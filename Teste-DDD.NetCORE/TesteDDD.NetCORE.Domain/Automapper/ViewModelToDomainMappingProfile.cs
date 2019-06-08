using AutoMapper;
using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Domain.ViewModels;

namespace TesteDDD.NetCORE.Domain.Automapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaViewModel, PessoaModel>();
            CreateMap<CargoViewModel, CargoModel>();
        }
    }
}
