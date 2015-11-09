using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBase.ViewModels;

namespace WPFBase.ViewModels
{
    public class SearchViewModel : ViewModel
    {
         private SearchViewModel() { }
         public SearchViewModel(IIOCContainer rep)
             : base(rep)
        {}
    }
}
