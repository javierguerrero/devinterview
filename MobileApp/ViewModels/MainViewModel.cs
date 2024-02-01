using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;
using System.Collections.ObjectModel;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDataService _dataService;
        private readonly INavigation _navigation;
        private List<Role> _roles;

        public MainViewModel(INavigation navigation)
        {
            _dataService = new DataService();
        }

        public ObservableCollection<Role> Roles { get; set; } = new();

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                    _roles = await _dataService.GetRoles();
                    App.Current.Dispatcher.Dispatch(() =>
                    {
                        Roles.Clear();
                        foreach (var role in _roles)
                        {
                            role.Image = "https://via.placeholder.com/200x200";
                            Roles.Add(role);
                        }
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