using TesteDDD.NetCORE.Domain.Models;
using TesteDDD.NetCORE.Infra.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TesteDDD.NetCORE.Repository.Interfaces
{
    public interface ICargoRepository
    {
        Task<List<CargoModel>> Get();
        Task<CargoModel> Get(int id);
        Task<Cargo> GetEntity(int id);
        Task<int> Post(CargoModel model);
        Task<bool> Delete(Cargo model);
        Task<bool> Update(Cargo model);
    }
}
