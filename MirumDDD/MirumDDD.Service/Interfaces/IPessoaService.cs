using MirumDDD.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<List<PessoaViewModel>> Get();
        Task<PessoaViewModel> Get(int id);
        Task<int> Post(PessoaViewModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(PessoaViewModel model);
    }
}
