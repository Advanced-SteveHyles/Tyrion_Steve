using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WPFBase.Components;
using System.Windows.Input;

namespace TestSuite.ViewModel
{
    [TestClass]
    public class CrudViewModelTest
    {
        bool EventFired = false;

        [TestMethod]
        public void TestRelayCommand()
        {
           ICommand _doSomething;
            _doSomething = new RelayCommand (p=>DoSomeImportantMethod(), p=>CanDoSomething(), "test");

            _doSomething.Execute(null);

            Assert.IsTrue(EventFired);
            //_doSomething.
        }

        bool CanDoSomething() { return false; }
        void DoSomeImportantMethod() { EventFired = true; }

    }

}