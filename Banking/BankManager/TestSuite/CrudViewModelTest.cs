using WPFBase.Components;
using System.Windows.Input;
using Xunit;

namespace TestSuite.ViewModel
{
    public class CrudViewModelTest
    {
        bool EventFired = false;

[Fact]
        public void TestRelayCommand()
        {
           ICommand _doSomething;
            _doSomething = new RelayCommand (p=>DoSomeImportantMethod(), p=>CanDoSomething(), "test");

            _doSomething.Execute(null);

            Assert.True(EventFired);
            //_doSomething.
        }

        bool CanDoSomething() { return false; }
        void DoSomeImportantMethod() { EventFired = true; }

    }

}