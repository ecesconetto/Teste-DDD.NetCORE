using System.Data.Common;

namespace MirumDDD.Repository.Interfaces
{
    public interface IBaseRepository
    {
        DbConnection OpenConnection();
    }
}
