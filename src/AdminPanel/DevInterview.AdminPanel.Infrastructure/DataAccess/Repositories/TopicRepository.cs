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
                var topicFirebaseList = new List<TopicFirebase>();
                Query query = _firebaseContext.Database.Collection("topics");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> topicRaw = documentSnapshot.ToDictionary();
                        string topicJson = JsonConvert.SerializeObject(topicRaw);
                        var topicFirebase = JsonConvert.DeserializeObject<TopicFirebase>(topicJson);
                        topicFirebase.TopicId = documentSnapshot.Id;
                        topicFirebaseList.Add(topicFirebase);
                    }
                }
                return await FillSubjectNames(_mapper.Map<List<Topic>>(topicFirebaseList));
            }
            catch
            {
                throw;
            }
        }

        private async Task<List<Topic>> FillSubjectNames(List<Topic> topics)
        {
            try
            {
                var subjectFirebaseList = new List<SubjectFirebase>();
                Query query = _firebaseContext.Database.Collection("subjects");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        var subjectRaw = documentSnapshot.ToDictionary();
                        var subjectJson = JsonConvert.SerializeObject(subjectRaw);
                        var subjectFirebase = JsonConvert.DeserializeObject<SubjectFirebase>(subjectJson);
                        subjectFirebase.SubjectId = documentSnapshot.Id;
                        subjectFirebaseList.Add(subjectFirebase);
                    }
                }

                topics.ForEach(topic => { 
                    var found = subjectFirebaseList.SingleOrDefault(r => r.SubjectId == topic.SubjectId);
                    if (found is not null)
                    {
                        topic.SubjectName = found.Name;
                    }
                });

                return topics;
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Topic>> GetTopicsBySubject(string subjectId)
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("topics").WhereEqualTo("subjectId", subjectId);
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
            try
            {
                var topicFirebase = new TopicFirebase();
                DocumentReference docRef = _firebaseContext.Database.Collection("topics").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Dictionary<string, object> role = snapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(role);
                    topicFirebase = JsonConvert.DeserializeObject<TopicFirebase>(json);
                    topicFirebase.TopicId = snapshot.Id;
                }

                return _mapper.Map<Topic>(topicFirebase);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UpdateTopic(Topic topic)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("topics").Document(topic.TopicId);
                var roleFirebase = _mapper.Map<TopicFirebase>(topic);
                await docRef.SetAsync(roleFirebase, SetOptions.Overwrite);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }
    }
}