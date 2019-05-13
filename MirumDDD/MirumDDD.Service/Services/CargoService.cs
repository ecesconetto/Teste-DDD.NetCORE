using AutoMapper;
using MirumDDD.Domain.Models;
using MirumDDD.Domain.ViewModels;
using MirumDDD.Repository.Interfaces;
using MirumDDD.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Service.Services
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

        public async Task<bool> Delete(CargoViewModel model)
        {
            //TODO: criar instancia do context e enviar para o DeleteRepository
            var entity = mapper.Map<CargoModel>(model);
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
            //TODO: criar instancia do context e enviar para o UpdateRepository
            var entity = mapper.Map<CargoModel>(model);
            return await cargoRepository.Update(entity);
        }
    }
}