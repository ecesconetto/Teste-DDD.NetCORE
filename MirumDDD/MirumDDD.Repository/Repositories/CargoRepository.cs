using MirumDDD.Domain.Models;
using MirumDDD.Infra.Core.Models;
using MirumDDD.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MirumDDD.Repository.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CargoModel>> Get()
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Select(x => new CargoModel { Id = x.Id, Nome = x.Nome, SalarioBase = x.SalarioBase }).ToList();
                return retorno;
            }
        }

        public async Task<CargoModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Post(CargoModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(CargoModel model)
        {
            throw new NotImplementedException();
        }
    }
}
