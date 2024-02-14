using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class RoleFirebase
    {
        public string RoleId { get; set; }

        [FirestoreProperty("name")]
        public string Name { get; set; }
    }
}
