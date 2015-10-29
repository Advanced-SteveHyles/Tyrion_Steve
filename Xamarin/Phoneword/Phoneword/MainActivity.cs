using System;
using RestSharp;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Phoneword
{
	[Activity (Label = "Phone Word", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our UI controls from the loaded layout:
			EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
			EditText NumberText  = FindViewById<EditText>(Resource.Id.NumberText);
			EditText RestResponse = FindViewById<EditText>(Resource.Id.RestResponseText);

			Button translateButton = FindViewById<Button>(Resource.Id.TranslateButton);
			Button TranslateToVanityButton = FindViewById<Button>(Resource.Id.TranslateToVanityButton);
			Button restButton = FindViewById<Button>(Resource.Id.RestButton);

			Button callButton = FindViewById<Button>(Resource.Id.CallButton);

			// Disable the "Call" button
			callButton.Enabled = false;

			// Add code to translate number
			string translatedNumber = string.Empty;

			translateButton.Click += (object sender, EventArgs e) =>
			{
				// Translate user's alphanumeric phone number to numeric
				translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
				if (String.IsNullOrWhiteSpace(translatedNumber))
				{
					callButton.Text = "Call";
					callButton.Enabled = false;
				}
				else
				{
					callButton.Text = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};

			TranslateToVanityButton.Click += (object sender, EventArgs e) => {
				translatedNumber = Core.PhonewordTranslator.ToVanity (NumberText.Text);

				if (String.IsNullOrWhiteSpace (translatedNumber)) {
					callButton.Text = "Call";
					callButton.Enabled = false;
				} else {
					callButton.Text = "Call " + translatedNumber;
					callButton.Enabled = true;
				}
			};


			callButton.Click += (object sender, EventArgs e) =>
			{
				// On "Call" button click, try to dial phone number.
				var callDialog = new AlertDialog.Builder(this);
				callDialog.SetMessage("Call " + translatedNumber + "?");
				callDialog.SetNeutralButton("Call", delegate {
					// Create intent to dial phone
					var callIntent = new Intent(Intent.ActionCall);
					callIntent.SetData(Android.Net.Uri.Parse("tel:" + translatedNumber));
					StartActivity(callIntent);
				});
				callDialog.SetNegativeButton("Cancel", delegate { });

				// Show the alert dialog to the user and wait for response.
				callDialog.Show();
			};

			restButton.Click += (object sender, EventArgs e) => 
			{
				var api = new RestCall();

				RestResponse.Text = api.GetBossier();
			};

		}

		public class RestCall
		{
			public string GetBossier()
			{
				var client = new RestClient("http://doasyouretold.apphb.com/");
				var request = new RestRequest("", Method.GET)
				{
					RequestFormat = DataFormat.Json
				};

				var response = client.Execute(request);
				return response.Content;
			}
		}
	}
}


