using Microsoft.EntityFrameworkCore;
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
        public async Task<bool> Delete(CargoModel model)
        {
            using (var context = new MirumContext())
            {
                //TODO: resgatar o cargo pelo id antes de alterá-lo no Service
                var cargo = context.Cargo.Where(x => x.Id == model.Id).FirstOrDefault();
                var retorno = context.Cargo.Remove(cargo);
                context.SaveChanges();
                return true;
            }
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
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Where(x => x.Id == id).Select(x => new CargoModel { Id = x.Id, Nome = x.Nome, SalarioBase = x.SalarioBase }).FirstOrDefault();
                return retorno;
            }
        }

        public async Task<int> Post(CargoModel model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Add(new Cargo { Nome = model.Nome, SalarioBase = model.SalarioBase });
                context.SaveChanges();
                return retorno.Entity.Id;
            }
        }

        public async Task<bool> Update(CargoModel model)
        {
            using (var context = new MirumContext())
            {
                //TODO: resgatar o cargo pelo id antes de alterá-lo no Service
                var cargo = context.Cargo.Where(x => x.Id == model.Id).FirstOrDefault();
                var retorno = context.Cargo.Update(cargo);
                context.Entry(cargo).State = EntityState.Modified;
                context.SaveChanges();
                return retorno.Entity.Id > 0;
            }
        }
    }
}
