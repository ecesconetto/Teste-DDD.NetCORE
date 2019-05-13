using AutoMapper;
using MirumDDD.Domain.Models;
using MirumDDD.Domain.ViewModels;

namespace MirumDDD.Domain.Automapper
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