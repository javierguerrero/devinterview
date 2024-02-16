using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private IFirebaseContext _firebaseContext;
        private readonly IMapper _mapper;

        public TopicRepository(IFirebaseContext firebaseContext, IMapper mapper)
        {
            _firebaseContext = firebaseContext;
            _mapper = mapper;
        }

        public async Task<List<Topic>> GetAllTopics()
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("topics");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var topicFirebaseList = new List<TopicFirebase>();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> role = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(role);
                        var topicFirebase = JsonConvert.DeserializeObject<TopicFirebase>(json);
                        topicFirebase.TopicId = documentSnapshot.Id;
                        topicFirebaseList.Add(topicFirebase);
                    }
                }
                return _mapper.Map<List<Topic>>(topicFirebaseList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Topic>> GetAllTopics(string roleId)
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("topics").WhereEqualTo("roleId", roleId);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var lstTopicFirebase = new List<TopicFirebase>();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> topic = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(topic);
                        var newTopicFirebase = JsonConvert.DeserializeObject<TopicFirebase>(json);
                        newTopicFirebase.TopicId = documentSnapshot.Id;
                        lstTopicFirebase.Add(newTopicFirebase);
                    }
                }

                return _mapper.Map<List<Topic>>(lstTopicFirebase);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> CreateTopic(Topic topic)
        {
            try
            {
                CollectionReference colRef = _firebaseContext.Database.Collection("topics");
                var topicFirebase = _mapper.Map<TopicFirebase>(topic);
                var docRef = await colRef.AddAsync(topicFirebase);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteTopic(string id)
        {
            try
            {
                DocumentReference cosplayerRef = _firebaseContext.Database.Collection("topics").Document(id);
                await cosplayerRef.DeleteAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Topic> GetTopic(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateTopic(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}