using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevInterview.MobileApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.MobileApp.ViewModels
{
    public partial class QuestionsAnswersViewModel : ObservableObject
    {
        private readonly IDataService _dataService;

        private readonly INavigation _navigation;
        public string? TopicId { get; internal set; }

        public QuestionsAnswersViewModel(INavigation navigation)
        {
            _dataService = new DataService();
            _navigation = navigation;
        }

        [RelayCommand]
        private Task AppearingAsync()
        {
            try
            {

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }

            return Task.CompletedTask;
        }
    }
}
