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

        public string RoleId { get; set; }
        public ObservableCollection<Topic> Topics { get; set; } = new();

        public TopicsViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        public ICommand TopicTapCommand => new Command<Topic>(OnTappedTopic);

        public async void OnTappedTopic(Topic topic)
        {
            //if (topic.ToggleIcon == "down_arrow")
            //{
            //    //hide content
            //    topic.ToggleIcon = "up_arrow";
            //}
            //else
            //{
            //    //show content
            //    topic.ToggleIcon = "down_arrow";
            //}

            var qaPage = new QuestionsAnswersPage();
            qaPage.BindingContext = new QuestionsViewModel(_navigation)
            {
                TopicId = topic.Id
            };
            await _navigation.PushAsync(qaPage);
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    _topics = await _dataService.GetTopicsByRole(RoleId);

                    App.Current?.Dispatcher.Dispatch(() =>
                    {
                        Topics.Clear();
                        _topics.ForEach(topic => Topics.Add(topic));
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