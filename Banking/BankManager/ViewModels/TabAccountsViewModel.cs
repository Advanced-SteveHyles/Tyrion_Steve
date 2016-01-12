using Interfaces;
using WPFBase.ViewModels;

namespace PortfolioManager
{
    public class TabAccountsViewModel : TabViewViewModel, ITabAccountsViewModel
    {
        public TabAccountsViewModel(IIOCContainer rep) { }
            
        public override string GetTabName
        {
            get { return "Accounts View"; }
        }
    }
}
