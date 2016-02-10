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
        public async Task<PaymentMethodNonce> TokenizeAsync(CardBuilder card)
        {
            var actionListener = new PaymentMethodNonceListener();
            try
            {
                AddListener(actionListener);

                Card.Tokenize(this, card);

                return await actionListener.Task();
            }
            // There is no catch statements here. Exception handling must be done by caller.
            finally
            {
                RemoveListener(actionListener);
            }
        }

        public async Task<PaymentMethodNonce> GetPaymentNonceAsync()
        {
            var actionListener = new PaymentMethodNonceListener();
            try
            {
                AddListener(actionListener);

                return await actionListener.Task();
            }
            // There is no catch statements here. Exception handling must be done by caller.
            finally
            {
                RemoveListener(actionListener);
            }
        }

        public async Task<PaymentMethodNonce> AuthorizePaypalPaymentAsync(bool requestBillingAgreement, string[] additionalParameters = null, PayPalRequest request = null)
        {
            var actionListener = new PaymentMethodNonceListener();
            try
            {
                AddListener(actionListener);

                PayPal.AuthorizeAccount(this, additionalParameters);

                if (requestBillingAgreement)
                {
                    PayPal.RequestBillingAgreement(this, request??new PayPalRequest());
                }

                return await actionListener.Task();
            }
            finally
            {
                RemoveListener(actionListener);
            }
        }

        private class PaymentMethodNonceListener : JObject, IPaymentMethodNonceCreatedListener, IBraintreeCancelListener, IBraintreeErrorListener
        {
            private readonly TaskCompletionSource<PaymentMethodNonce> _paymentMethodNonce;

            public bool IsCompleted
            {
                get { return _paymentMethodNonce.Task.IsCompleted; }
            }

            public PaymentMethodNonceListener()
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