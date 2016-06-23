using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class EarnerDataSource
    {

        public EarnerDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Earner FindByMemberId(Guid id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var earner = connection.Query<Earner>(@"
                        SELECT 
                        MemberId as Id ,
                        PersonSurname, 
                        PersonTitle, 
                        PersonName,
                        1 as IsPerson                        
                    FROM 
                        uvw_EarnerInfo
                    WHERE 
                       MemberId = @MemberId",
                    new { MemberId = id });

                return earner.FirstOrDefault();
            }
        }
    }
}