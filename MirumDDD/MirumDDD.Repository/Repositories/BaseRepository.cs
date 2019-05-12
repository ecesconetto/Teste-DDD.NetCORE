using System.Data.Common;
using System.Data.SqlClient;
using MirumDDD.CrossCutting;
using MirumDDD.Repository.Interfaces;

namespace MirumDDD.Repository.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        /// <summary>
        /// Método de abertura de conexão com o banco de dados SQL
        /// </summary>
        /// <returns></returns>
        public DbConnection OpenConnection()
        {
            var connection = new SqlConnection(ConnectionStrings.MirumDDDConnection);

            if (connection.State != System.Data.ConnectionState.Open)
                connection.Open();

            return connection;
        }
    }
}
