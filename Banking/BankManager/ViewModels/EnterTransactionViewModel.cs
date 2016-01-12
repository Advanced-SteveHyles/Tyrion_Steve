using Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPFBase.ViewModels;

namespace PortfolioManager
{
  public  class EnterTransactionViewModel : ViewModel
    {

        ITransaction _CurrentTransaction;

        public EnterTransactionViewModel(List<ITransactionType> transactionTypes)
        {
            //_CurrentTransaction = new Data.Accounts.Transaction();
            TransactionTypes = new ObservableCollection<ITransactionType>()  ; //(transactionTypes);           
        }

        #region "properties"

        private ObservableCollection<ITransactionType> _TransactionTypes;
        public ObservableCollection<ITransactionType> TransactionTypes
        {
            get
            {

                return _TransactionTypes;
                }
            set
            {
                _TransactionTypes = value;
                NotifyPropertyChanged();
            }

    }
                
        public DateTime EstimatedDate
        {
            get
            {
                return _CurrentTransaction.EstimatedDate;
            }
            set
            {
                _CurrentTransaction.EstimatedDate = value;                
                NotifyPropertyChanged();
            }
        }

        public DateTime ReconciledDate
        {
            get
            {
                return _CurrentTransaction.ReconciledDate;
            }
            set
            {
                _CurrentTransaction.ReconciledDate = value;
                NotifyPropertyChanged();
            }
        }


        #endregion

    }
}
