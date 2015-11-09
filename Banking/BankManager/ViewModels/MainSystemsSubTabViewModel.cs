using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBase.ViewModels;

namespace PortfolioManager
{
    public class MainSystemsSubTabViewModel : TabViewViewModel
    {
        public MainSystemsSubTabViewModel(IIOCContainer rep)
        {          
        }

        public override string GetTabName
        {
            get { return "MainSystemsSubTabViewModel"; }
        }
    }
}
