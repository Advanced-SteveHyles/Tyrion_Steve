using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using Xunit;

namespace WHITE
{
    public class Class1
    {
        const string executatble = "c:\\LEARNINGANDRAND\\LearningSolution1\\WhiteWinFormApp\\bin\\debug\\WhiteWinFormApp.exe";

        private static Application InvokeApplication()
        {
            Application application = Application.Launch(executatble);
            return application;
        }

        [Fact]
        void Click2ButtonsAndTestResults()
        {
            var application = InvokeApplication();

            try
            {

            var window = GetMainWindow(application);

            var button = window.Get<Button>(SearchCriteria.ByText("Start Here")) ;
            button.Click();

            var lblStatus = window.Get<Label>(SearchCriteria.ByAutomationId("lblStatus"));
            //var lblStatus = window.Get<Label>(SearchCriteria.ByText("lblStatus"));
            
            //Close the Dialog
            var dialog = window.ModalWindows().First();
            dialog.Keyboard.Enter("\n");

            Assert.Equal("Phase 1", lblStatus.Text); 

            button = window.Get<Button>(SearchCriteria.ByText("Click me next"));
            button .Click();
            
            dialog = window.ModalWindows().First();
            dialog.Keyboard.Enter("\n");

            Assert.Equal("Phase 2", lblStatus.Text); 

            }
            finally
            {

                application.Close();
            }
        }

        private static Window GetMainWindow(Application application)
        {
            Window window = application.GetWindow("frmMain");
            return window;
        }

        [Fact]
        private void NavigateToTheMDIContainer()
        {

            Application application = InvokeApplication();
            var window = GetMainWindow(application);

            var MDI =  window.Get<Button>(SearchCriteria.ByAutomationId("btnLaunchMDI"));
            MDI.Click();

            var mdiParent = application.GetWindows().Single(f => f.Title == "frmMDIParent");
            Assert.Equal("frmMDIParent", mdiParent.Title);
        }
    }
}
