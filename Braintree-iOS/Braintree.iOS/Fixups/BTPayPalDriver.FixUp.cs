using System;
using System.Threading.Tasks;
using System.Linq;
using Foundation;


namespace Braintree
{
	public partial class BTPayPalDriver
	{

		public Task<BTPaymentMethodNonce> AuthorizeAccountWithAdditionalScopesAsync(string[] payload)
		{
			var tcs = new TaskCompletionSource<BTPaymentMethodNonce>();

			var paypalScope = new NSSet<NSString>(payload.Select(p => new NSString(p)).ToArray());

			AuthorizeAccountWithAdditionalScopes(paypalScope, (paypalNonce, error) =>
				{
					if(error != null)
					{
						var exception = new NSErrorException(error);

						tcs.TrySetException(exception);

						return;
					}

					tcs.TrySetResult((BTPaymentMethodNonce)paypalNonce);
				});
					

			return tcs.Task;
		}


		public Task<BTPaymentMethodNonce> AuthorizeAccountWithCompletion()
		{
			var tcs = new TaskCompletionSource<BTPaymentMethodNonce>();

			AuthorizeAccountWithCompletion((paypalNonce, error) =>
				{
					if(error != null)
					{
						var exception = new NSErrorException(error);

						tcs.TrySetException(exception);

						return;
					}

					tcs.TrySetResult((BTPaymentMethodNonce)paypalNonce);
				});

			return tcs.Task;
		}
	}
}
