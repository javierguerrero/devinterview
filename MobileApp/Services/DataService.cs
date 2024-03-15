using DevInterview.MobileApp.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Newtonsoft.Json;

namespace DevInterview.MobileApp.Services
{
    public class DataService : IDataService
    {
        private FirestoreDb _firestoreDb;

        private async Task<FirestoreDb> InitFirestore()
        {
            try
            {
                var stream = await FileSystem.OpenAppPackageFileAsync(DevInterview.MobileApp.Constants.FirestoreKeyFilename);
                var reader = new StreamReader(stream);
                var contents = reader.ReadToEnd();

                FirestoreClientBuilder fbc = new FirestoreClientBuilder { JsonCredentials = contents };
                return FirestoreDb.Create(DevInterview.MobileApp.Constants.FirestoreProjectID, fbc.Build());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Role>> GetRoles()
        {
            _firestoreDb = await InitFirestore();

            try
            {
                Query query = _firestoreDb.Collection("roles");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var roleList = new List<Role>();

                foreach (DocumentSnapshot ds in querySnapshot.Documents)
                {
                    if (ds.Exists)
                    {
                        Dictionary<string, object> role = ds.ToDictionary();
                        string roleJson = JsonConvert.SerializeObject(role);
                        var newRole = JsonConvert.DeserializeObject<Role>(roleJson);
                        newRole.Id = ds.Id;
                        roleList.Add(newRole);
                    }
                }
                var sortedRoleList = roleList.OrderBy(x => x.Name).ToList();

                return sortedRoleList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Topic>> GetTopicsByRole(string roleId)
        {
            _firestoreDb = await InitFirestore();
            try
            {
                Query query = _firestoreDb.Collection("topics");
                QuerySnapshot qs = await query
                        .WhereEqualTo("roleId", roleId)
                        .OrderBy("name")
                        .GetSnapshotAsync();

                var topicList = new List<Topic>();

                foreach (DocumentSnapshot ds in qs.Documents)
                {
                    if (ds.Exists)
                    {
                        Dictionary<string, object> raw = ds.ToDictionary();
                        string topicJson = JsonConvert.SerializeObject(raw);
                        var newTopic = JsonConvert.DeserializeObject<Topic>(topicJson);
                        newTopic.Id = ds.Id;
                        topicList.Add(newTopic);
                    }
                }

                topicList = topicList.Select((item, index) =>
                {
                    item.Number = index + 1;
                    return item;
                }).ToList();

                return topicList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Question>> GetQuestionsByTopic(string topicId)
        {
            _firestoreDb = await InitFirestore();
            try
            {
                Query query = _firestoreDb.Collection("questions");
                QuerySnapshot qs = await query
                        .WhereEqualTo("topicId", topicId)
                        .GetSnapshotAsync();

                var questionList = new List<Question>();

                foreach (DocumentSnapshot ds in qs.Documents)
                {
                    if (ds.Exists)
                    {
                        Dictionary<string, object> raw = ds.ToDictionary();
                        string questionJson = JsonConvert.SerializeObject(raw);
                        var newQuestion = JsonConvert.DeserializeObject<Question>(questionJson);
                        newQuestion.Id = ds.Id;
                        questionList.Add(newQuestion);
                    }
                }

                questionList = questionList.Select((item, index) =>
                {
                    item.Number = index + 1;
                    return item;
                }).ToList();

                return questionList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}