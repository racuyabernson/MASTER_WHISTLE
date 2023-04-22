using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using whistle.AppDataHelper;
using whistle;
using Firebase.Auth;
using System.Threading.Tasks;
using whistle.Taskcom;
using Firebase.Firestore;
using Java.Util;

namespace whistle.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class SignUp_Activity : Activity
    {
        //global variable
        FirebaseFirestore db;
        FirebaseAuth authen;

        //Field Variables
        EditText fname, lname, email, pass;
        Button signup;
        datahelper appdata = new datahelper();
        Tasking tasklistener = new Tasking();
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.signup);

            fname = (EditText)FindViewById(Resource.Id.firstname);
            lname = (EditText)FindViewById(Resource.Id.lastname);
            email = (EditText)FindViewById(Resource.Id.emailaddress);
            pass  = (EditText)FindViewById(Resource.Id.password);
            //button
            signup = (Button)FindViewById(Resource.Id.SignUp);

            signup.Click += SIGNUP;
            //database
            db = appdata.getFireStore();
            authen = appdata.getFirebaseAuth();
        }

        private void SIGNUP(object sender, EventArgs e)
        {
            //RESTRICTIONS
            //if (string.IsNullOrWhiteSpace(email.Text) ||
            //string.IsNullOrWhiteSpace(pass.Text) ||
            //string.IsNullOrWhiteSpace(fname.Text) ||
            //string.IsNullOrWhiteSpace(pass.Text)) 
            //{
            //    Toast.MakeText(this, "Please fill in all fields.", ToastLength.Long).Show();
            //    return;
            //}

            //CREATES USER IN FIREBASE AUTHENTICATION
            authen.CreateUserWithEmailAndPassword(email.Text, pass.Text)
                .AddOnSuccessListener(this, tasklistener)
                .AddOnFailureListener(this, tasklistener);

            //INPUT DATA IN DATABASE;
            tasklistener.Success += (success, args) =>
            {
                HashMap userMap = new HashMap();

                userMap.Put("First Name", fname.Text);
                userMap.Put("Last Name", lname.Text);
                userMap.Put("Email", email.Text);
                

                DocumentReference userRef = db.Collection("USER_ACCOUNTS").Document(authen.CurrentUser.Uid);
                userRef.Set(userMap);

                Toast.MakeText(this, "Registered Successfully", ToastLength.Short).Show();


            };


            //FAILURE
            tasklistener.Failure += (failure, args) =>
            {
                Toast.MakeText(this, "Registered Failed" + args.Cause, ToastLength.Long).Show();
            };

        }
    }
}