using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Ref
{
  public  class DBGenerator
    {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
      public int VersionID { get; set; }

    }
}
