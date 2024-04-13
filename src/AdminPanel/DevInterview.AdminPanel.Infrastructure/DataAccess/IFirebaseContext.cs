using Google.Cloud.Firestore;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess
{
    public interface IFirebaseContext
    {
        FirestoreDb Database { get; }
    }
}
