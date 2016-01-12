using Interfaces;
using System;
using WPFBase.ViewModels;
//using System.ComponentModel;

namespace PortfolioManager
{
    public class DataEntryPortfolioViewModel : DateEntryViewModel, IDataEntryPortfolioViewModel
    {

        private IPortfolioHandler phand;

        private DataEntryPortfolioViewModel() : base(null) { }
        public DataEntryPortfolioViewModel(IIOCContainer iocc) : base(iocc) 
        {
            phand = (IPortfolioHandler)IOCC.GetInstance("IPortfolioHandler");
        }

        #region "Fields"
            string _PortfolioName;
        #endregion

        public string PortfolioName
        {
            get
            {
                return _PortfolioName;
            }
            set
            {
                _PortfolioName = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("CrudVM");        
            }
        }

        private ICrudViewModel _CrudVM;
        public ICrudViewModel CrudVM
       {
           get
           {
               if (_CrudVM == null)
               {
                   _CrudVM = (ICrudViewModel)IOCC.GetInstance(typeof(ICrudViewModel));

                   _CrudVM.SetNewCmd(p => NewCMD(), p => CanNewCMD());
                   _CrudVM.SetSaveCmd(p => SaveCMD(), p => CanSaveCMD(p));
                   //Wire Up Handlers
                   //_CrudVM
               }
               _CrudVM.Refresh();
               return _CrudVM;                
            }
        }

        #region "Commands"
            void NewCMD()
            {
            }

        void SaveCMD()               
            {
                //Get this to the database 
                phand.SavePortfolio(PortfolioName);
                Reset();
                NotifyPropertyChanged("PortfolioList");
            }


        Boolean CanNewCMD()
        {
            return true;
        }

       public     Boolean CanSaveCMD(object p)
        {
            return !string.IsNullOrEmpty(_PortfolioName);            
        }

        
        #endregion

       #region "misc"
           private void Reset()
           {
          //     _PortfolioList = null;
               _PortfolioName = string.Empty;

               NotifyPropertyChanged("PortfolioName");
            //   NotifyPropertyChanged("PortfolioList");
           }
       #endregion


           public void PortfolioSelected(IPortfolioDTO selectedPortffolio)
           {
             //  throw new NotImplementedException();
               PortfolioName = selectedPortffolio.PortfolioName;
           }
    }
}
