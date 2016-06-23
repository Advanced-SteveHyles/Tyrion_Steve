using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;
using DebtsModel.GraphQLDTO;

namespace DebtsModel.DataAccess
{
    public class AddressDataSource
    {

        public AddressDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public Address FindAddressByMemberId(Guid id, int addressTypeId)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var address = connection.Query<Address>(@"
                    select 
                        a.AddressId 
                    from 
                        Mem_map_Address ma 
                    inner join  [Address] a  on (ma.AddressID = a.AddressID)
                
                    WHERE 
                       MemberId = @MemberId and AddressTypeId = @AddressTypeId",
                    new { MemberId = id, AddressTypeId = addressTypeId });

                return address.FirstOrDefault();
            }
        }
    }
}