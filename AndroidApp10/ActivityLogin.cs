using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using PMCS_ESI_CLIENT.ESI.Client.Actions;

namespace AndroidApp10
{
    [Activity(Label = "AndroidApp10", MainLauncher = true, Icon = "@drawable/icon")]
    public class ActivityLogin : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.buttonLogin);
            EditText loginUserName = FindViewById<EditText>(Resource.Id.loginUsername);
            EditText loginPassword = FindViewById<EditText>(Resource.Id.loginPassword);

            button.Click += delegate
            {

                String username = loginUserName.Text;
                String password = loginPassword.Text;

                ActionInterface actionPerformer = new BaseAction();
                LoginAction la = new LoginAction(actionPerformer);
                bool result = la.login("9999", "9999", "posclient1");

                int ff = 0;

            };


        }
    }
}

