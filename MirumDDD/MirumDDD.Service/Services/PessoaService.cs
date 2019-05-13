using AutoMapper;
using MirumDDD.Domain.Models;
using MirumDDD.Domain.ViewModels;
using MirumDDD.Repository.Interfaces;
using MirumDDD.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Service.Services
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
            return await pessoaRepository.Delete(id);
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

        public async Task<int> Post(PessoaViewModel model)
        {
            var entity = mapper.Map<PessoaModel>(model);
            return await pessoaRepository.Post(entity);
        }

        public async Task<bool> Update(PessoaViewModel model)
        {
            var entity = mapper.Map<PessoaModel>(model);
            return await pessoaRepository.Update(entity);
        }
    }
}
