using BusinessLogic;
using Data.Repositorys;
using Interfaces;
using Interfaces.Data.Contexts;
using PortfolioManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using WPFBase;
using WPFBase.Components;

namespace Repository
{
    public class ViewModelRepository : IIOCContainer
    {        
        public object GetInstance(Type type)
        {
            if (type == typeof(Interfaces.IStartupViewModel)) { return new StartupViewModel(this); }
            if (type == typeof(Interfaces.IMainSystemsSubTabViewModel)) { return new MainSystemsSubTabViewModel(this); }
            
            // Components
            if (type == typeof(Interfaces.ICrudViewModel)) { return new CrudViewModel(this); }
           //            -->

            return new NullObject();
        }

        public object GetInstance(string type)
        {
            switch (type)
            {
                case "IPortfolioHandler" :
                    return new PortfolioHandler(this);
                case "ITabAccountsViewModel":
                    return new TabAccountsViewModel(this); 
                case "ITabPortfolioViewModel":
                    return new TabPortfolioViewModel(this); 
                case "ISearchPortfolioViewModel":
                    return new SearchPortfolioViewModel(this); 
                case "IDataEntryPortfolioViewModel":
                    return new DataEntryPortfolioViewModel(this);
                case "IMediator":
                    return new  Mediator();
            }

            return new NullObject() ;
        }
                
        private IDataEntryPortfolioViewModel _DataEntryPortfolioViewModel; 
        private IPortfolioRepository _PortfolioRepository;
        private IPortfolioManagerContext _PortfolioManagerContext;

        public object GetSingleInstance(string type)
        {
            switch (type)
            {
                case "IPortfolioRepository":
                    if (_PortfolioRepository == null)
                    {
                        _PortfolioRepository = (IPortfolioRepository)new PortfolioRepository((IPortfolioManagerContext)this.GetSingleInstance("IPortfolioManagerContext"));
                    }
                    return _PortfolioRepository;

                case "IPortfolioManagerContext":
                    if (_PortfolioManagerContext == null)
                    {
                        _PortfolioManagerContext = new Data.PortfolioManagerContext();
                    }
                    return _PortfolioManagerContext;
                case  "IDataEntryPortfolioViewModel":
                    if (_DataEntryPortfolioViewModel == null)
                    {
                        _DataEntryPortfolioViewModel = new DataEntryPortfolioViewModel(this);
                    }
                        return _DataEntryPortfolioViewModel;

                default:
                        return new NullObject();
            }
            
            
        }


        private class NullObject :INullInterface
        {
            public NullObject ()
            {
                try
                {
                    throw new Exception("Use of null object");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }


            }
        }
    }
}
