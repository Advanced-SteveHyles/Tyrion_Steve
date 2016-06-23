using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class AdditionalAddressElementDataSource
    {
        public AdditionalAddressElementDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;

        public AdditionalAddressElement GetAdditionalAddressElement(Guid id, int elementTypeId)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();

                var addressElement = connection.Query<AdditionalAddressElement>(@"
                    select 
                        a.AddElementText as Value
                    from 
                        Mem_map_El m INNER JOIN AdditionalAddressElements a on m.AddElementID = a.AddElementID
                    WHERE 
                       MemberID = @MemberId and AddElTypeID = @AddElTypeID",
                    new { MemberId = id, AddElTypeID = elementTypeId });

                return addressElement.FirstOrDefault();
            }
        }
    }
}