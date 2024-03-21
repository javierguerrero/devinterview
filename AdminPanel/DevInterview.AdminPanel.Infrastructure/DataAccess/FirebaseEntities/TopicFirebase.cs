using Google.Cloud.Firestore;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class TopicFirebase
    {
        public string TopicId { get; set; }

        [FirestoreProperty("name")]
        public string Name { get; set; }

        [FirestoreProperty("description")]
        public string Description { get; set; }

        [FirestoreProperty("subjectId")]
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }
    }
}