using DevInterview.MobileApp.Models;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
