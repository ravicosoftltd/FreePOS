using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessBook
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            String innerMessage = "Error: \r\n";
            innerMessage += e.Exception.StackTrace.Substring(0,600);
            innerMessage += "\r\n";
            innerMessage += "\r\n";
            innerMessage += e.Exception.InnerException.InnerException;

            MessageBox.Show(innerMessage, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            e.Handled = true;
        }
    }
}
