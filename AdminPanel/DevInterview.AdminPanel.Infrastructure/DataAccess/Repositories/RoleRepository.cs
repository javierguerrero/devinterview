using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using Google.Cloud.Firestore;
using Newtonsoft.Json;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private IFirebaseContext _firebaseContext;
        private readonly IMapper _mapper;

        public RoleRepository(IFirebaseContext firebaseContext, IMapper mapper)
        {
            _firebaseContext = firebaseContext;
            _mapper = mapper;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            try
            {
                Query query = _firebaseContext.Database.Collection("roles");
                QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
                var lstRoleFirebase = new List<RoleFirebase>();

                foreach (DocumentSnapshot documentSnapshot in querySnapshot.Documents)
                {
                    if (documentSnapshot.Exists)
                    {
                        Dictionary<string, object> role = documentSnapshot.ToDictionary();
                        string json = JsonConvert.SerializeObject(role);
                        var newRoleFirebase = JsonConvert.DeserializeObject<RoleFirebase>(json);
                        newRoleFirebase.RoleId = documentSnapshot.Id;
                        lstRoleFirebase.Add(newRoleFirebase);
                    }
                }
                var sortedRoleFirebaseList = lstRoleFirebase.OrderBy(x => x.Name).ToList();

                return _mapper.Map<List<Role>>(sortedRoleFirebaseList);
            }
            catch
            {
                throw;
            }
        }

        public async Task<Role> GetRole(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateRole(Role role)
        {
            try
            {
                CollectionReference colRef = _firebaseContext.Database.Collection("roles");
                var roleFirebase = _mapper.Map<RoleFirebase>(role);
                var docRef = await colRef.AddAsync(roleFirebase);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> UpdateRole(Role role)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("roles").Document(role.RoleId);
                await docRef.SetAsync(role, SetOptions.Overwrite);
                return docRef.Id;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteRole(string id)
        {
            try
            {
                DocumentReference docRef = _firebaseContext.Database.Collection("roles").Document(id);
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