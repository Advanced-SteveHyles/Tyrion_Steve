using Interfaces;
using System.Collections.ObjectModel;
using WPFBase.ViewModels;

namespace PortfolioManager
{
    public class StartupViewModel : ViewModel, IStartupViewModel
    {
        private StartupViewModel() : base(null) { }
        public StartupViewModel(IIOCContainer rep)
            : base(rep)
        {      
            SetupTabs();
        }


#region "ViewModel Bindings"
        void refresh()
        {
            NotifyPropertyChanged("TabAccountsViewModel");
            NotifyPropertyChanged("TabDataEntryPortfolioViewModel");
        }


        private ITabAccountsViewModel _TabAccountsViewModel;
        public ITabAccountsViewModel TabAccountsViewModel
        {
            get 
            {
               return _TabAccountsViewModel;
            }
        }


     

        private ITabPortfolioViewModel _TabPortfolioViewModel;
        public ITabPortfolioViewModel TabPortfolioViewModel
        {
            get
            {
            return _TabPortfolioViewModel;
        }
    }

#endregion

        private void SetupTabs()
        {
            _TabAccountsViewModel =  (ITabAccountsViewModel)IOCC.GetInstance("ITabAccountsViewModel");
            _TabPortfolioViewModel = (ITabPortfolioViewModel)IOCC.GetInstance("ITabPortfolioViewModel");


            //tabs.Add((ViewModel)Rep.GetInstance(typeof(ITabSelectPortfolioViewModel)));
            //tabs.Add((ViewModel)Rep.GetInstance(typeof(ITabAccountsViewModel)));
            //tabs.Add((ViewModel)Rep.GetInstance(typeof(IMainSystemsSubTabViewModel)));
            
            NotifyPropertyChanged("tabs");
            NotifyPropertyChanged("refresh");
        }

        private int _SelectedIndex  ;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set { _SelectedIndex = value; NotifyPropertyChanged(); }
        }

    }
}
