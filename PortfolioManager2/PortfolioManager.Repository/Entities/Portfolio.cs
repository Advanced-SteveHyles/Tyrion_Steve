using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioManager.Repository.Entities
{
    [Table ("Portfolio")]
    public partial class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}