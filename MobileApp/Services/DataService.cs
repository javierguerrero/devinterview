using DevInterview.MobileApp.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Newtonsoft.Json;

namespace DevInterview.MobileApp.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:7215" : "https://localhost:7215";

        public DataService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            var url = $"{baseUrl}/api/subjects";
            var response = await _httpClient.GetAsync(url);


            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
            }

            throw new NotImplementedException();
        }

        public async Task<List<Question>> GetQuestionsByTopic(string topicId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Topic>> GetTopicsBySubject(string roleId)
        {
            throw new NotImplementedException();
        }
    }
}