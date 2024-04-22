using DevInterview.MobileApp.Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace DevInterview.MobileApp.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _serializerOptions;
        private string baseUrl = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:8010" : "http://localhost:8010";

        public DataService()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<List<Subject>> GetSubjects()
        {
            var subjects = new List<Subject>();
            var url = $"{baseUrl}/api/subjects";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                subjects = JsonConvert.DeserializeObject<List<Subject>>(content);
            }

            return subjects;
        }

        public async Task<List<Topic>> GetTopicsBySubject(int subjectId)
        {
            var topics = new List<Topic>();
            var url = $"{baseUrl}/api/subjects/{subjectId}/topics";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                topics = JsonConvert.DeserializeObject<List<Topic>>(content);
            }

            return topics;
        }

        public async Task<List<Question>> GetQuestionsByTopic(int topicId)
        {
            var questions = new List<Question>();
            var url = $"{baseUrl}/api/topics/{topicId}/questions";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                questions = JsonConvert.DeserializeObject<List<Question>>(content);
            }

            return questions;
        }
    }
}