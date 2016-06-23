using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class MilestoneDataSource
    {
        private readonly string _connectionString;

        public MilestoneDataSource(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Milestone> FindMilestones(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var milestones = connection.Query<Milestone>(@"
                    SELECT 
                        p.description as Description 
                    FROM 
                        [Processes].[Process] p 
                    INNER JOIN 
                        [Processes].[ProcessStatus] s ON p.status = s.ProcessStatusId 
                    WHERE 
                        projectid = @ProjectId 
                        AND 
                        ParentProcessId = RootProcessId
                        AND 
                        s.Name = 'InProgress'
                    ORDER BY 
                        OrderNumber
                ", new { ProjectId = id });

                return milestones.ToList();
            }
        }

        public List<Milestone> FindMilestonesWithActions(Guid id)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var milestones = connection.Query<MilestonesWithActions>(@"
                   declare @srcprocesses table (ProcessId uniqueidentifier, ParentProcessid uniqueidentifier, RootProcessId uniqueidentifier, Description ntext, Status tinyint, OrderNumber int)
                    insert into @srcprocesses select processid, parentprocessid, RootProcessId, description, status, OrderNumber from Processes.Process where projectid = @ProjectId;

                    WITH cteProcessMap(MileStoneId, MilestoneOrder, processid, ParentProcessId, RootProcessId, processlevel, MileStoneName)
                    as
                    (
	                    SELECT p0.processid as MileStoneId, p0.OrderNumber as MilestoneOrder,  p0.processid, p0.ParentProcessid, p0.RootprocessId, 1, p0.Description  as MileStoneName
	                    from @srcprocesses p0
	                    where parentprocessid = RootProcessId and Status in (2 , 3)

	                    union all

	                    SELECT cte.MileStoneId, cte.MilestoneOrder, p.processid, p.ParentProcessid, p.RootprocessId, cte.processlevel +1, cte.MileStoneName
	                    from @srcprocesses p
			                    INNER JOIN cteProcessMap cte on (p.ParentProcessId = cte.processid)		
                    )
                    select  cte1.MileStoneName, cte1.MilestoneOrder, ut.Name as TaskName, ut.Dueby  from Processes.ProcessWorkflow pwf  
                    inner join cteProcessMap cte1 on (pwf.ProcessId = cte1.processid)
                    inner join tasks.WorkflowTask wft on (wft.WorkflowInstanceId = pwf.WorkflowInstanceId)
                    inner join tasks.UserTask ut on (wft.UserTaskId = ut.UserTaskId)
                    union all
                    select  cte1.MileStoneName, cte1.MilestoneOrder, ut.Name as TaskName, ut.Dueby  from Processes.Process p
                    inner join cteProcessMap cte1 on (p.ProcessId = cte1.processid)
                    inner join tasks.TaskProcess tp on (tp.ProcessId  = p.ProcessId)
                    inner join tasks.UserTask ut on (tp.UserTaskId= ut.UserTaskId)
                    order by cte1.MilestoneOrder, ut.DueBy

                ", new { ProjectId = id });

                var findMilestonesWithActions = milestones.ToList().GroupBy(d => d.MileStoneName)
                    .Select(
                        g =>
                            new Milestone()
                            {
                                MileStoneName = g.Key,
                                UserTasks =
                                    g.Select(t => new UserTask() {DueBy = t.Dueby, TaskName = t.TaskName}).ToList()
                            }).ToList();

                return findMilestonesWithActions;
                
            }            
        }
    }
}