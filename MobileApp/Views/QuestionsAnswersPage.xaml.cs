using DevInterview.MobileApp.ViewModels;

namespace DevInterview.MobileApp.Views;

public partial class QuestionsAnswersPage : ContentPage
{
	public QuestionsAnswersPage()
	{
		InitializeComponent();
        BindingContext = new QuestionsAnswersViewModel(this.Navigation);
    }
}