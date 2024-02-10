using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class AnswerViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        private readonly INavigation _navigation;

        [ObservableProperty]
        private Answer _answer;

        public string QuestionId { get; set; }

        public AnswerViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    Answer = await _dataService.GetAnswer(QuestionId);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return Task.CompletedTask;
        }
    }
}
