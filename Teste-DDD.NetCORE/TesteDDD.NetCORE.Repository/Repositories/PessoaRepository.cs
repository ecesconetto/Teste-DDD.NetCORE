using Microsoft.EntityFrameworkCore;
using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Infra.Core.Models;
using TesteDDD.NetCORE.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Repository.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        public async Task<bool> Delete(Pessoa model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa.Remove(model);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }

        public async Task<List<PessoaModel>> Get()
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa
                    .Include(x => x.Cargo)
                    .Select(x => new PessoaModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        RG = x.Rg,
                        Cargo = new CargoModel()
                        {
                            Id = x.Cargo.Id,
                            Nome = x.Cargo.Nome,
                            SalarioBase = x.Cargo.SalarioBase
                        }
                    }).ToList();

                return retorno;
            }
        }

        public async Task<PessoaModel> Get(int id)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa
                    .Include(x => x.Cargo)
                    .Where(x => x.Id == id)
                    .Select(x => new PessoaModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        RG = x.Rg,
                        CargoId = x.CargoId ?? 0,
                        Cargo = new CargoModel()
                        {
                            Id = x.Cargo.Id,
                            Nome = x.Cargo.Nome,
                            SalarioBase = x.Cargo.SalarioBase
                        }
                    }).FirstOrDefault();

                return retorno;
            }
        }

        public async Task<Pessoa> GetEntity(int id)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa.Where(x => x.Id == id).FirstOrDefault();
                return retorno;
            }
        }

        public async Task<List<PessoaModel>> GetPessoaByCargoId(int cargoId)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa
                    .Include(x => x.Cargo)
                    .Where(x => x.CargoId == cargoId)
                    .Select(x => new PessoaModel
                    {
                        Id = x.Id,
                        Nome = x.Nome,
                        Email = x.Email,
                        RG = x.Rg,
                        Cargo = new CargoModel()
                        {
                            Id = x.Cargo.Id,
                            Nome = x.Cargo.Nome,
                            SalarioBase = x.Cargo.SalarioBase
                        }
                    }).ToList();

                return retorno;
            }
        }

        public async Task<int> Post(PessoaModel model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa.Add(new Pessoa { Nome = model.Nome, CargoId = model.CargoId, Rg = model.RG, Email = model.Email });
                context.SaveChanges();
                return retorno.Entity.Id;
            }
        }

        public async Task<bool> Update(Pessoa model)
        {
            using (var context = new MirumContext())
            {
                var retorno = context.Pessoa.Update(model);
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();
                return retorno.Entity.Id > 0;
            }
        }
    }
}
