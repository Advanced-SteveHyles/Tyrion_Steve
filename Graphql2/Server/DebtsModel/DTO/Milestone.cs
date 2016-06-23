using System.Collections.Generic;

namespace DebtsModel.DTO
{
    public class Milestone
    {
        public string MileStoneName { get; set; }

        public List<UserTask> UserTasks { get; set; }
    }
}