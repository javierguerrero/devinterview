using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities
{
    [FirestoreData]
    public class AnswerFirebase
    {
        public string AnswerId { get; set; }

        [FirestoreProperty("questionId")]
        public string QuestionId { get; set; }


        [FirestoreProperty("text")]
        public string Text { get; set; }
    }
}
