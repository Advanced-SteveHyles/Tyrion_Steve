using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class UserDataSource
    {
        private readonly string _connectionString;

        public UserDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public User FindByUserName(string userName)
        //{
        //    using (var connection = new SqlConnection())
        //    {
        //        connection.ConnectionString = _connectionString;
        //        connection.Open();

        //        var users =
        //            connection.Query<User>(@"
        //            SELECT 
        //                name as UserName, 
        //                '' as PersonTitle, 
        //                PersonName, 
        //                PersonSurname, 
        //                1 as IsPerson
        //            FROM 
        //                uvw_UsersAll 
        //            WHERE 
        //                name = @UserName",
        //                new {UserName = userName});

        //        return users.FirstOrDefault();
        //    }
        //}
    }
}