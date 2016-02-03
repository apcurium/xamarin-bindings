using Android.Runtime;
using JObject = Java.Lang.Object;

namespace Braintree.Device_Collector.Collectors
{
    public abstract partial class AbstractAsyncCollectorTask
    {
        protected override JObject DoInBackground(params JObject[] @params)
        {
            var invoker = new AbstractAsyncCollectorTaskInvoker(Handle, JniHandleOwnership.TransferLocalRef);

            return invoker.DoInBackground(@params);
        }
    }
}