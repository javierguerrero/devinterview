using DevInterview.MobileApp.ViewModels;

namespace DevInterview.MobileApp.Views;

public partial class QuestionsPage : ContentPage
{
	public QuestionsPage()
	{
		InitializeComponent();
        BindingContext = new QuestionsViewModel(this.Navigation);
    }
}