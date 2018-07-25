using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using WpfEQDValidationApp.Startup;

namespace WpfEQDValidationApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            Bootstrapper bs = new Bootstrapper();
            bs.Run();
        }

    }
}
