using Foundation;
using SquareRegisterSDK.iOS;
using UIKit;

namespace SquareRegisterSDK.TestApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
        {
            this.Window = new UIWindow(UIScreen.MainScreen.Bounds);
            this.Window.RootViewController = new UIViewController();
            this.Window.BackgroundColor = UIColor.White;

            this.Window.MakeKeyAndVisible();

            // Always set the client ID before creating your first API request.
            SCCAPIRequest.SetClientID("YOUR_CLIENT_ID");

            // Replace with your app's callback URL.
            var callbackURL = new NSUrl("register-sdk-testapp://myCallback");

            // Specify the amount of money to charge.
            NSError error;
            var amount = SCCMoney.MoneyWithAmountCents(100, "USD", out error);

            // Specify which forms of tender the merchant can accept
            var supportedTenderTypes = SCCAPIRequestTenderTypes.Card;

            // Specify whether default fees in Square Register are cleared from this transaction
            // (Default is NO, they are not cleared)
            var clearsDefaultFees = true;

            // Replace with the current merchant's ID.
            string merchantID = null;

            // Replace with any string you want returned from Square Register.
            var userInfoString = "Useful information";

            // Replace with notes to associate with the transaction.
            var notes = "Notes";

            // Initialize the request.
            var request = SCCAPIRequest.RequestWithCallbackURL(callbackURL,
                                                               amount,
                                                               userInfoString,
                                                               merchantID,
                                                               notes,
                                                               supportedTenderTypes,
                                                               clearsDefaultFees,
                                                               false,
                                                               out error);

            // Perform the request. (Strangely, it seems to return false even when error is null and that the Register app gets started...)
            var success = SCCAPIConnection.PerformRequest(request, out error);
            if(!success && error != null)
            {
                var alertView = new UIAlertView("Register app installed?",
                                                "Make sure the register app is installed in the simulator. Log in as the merchant with token 7074ME2C077ZB.",
                                                null, "Dismiss");
                alertView.Show();
            }

            return true;
        }

        public override bool OpenUrl (UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        {
            // Make sure the URL comes from Square Register, fail if it doesn't.
            if(!sourceApplication.StartsWith("com.squareup.square"))
            {
                return false;
            }

            // The response data is encoded in the URL and can be decoded as an SCCAPIResponse.
            NSError decodeError;
            var response = SCCAPIResponse.ResponseWithResponseURL(url, out decodeError);

            string message;
            string title;

            // Process the response as desired.
            if(response.SuccessResponse)
            {
                title = "Success!";
                message = string.Format("Payment creation succeeded with payment ids {0} {1}, transaction ID {2}", response.PaymentID, response.OfflinePaymentID, response.TransactionID);
            }
            else
            {
                title = "Error!";

                // An invalid response message error is distinct from a successfully decoded error.
                var errorToPresent = response != null 
                    ? response.Error 
                    : decodeError;
                message = string.Format("Payment creation failed with error {0}", errorToPresent.LocalizedDescription);
            }

            var alertView = new UIAlertView(title, message, null, "OK");
            alertView.Show();

            return true;
        }
    }
}


