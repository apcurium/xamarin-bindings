using System.Threading.Tasks;
using Braintree.Api.Interfaces;
using Braintree.Api.Models;

//Java Lang
using Throwable = Java.Lang.Throwable;
using JException = Java.Lang.Exception;
using JObject = Java.Lang.Object;

namespace Braintree.Api
{
    public partial class BraintreeFragment
    {
        /// <summary>
        /// This method generates a listener for PaymentMethodNonceCreated, Cancel and Error events and returns a result or an error dependent on 
        /// what the system answer.
        /// </summary>
        /// <remarks>
        ///     This method will throw TaskCancelException if Cancel event occurs in brantree.
        /// 
        ///     This method will remove the listener when it's done with the screen.
        /// </remarks>
        /// <returns>
        ///     A paymetnMethodNonce object wrapped in a Task containing the payment method nonce to be used by the server.
        /// </returns>
        public async Task<PaymentMethodNonce> GetPaymentMethodNonceTask()
        {
            var actionListener = new BraintreeFragmentPaymentMethodNonceListener();
            try
            {
                AddListener(actionListener);

                var result = await actionListener.Task();

                return result;
            }
            // There is no catch statements here. Exception handling must be done by caller.
            finally
            {
                RemoveListener(actionListener);
            }
        }

        private class BraintreeFragmentPaymentMethodNonceListener : JObject, IPaymentMethodNonceCreatedListener, IBraintreeCancelListener, IBraintreeErrorListener
        {
            private readonly TaskCompletionSource<PaymentMethodNonce> _paymentMethodNonce;

            public BraintreeFragmentPaymentMethodNonceListener()
            {
                _paymentMethodNonce = new TaskCompletionSource<PaymentMethodNonce>();
            }

            public void OnError(JException p0)
            {
                var ex = Throwable.ToException(p0);

                _paymentMethodNonce.TrySetException(ex);
            }

            public void OnCancel(int p0)
            {
                _paymentMethodNonce.TrySetCanceled();
            }

            public void OnPaymentMethodNonceCreated(PaymentMethodNonce p0)
            {
                _paymentMethodNonce.TrySetResult(p0);
            }

            public Task<PaymentMethodNonce> Task()
            {
                return _paymentMethodNonce.Task;
            } 
        }
    }
}