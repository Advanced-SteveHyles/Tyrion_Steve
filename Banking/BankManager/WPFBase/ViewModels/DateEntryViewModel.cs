using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFBase.ViewModels
{
    public class DateEntryViewModel : ViewModel
    {
        private DateEntryViewModel() { }
        public DateEntryViewModel(IIOCContainer rep) : base (rep)
        {}
    }
}
