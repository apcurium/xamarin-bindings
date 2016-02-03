using System;
using System.Threading.Tasks;
using System.Linq;
using Foundation;


namespace Braintree
{
	public partial class BTPayPalDriver
	{

		public Task<string> AuthorizeAccountWithAdditionalScopesAsync(string[] payload)
		{
			var tcs = new TaskCompletionSource<string>();

			var paypalScope = new NSSet<NSString>(payload.Select(p => new NSString(p)).ToArray());

			AuthorizeAccountWithAdditionalScopes(paypalScope, (paypalNonce, error) =>
				{
					if(error != null)
					{
						var exception = new NSErrorException(error);

						tcs.TrySetException(exception);

						return;
					}

					tcs.TrySetResult(((BTPaymentMethodNonce)paypalNonce).Nonce);
				});
					

			return tcs.Task;
		}


		public Task<string> AuthorizeAccountWithCompletion()
		{
			var tcs = new TaskCompletionSource<string>();

			AuthorizeAccountWithCompletion((paypalNonce, error) =>
				{
					if(error != null)
					{
						var exception = new NSErrorException(error);

						tcs.TrySetException(exception);

						return;
					}

					tcs.TrySetResult(((BTPaymentMethodNonce)paypalNonce).Nonce);
				});

			return tcs.Task;
		}
	}
}
