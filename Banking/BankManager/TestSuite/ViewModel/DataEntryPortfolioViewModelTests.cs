using Interfaces;
using PortfolioManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TestSuite.MOK;
namespace TestSuite.ViewModel
{
    public class DataEntryPortfolioViewModelTests
    {
        IDataEntryPortfolioViewModel dmv;

        void Setup()
        {
            RepositoryMOK mok = new RepositoryMOK();

            //Create a ViewModel
            IDataEntryPortfolioViewModel dmv = new DataEntryPortfolioViewModel(mok);
            
        }

      //  [Trait("ViewModels", "DataReading")]
      //  [Fact]
      //public  void CanGetPortfolioList()
      //  {
      //      Setup();
      //      Assert.NotEmpty(dmv.PortfolioList);
      //  }
    }
}
