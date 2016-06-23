using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class UserTaskDataSource
    {
        private readonly string _connectionString;

        public UserTaskDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserTask> FindUserTasks(Guid id)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = _connectionString;
                connection.Open();
                var userTasks = connection.Query<UserTask>(@"
                    SELECT 
                        Name AS Description, 
                        DueBy AS DueByDate 
                    FROM 
                        [Tasks].[UserTask]
                    WHERE 
                        entityid = @MatterId
                        AND 
                        UdModuleUId = 'A38F4CDE-8AD2-4B14-950F-775F6650F4B3'
                        AND 
                        EntityType = 'Matter' 
                        AND 
                        IsSuspended = 0", new {MatterId = id});
                return userTasks.ToList();
            }
        }
    }
}