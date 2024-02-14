using Google.Cloud.Firestore;
using Microsoft.Extensions.Configuration;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess
{
    public class FirebaseContext : IFirebaseContext
    {
        private readonly IConfiguration _configuration;
        private string _projectId = "devinterview-2aedb";
        private FirestoreDb _database;

        public FirebaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public FirestoreDb Database
        {
            get
            {
                if (_database is null)
                {
                    var credentialPath = _configuration["GoogleApplicationCredentials:CredentialPath"];
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath);
                    _database = FirestoreDb.Create(_projectId);
                }
                return _database;
            }
        }
    }
}