using System;
using Android.Runtime;

namespace Braintree.Cardform.View
{
    public partial class ErrorEditText
    {
        private static IntPtr _idIsError;

        public new unsafe bool Error
        {
            
            // Metadata.xml XPath method reference: path="/api/package[@name='com.braintreepayments.cardform.view']/class[@name='ErrorEditText']/method[@name='isError' and count(parameter)=0]"
            [Register("isError", "()Z", "GetIsErrorHandler")]
            get
            {
                if (_idIsError == IntPtr.Zero)
                {
                    _idIsError = JNIEnv.GetMethodID(ThresholdClass, "isError", "()Z");
                }
                try
                {

                    return GetType() == ThresholdType 
                        ? JNIEnv.CallBooleanMethod(Handle, _idIsError) 
                        : JNIEnv.CallNonvirtualBooleanMethod(Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "isError", "()Z"));
                        
                }
                finally
                {
                }
            }
            // Metadata.xml XPath method reference: path="/api/package[@name='com.braintreepayments.cardform.view']/class[@name='ErrorEditText']/method[@name='setError' and count(parameter)=1 and parameter[1][@type='boolean']]"
            [Register("setError", "(Z)V", "GetSetError_ZHandler")]
            set
            {
                if (id_setError_Z == IntPtr.Zero)
                {
                    id_setError_Z = JNIEnv.GetMethodID(ThresholdClass, "setError", "(Z)V");
                }
                try
                {
                    JValue* args = stackalloc JValue[1];
                    args[0] = new JValue(value);

                    if (GetType() == ThresholdType)
                    {
                        JNIEnv.CallVoidMethod(Handle, id_setError_Z, args);
                    }

                    else
                    {
                        JNIEnv.CallNonvirtualVoidMethod(Handle, ThresholdClass, JNIEnv.GetMethodID(ThresholdClass, "setError", "(Z)V"), args);
                    }
                }
                finally
                {
                }
            }
        }
    }
}
