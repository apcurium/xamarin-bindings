using System;
using Android.Runtime;
using Object = Java.Lang.Object;

namespace Braintree.Api
{
    public partial class PaymentButton
    {
        private static Delegate cb_onResponse_view_view;
        private static IntPtr id_onResponse_Landroid_view_View_;

#pragma warning disable 0169
        static Delegate GetOnResponse_Landroid_view_View_Handler()
        {
            if (cb_onResponse_view_view == null)
            {
                cb_onResponse_view_view = JNINativeWrapper.CreateDelegate((Action<IntPtr, IntPtr, IntPtr>)n_OnResponse_Landroid_view_View_);
            }
                
            return cb_onClick_Landroid_view_View_;
        }

        static void n_OnResponse_Landroid_view_View_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
        {
            var __this = GetObject<PaymentButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
            Android.Views.View p0 = GetObject<Android.Views.View>(native_p0, JniHandleOwnership.DoNotTransfer);
            __this.OnClick(p0);
        }
#pragma warning restore 0169

        [Register("onResponse", "(Landroid/view/View;)V", "GetOnResponse_Landroid_view_View_Handler")]
        public void OnResponse(Object p0)
        {
            if (id_onResponse_Landroid_view_View_ == IntPtr.Zero)
            {
                id_onResponse_Landroid_view_View_ = JNIEnv.GetMethodID(class_ref, "onResponse", "(Landroid/view/View;)V");
            }
                
            try
            {
                unsafe
                {
                    JValue* args = stackalloc JValue[1];
                    args[0] = new JValue(p0);

                    if (GetType() == ThresholdType)
                    {
                        JNIEnv.CallVoidMethod(Handle, id_onResponse_Landroid_view_View_, args);
                    }

                    else
                    {
                        JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "onClick", "(Landroid/view/View;)V"), args);
                    }
                }
            }
            finally
            {
            }

        }
    }
}
