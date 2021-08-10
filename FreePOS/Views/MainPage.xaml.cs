using CommunityToolkit.Mvvm.DependencyInjection;

using FreePOS.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FreePOS.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }

        public MainPage()
        {
            ViewModel = Ioc.Default.GetService<MainViewModel>();
            InitializeComponent();
        }
    }
}
