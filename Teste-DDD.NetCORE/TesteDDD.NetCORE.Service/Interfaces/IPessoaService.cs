using TesteDDD.NetCORE.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Service.Interfaces
{
    public interface IPessoaService
    {
        Task<List<PessoaViewModel>> Get();
        Task<PessoaViewModel> Get(int id);
        Task<int> Post(PessoaViewModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(PessoaViewModel model);
        Task<List<PessoaViewModel>> GetPessoaByCargoId(int cargoId);
    }
}
