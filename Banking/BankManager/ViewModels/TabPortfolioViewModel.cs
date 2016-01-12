using Interfaces;

namespace PortfolioManager
{
    public class TabPortfolioViewModel : WPFBase.ViewModels.TabViewViewModel, ITabPortfolioViewModel
    {
        private IMediator _Mediator;

        public TabPortfolioViewModel(IIOCContainer rep)
            : base(rep)
        {
            _DataEntryPortfolioVM = (IDataEntryPortfolioViewModel)IOCC.GetInstance("IDataEntryPortfolioViewModel");
            _SearchPortfolioVM = (ISearchPortfolioViewModel)IOCC.GetInstance("ISearchPortfolioViewModel");

            _Mediator = (IMediator) IOCC.GetInstance("IMediator");
            _SearchPortfolioVM.Mediator = _Mediator;
            _Mediator.RegisterInterest(0, p => _DataEntryPortfolioVM.PortfolioSelected(_SearchPortfolioVM.SelectedPortfolio), _DataEntryPortfolioVM);
        }


        public override string GetTabName
        {
            get { return "Portfolio"; }
        }


        private IDataEntryPortfolioViewModel _DataEntryPortfolioVM;
        public IDataEntryPortfolioViewModel DataEntryPortfolioVM
        {
            get
            {
                return _DataEntryPortfolioVM;
            }
        }


        private ISearchPortfolioViewModel _SearchPortfolioVM;
        public ISearchPortfolioViewModel SearchPortfolioVM
        {
            get
            {
                return _SearchPortfolioVM;
            }
        }
           
    }
}
