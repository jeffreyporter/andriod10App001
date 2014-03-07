using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using PMCS_ESI_CLIENT;

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

            button.Click += delegate { 
                button.Text = string.Format("{0} xxclicks!", count++);


                ActionInterface actionPerformer = new BaseAction();
                LoginAction la = new LoginAction(actionPerformer);
                bool result = la.login(Username, Password, App.MainFrame.DefaultViewModel.clientID);


            };


        }
    }
}

