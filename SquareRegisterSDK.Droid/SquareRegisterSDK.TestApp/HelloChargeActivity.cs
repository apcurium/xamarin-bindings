using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Com.Squareup.Sdk.Register;
using Android.Content;
using Android.Net;
using Android.Support.Design.Widget;
using System.Collections.Generic;
using Java.Util.Concurrent;
using Android.Text;

namespace SquareRegisterSDK.TestApp
{
    [Activity(Label = "HelloCharge", MainLauncher = true, WindowSoftInputMode = Android.Views.SoftInput.StateHidden)]
    public class HelloChargeActivity : AppCompatActivity
    {
        private const int ChargeRequestCode = 0xF00D;
        private string ClientId;
        private Uri OAuthLink;

        private EditText _transactionAmountEditText;
        private EditText _currencyCodeEditText;
        private EditText _noteEditText;
        private CheckBox _cardCheckbox;
        private CheckBox _cashCheckbox;
        private CheckBox _otherTenderCheckbox;
        private EditText _locationIdEditText;
        private EditText _autoReturnTimeoutEditText;
        private EditText _requestMetadataEditText;

        private IRegisterClient _registerClient;

        public HelloChargeActivity ()
        {
            ClientId = "YOUR_CLIENT_ID";
            OAuthLink = Uri.Parse($"https://connect.squareup.com/oauth2/authorize?client_id={ClientId}&response_type=token&scope=PAYMENTS_WRITE");
        }

        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.hello_charge_activity);

            _transactionAmountEditText = FindViewById<EditText>(Resource.Id.transaction_amount_edit_text);
            _currencyCodeEditText = FindViewById<EditText>(Resource.Id.currency_code_edit_text);
            _noteEditText = FindViewById<EditText>(Resource.Id.note_edit_text);
            _cardCheckbox = FindViewById<CheckBox>(Resource.Id.card_tender_checkbox);
            _cashCheckbox = FindViewById<CheckBox>(Resource.Id.cash_tender_checkbox);
            _otherTenderCheckbox = FindViewById<CheckBox>(Resource.Id.other_tender_checkbox);
            _locationIdEditText = FindViewById<EditText>(Resource.Id.location_id_edit_text);
            _autoReturnTimeoutEditText = FindViewById<EditText>(Resource.Id.auto_return_timeout_edit_text);
            _requestMetadataEditText = FindViewById<EditText>(Resource.Id.request_metadata_edit_text);

            FindViewById<Button>(Resource.Id.oauth_button).Click += (sender, e) => StartOAuth();
            FindViewById<FloatingActionButton>(Resource.Id.start_transaction_button).Click += (sender, e) => StartTransaction();

            _registerClient = RegisterSdk.CreateClient(this, ClientId);
        }

        private void StartOAuth ()
        {
            var browserIntent = new Intent(Intent.ActionView, OAuthLink);
            StartActivity(browserIntent);
        }

        private void StartTransaction ()
        {
            if(!_registerClient.IsRegisterInstalled)
            {
                new Android.Support.V7.App.AlertDialog.Builder(this)
                   .SetTitle(Resource.String.install_register_title)
                   .SetMessage(Resource.String.install_register_message)
                   .SetPositiveButton(Resource.String.install_register_confirm,
                       (sender, e) => _registerClient.OpenRegisterPlayStoreListing())
                   .SetNegativeButton(Android.Resource.String.Cancel, 
                       (sender, e) => { })
                   .Show ();
                return;
            }

            var amountString = _transactionAmountEditText.Text;
            var amount = string.IsNullOrWhiteSpace(amountString) ? 0 : int.Parse(amountString);
            var currencyCode = _currencyCodeEditText.Text;
            var note = _noteEditText.Text;

            var tenderTypes = new List<ChargeRequest.TenderType>();
            if(_cardCheckbox.Checked)
            {
                tenderTypes.Add(ChargeRequest.TenderType.Card);
            }
            if(_cashCheckbox.Checked)
            {
                tenderTypes.Add(ChargeRequest.TenderType.Cash);
            }
            if(_otherTenderCheckbox.Checked)
            {
                tenderTypes.Add(ChargeRequest.TenderType.Other);
            }

            var locationId = _locationIdEditText.Text;
            var timeoutString = _autoReturnTimeoutEditText.Text;
            var timeout = string.IsNullOrWhiteSpace(timeoutString) 
                ? RegisterApi.AutoReturnNoTimeout 
                : int.Parse(timeoutString);
            var requestMetadata = _requestMetadataEditText.Text;

            var chargeRequest = new ChargeRequest.Builder(amount, CurrencyCode.ValueOf(currencyCode))
                 .Note(note)
                 .EnforceBusinessLocation(locationId)
                 .AutoReturn(timeout, TimeUnit.Milliseconds)
                 .RequestMetadata(requestMetadata)
                 .RestrictTendersTo(tenderTypes)
                 .Build();

            try
            {
                var chargeIntent = _registerClient.CreateChargeIntent(chargeRequest);
                StartActivityForResult(chargeIntent, ChargeRequestCode);
            }
            catch(ActivityNotFoundException ex)
            {
                ShowSnackbar("Square Register was just uninstalled.");
            }
        }

        protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
        {
            if(requestCode == ChargeRequestCode)
            {
                if(data == null)
                {
                    // This can happen if Square Register was uninstalled or crashed while we're waiting for a result.
                    ShowSnackbar("No Result from Square Register");
                    return;
                }
                if(resultCode == Result.Ok)
                {
                    ChargeRequest.Success success = _registerClient.ParseChargeSuccess(data);
                    OnTransactionSuccess(success);
                }
                else 
                {
                    ChargeRequest.Error error = _registerClient.ParseChargeError(data);
                    OnTransactionError(error);
                }
            }
            else
            {
                base.OnActivityResult(requestCode, resultCode, data);
            }
        }

        private void OnTransactionSuccess (ChargeRequest.Success successResult)
        {
            var message = Html.FromHtml(
                "<b><font color='#00aa00'>Success</font></b><br><br>" +
                "<b>Client RealTransaction Id</b><br>" + 
                successResult.ClientTransactionId + 
                "<br><br><b>Server RealTransaction Id</b><br>" + 
                successResult.ServerTransactionId + 
                "<br><br><b>Request Metadata</b><br>" + 
                successResult.RequestMetadata).ToString();
            
            ShowResult(message);
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void OnTransactionError (ChargeRequest.Error errorResult)
        {
            var message = Html.FromHtml(
                "<b><font color='#aa0000'>Error</font></b><br><br>" + 
                "<b>Error Key</b><br>" +
                errorResult.Code + 
                "<br><br><b>Error Description</b><br>" + 
                errorResult.DebugDescription + 
                "<br><br><b>Request Metadata</b><br>" + 
                errorResult.RequestMetadata).ToString();
            
            ShowResult(message);
            System.Diagnostics.Debug.WriteLine(message);
        }

        private void ShowSnackbar (string text)
        {
            Snackbar.Make(_noteEditText, text, Snackbar.LengthLong).Show();
        }

        private void ShowResult (string message)
        {
            new Android.Support.V7.App.AlertDialog.Builder(this)
               .SetTitle(Resource.String.result_title)
               .SetMessage(message)
               .SetPositiveButton(Android.Resource.String.Ok,
                   (sender, e) => { })
               .Show();
        }
    }
}