using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;
using DevInterview.MobileApp.Views;
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

        [ObservableProperty]
        private bool _isBusy = true;

        public QuestionsViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        public ICommand TapCommand => new Command<Question>(OnTapped);

        public async void OnTapped(Question question)
        {
            var answerPage = new AnswerPage();
            answerPage.BindingContext = new AnswerViewModel(_navigation)
            {
                Question = question
            };
            await _navigation.PushAsync(answerPage);
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
                        IsBusy = false;
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