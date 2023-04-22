using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Nio.Channels;
using Toolbar = AndroidX.AppCompat.Widget.Toolbar;
using AlertDialog = Android.App.AlertDialog;
using Firebase.Auth;
using whistle.AppDataHelper;

namespace whistle
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            Toolbar toolbar;
            FirebaseAuth auth;
            datahelper appdata = new datahelper();
            
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            auth = appdata.getFirebaseAuth();
          
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
           MenuInflater.Inflate(Resource.Menu.feed_menu, menu);
            return true;
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;

            if (id== Resource.Id.action_logout)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Confirm!");
                builder.SetMessage("Are you sure you want to log out?");

                builder.SetPositiveButton("Yes",(sender, e) =>
                {
                    
                    Toast.MakeText(this, "Logged out Successfully!", ToastLength.Short).Show();
                }

            }
        }

    }
}