﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
namespace PomoMeetApp.Classes
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string UserID { get; set; }
        [FirestoreProperty]
        public string Username { get; set; }

        [FirestoreProperty]
        public string Password { get; set; }

        [FirestoreProperty]
        public string Email { get; set; }    // thêm dòng này
    }
}
