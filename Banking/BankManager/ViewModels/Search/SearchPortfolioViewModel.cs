using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFBase.Components;

namespace ViewModels
{
    public class SearchPortfolioViewModel : WPFBase.ViewModels.SearchViewModel, ISearchPortfolioViewModel
    {
    public SearchPortfolioViewModel(IIOCContainer rep) :base(rep) { }

#region "Mediator"
    public IMediator Mediator { get; set; }
#endregion


    #region "List"
    private List<IPortfolioDTO> _PortfolioList;
    public ObservableCollection<IPortfolioDTO> PortfolioList
    {
        get
        {
            if (_PortfolioList == null)
            {
                //
                var pr = (IPortfolioRepository)IOCC.GetSingleInstance("IPortfolioRepository");
                _PortfolioList = pr.GetAllPortfolios().ToList();

            }
            return new ObservableCollection<IPortfolioDTO>(_PortfolioList);
        }
    }
    #endregion

        private IPortfolioDTO _ItemSelected ;
        public IPortfolioDTO ItemSelected 
        {
            get {return _ItemSelected;}
            set
            { 
                _ItemSelected = value; 
                NotifyPropertyChanged();
                Mediator.InformChange(0, ItemSelected, this);
            }
        }

    //private RelayCommand _SelectPortfolioCommand;
    //public RelayCommand SelectPortfolioCommand 
    //{
    //    get
    //    {
    //        if (_SelectPortfolioCommand == null)
    //        {
    //            _SelectPortfolioCommand = new RelayCommand(p => SelectPortfolioCmd());
    //        }
    //        return _SelectPortfolioCommand;
    //    }
    //    set {;}
    //}

        void SelectPortfolioCmd() //(IPortfolioDTO i)
    {
        int i;
        Mediator.InformChange(0, ItemSelected, this);
    }

        
    private ICrudViewModel _CrudVM;
    public ICrudViewModel CrudVM
    {
        get
        {
            if (_CrudVM == null)
            {
                _CrudVM = (ICrudViewModel)IOCC.GetInstance(typeof(ICrudViewModel));

                _CrudVM.SetSelectCmd(p => SelectCmd(), p => CanSelectItem());
                //Wire Up Handlers                
            }
            _CrudVM.Refresh();
            return _CrudVM;
        }
    }

 public   void SelectCmd()
    { }

 public bool CanSelectItem()
    { return true; }


 public IPortfolioDTO SelectedPortfolio
 {
     get
     {
         return _ItemSelected;
     }   
 }
    }
       
}
