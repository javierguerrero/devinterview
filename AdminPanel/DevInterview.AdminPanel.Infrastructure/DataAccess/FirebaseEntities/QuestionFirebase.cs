using Google.Cloud.Firestore;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class QuestionFirebase
    {
        public string Id { get; set; }

        [FirestoreProperty("questionText")]
        public string QuestionText { get; set; }

        [FirestoreProperty("answerText")]
        public string AnswerText { get; set; }

        [FirestoreProperty("topicId")]
        public string TopicId { get; set; }
    }
}