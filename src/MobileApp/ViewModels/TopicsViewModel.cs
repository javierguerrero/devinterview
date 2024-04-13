using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;
using DevInterview.MobileApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class TopicsViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        private readonly INavigation _navigation;
        private List<Topic> _topics;

        public int SubjectId { get; set; }
        public ObservableCollection<Topic> Topics { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;

        public TopicsViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        public ICommand TapCommand => new Command<Topic>(OnTapped);

        public async void OnTapped(Topic topic)
        {
            var questionsPage = new QuestionsPage();
            questionsPage.BindingContext = new QuestionsViewModel(_navigation)
            {
                TopicId = topic.Id
            };
            await _navigation.PushAsync(questionsPage);
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    _topics = await _dataService.GetTopicsBySubject(SubjectId);

                    App.Current?.Dispatcher.Dispatch(() =>
                    {
                        Topics.Clear();
                        _topics.ForEach(topic => Topics.Add(topic));
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