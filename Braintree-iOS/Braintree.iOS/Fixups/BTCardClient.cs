using System;
using System.Threading.Tasks;
using Foundation;

namespace Braintree
{
	public partial class BTCardClient
	{
		public Task<string> TokenizeCardAsync(BTCard card)
		{
			var tcs = new TaskCompletionSource<string>();

			TokenizeCard(card, (nonce, error) =>
				{
					if(error != null)
					{
						var exception = new NSErrorException(error);

						tcs.TrySetException(exception);
					}

					tcs.TrySetResult(((BTPaymentMethodNonce)nonce).Nonce);
				});
			return tcs.Task;
		}
	}
}

