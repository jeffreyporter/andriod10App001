using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PMCS_ESI_CLIENT.ESI.Client.Actions;

namespace AndroidApp10
{
    [Activity(Label = "ActivityAddItem")]
    public class ActivityAddItem : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.AddItem);

            EditText addItemCode = FindViewById<EditText>(Resource.Id.itemCode);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.buttonAddItem);


            string[] items = new string[] { "mark", "tom", "pete", "jeff" };
            ListView listview1 = FindViewById<ListView>(Resource.Id.listView1);
            ArrayAdapter<string> adapater = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, items);
            listview1.Adapter = adapater;


            button.Click += delegate
            {
               String theCode = addItemCode.Text;

               ActionInterface actionPerformer = new BaseAction();
               LookupItemAction la = new LookupItemAction(actionPerformer);
               productdetailtype result = la.lookupItem("9999", "9999", "posclient1", "70029");
               addItemCode.Text = result.productname;

               AddItemAction ai = new AddItemAction(actionPerformer);
               bool resultFromAdd = ai.addItem("9999", "9999", "posclient1", "70029", 1, 3);

                if (resultFromAdd)
                {
                    addItemCode.Text = addItemCode.Text + ":true";
                }  else
                {
                    addItemCode.Text = addItemCode.Text + ":false";
                }

           };
        }
    }
}