using System;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class ContactDataSource
    {
        private readonly string _connectionString;

        public ContactDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Contact FindContact(Guid id, string role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var contact = connection.Query<Contact>(@"
                                                        SELECT 
                                                            c.Id,
                                                            c.orgName as OrgName, 
                                                            c.PersonTitle, 
                                                            c.PersonName, 
                                                            c.PersonSurname,
                                                            c.IsPerson
	                                                    FROM
		                                                    dbo.ProjectAssociations as pa
	                                                    INNER JOIN
		                                                    dbo.AssociationRoles as ar
	                                                    ON
		                                                    ar.AssociationRolesId = pa.AssociationRoleId
	                                                    INNER JOIN
		                                                    uvw_ContactSummary as c
	                                                    ON
		                                                    c.Id = pa.OrgID
		                                                    OR
		                                                    c.Id = pa.MemberID
	                                                    WHERE
		                                                    pa.ProjectId = @MatterId
		                                                    AND
		                                                    ar.AssociationRoleName = @RoleName
                ", new { MatterId = id, RoleName = role } ).SingleOrDefault();
                
                return contact;
            }
        }
    }
}