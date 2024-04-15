using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private IFirebaseContext _firebaseContext;
        private readonly IMapper _mapper;

        public SubjectRepository(IFirebaseContext firebaseContext, IMapper mapper)
        {
            _firebaseContext = firebaseContext;
            _mapper = mapper;
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            try
            {
                var lstRoleFirebase = new List<SubjectFirebase>();
                Query query = _firebaseContext.Database.Collection("subjects");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        var roleRaw = documentSnapshot.ToDictionary();
                        var roleJson = JsonConvert.SerializeObject(roleRaw);
                        var roleFirebase = JsonConvert.DeserializeObject<SubjectFirebase>(roleJson);
                        roleFirebase.SubjectId = documentSnapshot.Id;
                        lstRoleFirebase.Add(roleFirebase);
                    }
                }
                var sortedRoleFirebaseList = lstRoleFirebase.OrderBy(x => x.Name).ToList();

                return _mapper.Map<List<Subject>>(sortedRoleFirebaseList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Subject> GetSubject(string id)
        {
            try
            {
                var roleFirebase = new SubjectFirebase();
                DocumentReference docRef = _firebaseContext.Database.Collection("subjects").Document(id);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();
                if (snapshot.Exists)
                {
                    Dictionary<string, object> role = snapshot.ToDictionary();
                    string json = JsonConvert.SerializeObject(role);
                    roleFirebase = JsonConvert.DeserializeObject<SubjectFirebase>(json);
                    roleFirebase.SubjectId = snapshot.Id;
                }

                return _mapper.Map<Subject>(roleFirebase);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> CreateSubject(Subject role)
        {
            try
            {
                CollectionReference colRef = _firebaseContext.Database.Collection("subjects");
                var roleFirebase = _mapper.Map<SubjectFirebase>(role);
                var docRef = await colRef.AddAsync(roleFirebase);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UpdateSubject(Subject role)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("subjects").Document(role.SubjectId.ToString());
                var roleFirebase = _mapper.Map<SubjectFirebase>(role);
                await docRef.SetAsync(roleFirebase, SetOptions.Overwrite);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteSubject(string id)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("subjects").Document(id);
                await docRef.DeleteAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}