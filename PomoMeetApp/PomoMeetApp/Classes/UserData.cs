using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace PomoMeetApp.Classes
{
    [FirestoreData]
    public class UserData
    {
        [FirestoreProperty]
        public string UserId { get; set; }
        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }

        [FirestoreProperty]
        public string status { get; set; }
        [FirestoreProperty]
        public string Avatar { get; set; }
        [FirestoreProperty]
        public Timestamp lastUpdated { get; set; }
    }
}
