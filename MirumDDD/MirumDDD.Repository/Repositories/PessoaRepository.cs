using MirumDDD.Domain.Models;
using MirumDDD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PessoaModel>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<PessoaModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Post(PessoaModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(PessoaModel model)
        {
            throw new NotImplementedException();
        }
    }
}
