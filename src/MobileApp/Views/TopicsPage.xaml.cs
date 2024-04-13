using DevInterview.MobileApp.ViewModels;

namespace DevInterview.MobileApp.Views;

public partial class TopicsPage : ContentPage
{
	public TopicsPage()
	{
		InitializeComponent();
        BindingContext = new TopicsViewModel(this.Navigation);
    }
}