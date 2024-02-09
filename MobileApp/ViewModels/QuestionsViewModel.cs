using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class QuestionsViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        private readonly INavigation _navigation;
        private List<Question> _questions;

        public string TopicId { get; internal set; }
        public ObservableCollection<Question> Questions { get; set; } = new();

        public QuestionsViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        public ICommand TapCommand => new Command<Question>(OnTapped);

        public async void OnTapped(Question question)
        {
            //await App.Current.MainPage.DisplayAlert("Alert", question.Answer, "OK");
        }


        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    _questions = await _dataService.GetQuestionsByTopic(TopicId);

                    App.Current?.Dispatcher.Dispatch(() =>
                    {
                        Questions.Clear();
                        _questions.ForEach(topic => Questions.Add(topic));
                    });
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
