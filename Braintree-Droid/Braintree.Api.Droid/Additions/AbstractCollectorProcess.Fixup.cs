using Android.Runtime;
using JObject = Java.Lang.Object;

namespace Braintree.Device_Collector
{
    public abstract partial class AbstractCollectorProcess
    {
        protected override JObject DoInBackground(params JObject[] @params)
        {
            var invoker = new AbstractCollectorProcessInvoker(Handle, JniHandleOwnership.TransferLocalRef);

            return invoker.DoInBackground(@params);
        }
    }
}