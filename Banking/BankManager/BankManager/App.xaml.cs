using System.Windows;
using Interfaces;
using Repository;

namespace PortfolioManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        readonly IIOCContainer vrm = new ViewModelRepository();

        private void Application_Startup(object sender, StartupEventArgs e)
        {                    
            Current.MainWindow = new StartupView
            {
                DataContext = (IStartupViewModel) vrm.GetInstance(typeof(IStartupViewModel))
            };

            Current.MainWindow.Show();                          
        }
    }
}


//http://agileprogrammer.com/2009/08/17/test-driving-a-wpf-application-using-mvvm-and-tdd/
//http://martinfowler.com/articles/injection.html
//http://stackoverflow.com/questions/8693141/constructor-injection-of-a-view-model-instance-used-as-an-action-method-paramete/24166483#24166483
//http://stackoverflow.com/questions/327984/wpf-databinding-to-interface-and-not-actual-object-casting-possible
