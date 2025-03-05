using Linkpreview.ViewModels;
using Microsoft.Maui.ApplicationModel;

namespace Linkpreview.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }
        private async void OnPreviewTapped(object sender, EventArgs e)
        {
            if (BindingContext is MainViewModel viewModel && !string.IsNullOrEmpty(viewModel.Url))
            {
                await Browser.OpenAsync(viewModel.Url, BrowserLaunchMode.SystemPreferred);
            }
        }
        private void OnGetPreviewClicked(object sender, EventArgs e)
        {
            UrlEntry.Unfocus();
        }
    }

}
