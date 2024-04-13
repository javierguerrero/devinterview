using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Models;
using DevInterview.MobileApp.Services;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class AnswerViewModel : ObservableObject
    {
        private readonly INavigation _navigation;

        public Question Question { get; set; }

        public AnswerViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {
                Task.Run(async () =>
                {
                   
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
