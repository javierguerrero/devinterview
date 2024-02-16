using Google.Cloud.Firestore;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class TopicFirebase
    {
        public string TopicId { get; set; }

        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("roleId")]
        public string RoleId { get; set; }

    }
}