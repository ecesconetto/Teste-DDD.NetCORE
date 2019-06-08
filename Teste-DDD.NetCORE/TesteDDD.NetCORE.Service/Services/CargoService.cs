using AutoMapper;
using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Domain.ViewModels;
using TesteDDD.NetCORE.Repository.Interfaces;
using TesteDDD.NetCORE.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Service.Services
{
    public class CargoService : ICargoService
    {
        private readonly IMapper mapper;
        private readonly ICargoRepository cargoRepository;

        public CargoService(IMapper mapper, ICargoRepository cargoRepository)
        {
            this.mapper = mapper;
            this.cargoRepository = cargoRepository;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await cargoRepository.GetEntity(id);
            return await cargoRepository.Delete(entity);
        }

        public async Task<List<CargoViewModel>> Get()
        {
            var model = await cargoRepository.Get();
            var viewModel = mapper.Map<List<CargoViewModel>>(model);

            return viewModel;
        }

        public async Task<CargoViewModel> Get(int id)
        {
            var model = await cargoRepository.Get(id);
            var viewModel = mapper.Map<CargoViewModel>(model);

            return viewModel;
        }

        public async Task<CargoViewModel> Post(CargoViewModel model)
        {
            var entity = mapper.Map<CargoModel>(model);
            model.Id = await cargoRepository.Post(entity);

            return model;
        }

        public async Task<bool> Update(CargoViewModel model)
        {
            var entity = await cargoRepository.GetEntity(model.Id);
            entity.Nome = model.Nome;
            entity.SalarioBase = model.SalarioBase;

            return await cargoRepository.Update(entity);
        }
    }
}
