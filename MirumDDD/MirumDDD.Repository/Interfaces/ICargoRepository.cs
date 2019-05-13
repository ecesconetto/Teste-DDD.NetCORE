using MirumDDD.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Repository.Interfaces
{
    public interface ICargoRepository
    {
        Task<List<CargoModel>> Get();
        Task<CargoModel> Get(int id);
        Task<int> Post(CargoModel model);
        Task<bool> Delete(CargoModel model);
        Task<bool> Update(CargoModel model);
    }
}
