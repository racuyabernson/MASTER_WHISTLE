using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whistle.AppDataHelper
{
    public class datahelper
    {
        public FirebaseAuth getFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth auth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("whistle-11f12")
                    .SetApplicationId("whistle-11f12")
                    .SetApiKey("AIzaSyC72kgAktnl6l4dSbJJiikbj5vVQP-oLmk")
                    .SetStorageBucket("whistle-11f12.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                auth = FirebaseAuth.GetInstance(app);
            }
            else
            {
                auth = FirebaseAuth.GetInstance(app);  
            }
            return auth;
        }


        public FirebaseFirestore getFireStore()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseFirestore database;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("whistle-11f12")
                    .SetApplicationId("whistle-11f12")
                    .SetApiKey("AIzaSyC72kgAktnl6l4dSbJJiikbj5vVQP-oLmk")
                    .SetStorageBucket("whistle-11f12.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);
            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }

            return database;
        }
    }
}