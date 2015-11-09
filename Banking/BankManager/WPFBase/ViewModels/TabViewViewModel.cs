using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBase.ViewModels
{
    public abstract class TabViewViewModel : ViewModel
    {

        public TabViewViewModel() : base(null) { }
        public TabViewViewModel(IIOCContainer rep) : base(rep) { }

      public abstract string GetTabName { get; }
        
       
     public   string TabName
        { 
            get
            {
                return this.GetTabName;
            }          
        }       

    }
}
