using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private IFirebaseContext _firebaseContext;
        private readonly IMapper _mapper;

        public QuestionRepository(IFirebaseContext firebaseContext, IMapper mapper)
        {
            _firebaseContext = firebaseContext;
            _mapper = mapper;
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("questions");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var questionFirebaseList = new List<QuestionFirebase>();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> question = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(question);
                        var questionFirebase = JsonConvert.DeserializeObject<QuestionFirebase>(json);
                        questionFirebase.Id = documentSnapshot.Id;
                        questionFirebaseList.Add(questionFirebase);
                    }
                }
                return _mapper.Map<List<Question>>(questionFirebaseList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Question>> GetQuestionsByTopic(string topicId)
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("questions").WhereEqualTo("topicId", topicId);
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var lstQuestionFirebase = new List<QuestionFirebase>();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> question = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(question);
                        QuestionFirebase questionFirebase = JsonConvert.DeserializeObject<QuestionFirebase>(json);
                        questionFirebase.Id = documentSnapshot.Id;
                        lstQuestionFirebase.Add(questionFirebase);
                    }
                }

                return _mapper.Map<List<Question>>(lstQuestionFirebase);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Question> GetQuestion(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateQuestion(Question question)
        {
            try
            {
                CollectionReference colRef = _firebaseContext.Database.Collection("questions");
                var questionFirebase = _mapper.Map<QuestionFirebase>(question);
                var docRef = await colRef.AddAsync(questionFirebase);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UpdateQuestion(Question question)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("questions").Document(question.Id);
                var questionFirebase = _mapper.Map<QuestionFirebase>(question);
                await docRef.SetAsync(questionFirebase, SetOptions.Overwrite);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteQuestion(string id)
        {
            try
            {
                DocumentReference questionRef = _firebaseContext.Database.Collection("questions").Document(id);
                await questionRef.DeleteAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}