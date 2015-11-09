using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Ref
{
    public  class  AccountType
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AccountTypeID { get; set; }
        
        public string TypeName { get; set; }
        public bool isDeleted {get; set;}
    }

}

