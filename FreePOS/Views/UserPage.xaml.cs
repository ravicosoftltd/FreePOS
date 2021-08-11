using CommunityToolkit.Mvvm.DependencyInjection;
using FreePOS.ViewModels;
using Microsoft.UI.Xaml.Controls;
namespace FreePOS.Views
{

    public sealed partial class UserPage : Page
    {
        public UserViewModel ViewModel { get; }

        public UserPage()
        {
            ViewModel = Ioc.Default.GetService<UserViewModel>();
            InitializeComponent();
        }
    }
}
