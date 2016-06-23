using System;
using System.Collections.Generic;

namespace DebtsModel.DTO
{
    public class Matter
    {
        public Guid Id { get; set; }
        public string Reference { get; set; }
        public string Description { get; set; }
        public string OurReference { get; set; }
        public DateTime OpenDate { get; set; }
                
        public Debt Debt { get; set; }
        public List<Milestone> Milestones { get; set; }

        public Guid FeeEarnerId { get; set; }
        public Guid SupervisorId { get; set; }
    }
}