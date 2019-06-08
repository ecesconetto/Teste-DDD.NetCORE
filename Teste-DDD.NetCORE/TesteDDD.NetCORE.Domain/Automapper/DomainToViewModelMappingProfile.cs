using AutoMapper;
using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Domain.ViewModels;

namespace TesteDDD.NetCORE.Domain.Automapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<PessoaModel, PessoaViewModel>();
            CreateMap<CargoModel, CargoViewModel>();
        }
    }
}
