using MirumDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Repository.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<PessoaModel>> Get();
        Task<PessoaModel> Get(int id);
        Task<int> Post(PessoaModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(PessoaModel model);
    }
}
