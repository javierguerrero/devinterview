using Google.Cloud.Firestore;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class QuestionFirebase
    {
        public string QuestionId { get; set; }

        [FirestoreProperty("topicId")]
        public string TopicId { get; set; }

        [FirestoreProperty("text")]
        public string Text { get; set; }
    }
}