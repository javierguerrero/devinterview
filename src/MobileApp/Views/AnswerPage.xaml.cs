using DevInterview.MobileApp.ViewModels;

namespace DevInterview.MobileApp.Views;

public partial class AnswerPage : ContentPage
{
	public AnswerPage()
	{
		InitializeComponent();
        BindingContext = new AnswerViewModel(this.Navigation);
    }
}