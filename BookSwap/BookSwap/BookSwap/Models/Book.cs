using MvvmHelpers;

namespace BookSwap.Models
{
    public class Book : ObservableObject
    {
        private string _title;
        private string _author;
        private string _converImage;
        private string _accentColor;

        public string Title
        {
            get => _title;
            set =>  SetProperty<string>(ref _title, value);
        }

        public string Author
        {
            get => _author;
            set => SetProperty<string>(ref _author, value);
        }

        public string CoverImage
        {
            get => _converImage;
            set => SetProperty<string>(ref _converImage, value);
        }

        public string AccentColor
        {
            get => _accentColor;
            set => SetProperty<string>(ref _accentColor, value);
        }

    }
}
