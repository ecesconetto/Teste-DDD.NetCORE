using AutoMapper;
using MirumDDD.Domain.Models;
using MirumDDD.Domain.ViewModels;

namespace MirumDDD.Domain.Automapper
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
