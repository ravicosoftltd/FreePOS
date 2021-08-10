using CommunityToolkit.Mvvm.DependencyInjection;

using FreePOS.ViewModels;

using Microsoft.UI.Xaml.Controls;

namespace FreePOS.Views
{
    public sealed partial class ContentGridPage : Page
    {
        public ContentGridViewModel ViewModel { get; }

        public ContentGridPage()
        {
            ViewModel = Ioc.Default.GetService<ContentGridViewModel>();
            InitializeComponent();
        }
    }
}
