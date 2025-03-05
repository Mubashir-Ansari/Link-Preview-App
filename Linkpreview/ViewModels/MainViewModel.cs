using System.Windows.Input;
using Linkpreview.Services;

namespace Linkpreview.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private readonly LinkPreviewService _linkPreviewService;
        private string _url = string.Empty;
        private string _title = string.Empty;
        private string _description = string.Empty;
        private string _image = string.Empty;

        public MainViewModel()
        {
            _linkPreviewService = new LinkPreviewService();
            FetchPreviewCommand = new Command(async () => await FetchPreviewAsync());
        }

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged();
            }
        }

        public ICommand FetchPreviewCommand { get; }
        private async Task FetchPreviewAsync()
        {
            if (string.IsNullOrEmpty(Url)) return;

            var preview = await _linkPreviewService.GetLinkPreviewAsync(Url);

            if (preview != null)
            {
                Title = preview.Title ?? string.Empty;
                Description = preview.Description ?? string.Empty;
                Image = preview.Image ?? string.Empty;
            }
            else
            {
                Title = string.Empty;
                Description = string.Empty;
                Image = string.Empty;
            }
        }

    }
}
