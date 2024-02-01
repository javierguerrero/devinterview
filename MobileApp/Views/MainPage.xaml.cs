using DevInterview.MobileApp.ViewModels;

namespace DevInterview.MobileApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel(this.Navigation);
        }
    }
}