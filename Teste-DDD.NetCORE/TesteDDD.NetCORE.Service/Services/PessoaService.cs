using AutoMapper;
using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Domain.ViewModels;
using TesteDDD.NetCORE.Repository.Interfaces;
using TesteDDD.NetCORE.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Service.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IMapper mapper;
        private readonly IPessoaRepository pessoaRepository;

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository)
        {
            this.mapper = mapper;
            this.pessoaRepository = pessoaRepository;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await pessoaRepository.GetEntity(id);
            return await pessoaRepository.Delete(entity);
        }

        public async Task<List<PessoaViewModel>> Get()
        {
            var model = await pessoaRepository.Get();
            var viewModel = mapper.Map<List<PessoaViewModel>>(model);

            return viewModel;
        }

        public async Task<PessoaViewModel> Get(int id)
        {
            var model = await pessoaRepository.Get(id);
            var viewModel = mapper.Map<PessoaViewModel>(model);

            return viewModel;
        }

        public async Task<List<PessoaViewModel>> GetPessoaByCargoId(int cargoId)
        {
            var model = await pessoaRepository.GetPessoaByCargoId(cargoId);
            var viewModel = mapper.Map<List<PessoaViewModel>>(model);

            return viewModel;
        }

        public async Task<int> Post(PessoaViewModel model)
        {
            var entity = mapper.Map<PessoaModel>(model);
            return await pessoaRepository.Post(entity);
        }

        public async Task<bool> Update(PessoaViewModel model)
        {
            var entity = await pessoaRepository.GetEntity(model.Id);
            entity.CargoId = model.CargoId;
            entity.Email = model.Email;
            entity.Nome = model.Nome;
            entity.Rg = model.RG;

            return await pessoaRepository.Update(entity);
        }
    }
}
