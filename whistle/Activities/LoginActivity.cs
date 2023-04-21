using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using whistle.Taskcom;
using whistle.AppDataHelper;

namespace whistle.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class LoginActivity : Activity
    {
        EditText email, pass;
        Button Signin, SignUp;
        Tasking tasklistener = new Tasking();
        datahelper appdata = new datahelper();

        //global variable
        FirebaseFirestore db;
        FirebaseAuth authen;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.login);

            // Create your application here
            email = (EditText)FindViewById(Resource.Id.Email);
            pass = (EditText)FindViewById(Resource.Id.password);
            Signin = (Button)FindViewById(Resource.Id.signin);
            
            SignUp = (Button)FindViewById(Resource.Id.signup);
            SignUp.Click += delegate
            {
                Intent intent = new Intent(this, typeof(SignUp_Activity));
                StartActivity(intent);
            };

            Signin.Click += SIGN_IN;
            db = appdata.getFireStore();
            authen = appdata.getFirebaseAuth();


        }

        private void SIGN_IN(object sender, EventArgs e)
        {
            authen.SignInWithEmailAndPassword(email.Text, pass.Text)
                .AddOnSuccessListener(tasklistener)
                .AddOnFailureListener(tasklistener);


            //Registration success callback - LOGIN
            tasklistener.Success += (success, args) =>
            {
                StartActivity(typeof(MainActivity));
                Toast.MakeText(this, "GREAT ANOTHER USER HAYSSS~", ToastLength.Short).Show();
            };

            tasklistener.Failure += (success, args) =>
            {
                Toast.MakeText(this, "U FAILED U TWAT" + args.Cause, ToastLength.Short).Show();
            };
        }
    }
}