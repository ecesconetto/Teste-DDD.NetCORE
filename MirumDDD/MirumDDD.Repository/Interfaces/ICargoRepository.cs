using MirumDDD.Domain.Models;
using MirumDDD.Infra.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Repository.Interfaces
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
