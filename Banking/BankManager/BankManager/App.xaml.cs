using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
        
         private void Application_Startup(object sender, StartupEventArgs e)
        {
            IIOCContainer vrm = new ViewModelRepository();

            Current.MainWindow = new StartupView();
             Current.MainWindow.DataContext = vrm.GetInstance(typeof(IStartupViewModel)); // new MainWindowViewModel();
             Current.MainWindow.Show();                          
        }
    }
}


//http://agileprogrammer.com/2009/08/17/test-driving-a-wpf-application-using-mvvm-and-tdd/
//http://martinfowler.com/articles/injection.html
//http://stackoverflow.com/questions/8693141/constructor-injection-of-a-view-model-instance-used-as-an-action-method-paramete/24166483#24166483
//http://stackoverflow.com/questions/327984/wpf-databinding-to-interface-and-not-actual-object-casting-possible
