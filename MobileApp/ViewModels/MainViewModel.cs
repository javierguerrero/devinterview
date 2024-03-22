using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;
using DevInterview.MobileApp.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        private readonly INavigation _navigation;

        private List<Subject>? _roles;

        public ObservableCollection<Subject> Subjects { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;

        public MainViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        public ICommand RoleTapCommand => new Command<Subject>(OnTappedRole);

        public async void OnTappedRole(Subject subject)
        {
            var topicsPage = new TopicsPage();
            topicsPage.BindingContext = new TopicsViewModel(_navigation)
            {
                SubjectId = subject.Id
            };
            await _navigation.PushAsync(topicsPage);
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    _roles = await _dataService.GetSubjects();
                    App.Current.Dispatcher.Dispatch(() =>
                    {
                        Subjects.Clear();
                        _roles.ForEach(role => Subjects.Add(role));
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