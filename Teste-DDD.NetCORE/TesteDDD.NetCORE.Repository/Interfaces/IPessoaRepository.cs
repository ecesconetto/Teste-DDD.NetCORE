using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Infra.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<PessoaModel>> Get();
        Task<PessoaModel> Get(int id);
        Task<Pessoa> GetEntity(int id);
        Task<int> Post(PessoaModel model);
        Task<bool> Delete(Pessoa model);
        Task<bool> Update(Pessoa model);
        Task<List<PessoaModel>> GetPessoaByCargoId(int cargoId);
    }
}
