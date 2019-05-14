using MirumDDD.Domain.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MirumDDD.Service.Interfaces
{
    public interface ICargoService
    {
        Task<List<CargoViewModel>> Get();
        Task<CargoViewModel> Get(int id);
        Task<CargoViewModel> Post(CargoViewModel model);
        Task<bool> Delete(int id);
        Task<bool> Update(CargoViewModel model);
    }
}
