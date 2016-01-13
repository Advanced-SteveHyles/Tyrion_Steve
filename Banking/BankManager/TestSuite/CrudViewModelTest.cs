using System.Data.Entity.Core.Common.CommandTrees;
using WPFBase.Components;
using System.Windows.Input;
using Xunit;

namespace TestSuite.ViewModel
{
    public class CrudViewModelTest
    {
        bool EventFired = false;

        [Fact(Skip = "Not sure whether this is valid or not")]
        public void TestRelayCommandFiresWhenAllowed()
        {
            ICommand doSomething = new RelayCommand(p => DoSomeImportantMethod(), p => CanDoSomething, "test");
            
            doSomething.Execute(null);

            Assert.True(EventFired);
        }

        [Fact (Skip = "Not sure whether this is valid or not")]
        public void TestRelayCommandDoesNotFireWhenNotAllowed()
        {
            ICommand doSomething = new RelayCommand(p => DoSomeImportantMethod(), p => CannotDoSomething, "test");

            doSomething.Execute(null);

            Assert.False(EventFired);
        }


        private bool CanDoSomething => true;
        private bool CannotDoSomething => false;
        
        void DoSomeImportantMethod() { EventFired = true; }

    }

}