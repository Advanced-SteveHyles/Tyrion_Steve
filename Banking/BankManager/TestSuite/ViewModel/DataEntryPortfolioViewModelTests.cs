using Interfaces;
using PortfolioManager;
using TestSuite.MOK;
namespace TestSuite.ViewModel
{
    public class DataEntryPortfolioViewModelTests
    {
        IDataEntryPortfolioViewModel dmv;

        void Setup()
        {
            FakeRepository mok = new FakeRepository();

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
