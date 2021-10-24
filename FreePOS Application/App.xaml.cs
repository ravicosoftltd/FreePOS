using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FreePOS
{
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            String innerMessage = "Error";
            innerMessage += "\r\n";
            innerMessage += "Message :"+ e.Exception.Message;
            innerMessage += "\r\n";
            innerMessage += "StackTrace "+ e.Exception.StackTrace;
            innerMessage += "\r\n";
            innerMessage += "InnerException " + e.Exception.InnerException.InnerException;
            MessageBox.Show(innerMessage, "Exception", MessageBoxButton.OK, MessageBoxImage.Information);
            e.Handled = true;
        }
    }
}
