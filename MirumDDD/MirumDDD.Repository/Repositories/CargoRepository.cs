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
        public async Task<bool> Delete(Cargo model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Remove(model);
                context.Entry(model).State = EntityState.Deleted;
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

        public async Task<Cargo> GetEntity(int id)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Where(x => x.Id == id).FirstOrDefault();
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

        public async Task<bool> Update(Cargo model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Cargo.Update(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return retorno.Entity.Id > 0;
            }
        }
    }
}