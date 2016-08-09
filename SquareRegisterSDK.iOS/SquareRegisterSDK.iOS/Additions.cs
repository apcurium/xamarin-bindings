using Foundation;

namespace SquareRegisterSDK.iOS
{
    public static class Additions
    {
        public static string GetClientTransactionId (this NSUrl url, out NSError error)
        {
            error = null;
            var parameters = SCC_HTTPGETParameters(url);

            var dataString = parameters.SCC_stringForKey(Constants.SCCAPIResponseDataKey);
            if(dataString.Length == 0)
            {
                if(error == null)
                {
                    error = NSError_SCCAdditions.SCC_missingOrInvalidResponseDataError;
                }
                return null;
            }

            NSDictionary data = null;
            var jsonData = NSData.FromString(dataString, NSStringEncoding.UTF8);
            var jsonObject = NSJsonSerialization.Deserialize(jsonData, 0, out error);
            if(!jsonObject.IsKindOfClass(new ObjCRuntime.Class(typeof(NSDictionary))))
            {
                if(error == null)
                {
                    error = NSError_SCCAdditions.SCC_missingOrInvalidResponseJSONDataError;
                }
                return null;
            }
            else
            {
                data = (NSDictionary)jsonObject;
            }

            var statusString = data.SCC_stringForKey(Constants.SCCAPIResponseStatusKey);
            var status = SCCAPIResponseStatusFromString(statusString);
            if(status == SCCAPIResponseStatus.Unknown
               || status == SCCAPIResponseStatus.Error)
            {
                if(error == null)
                {
                    error = NSError_SCCAdditions.SCC_missingOrInvalidResponseStatusError;
                }
                return null;
            }

            return data.SCC_stringForKey(Constants.SCCAPIResponseClientTransactionIDKey);
        }

        private static string SCC_stringForKey (this NSDictionary dictionary, NSObject key)
        {
            var obj = dictionary.ObjectForKey(key);
            if(obj.IsKindOfClass(new ObjCRuntime.Class(typeof(NSString))))
            {
                return obj.ToString();
            }
            return null;
        }

        private static NSDictionary SCC_HTTPGETParameters (NSUrl url)
        {
            var parameters = new NSMutableDictionary();
            var components = NSUrlComponents.FromUrl(url, false);

            foreach(var queryItem in components.QueryItems)
            {
                if(queryItem.Value.Length > 0)
                {
                    parameters.Add(new NSString(queryItem.Name), new NSString(queryItem.Value));
                }
                else
                {
                    parameters.Add(new NSString(queryItem.Name), null);
                }
            }

            return parameters;
        }


        private static SCCAPIResponseStatus SCCAPIResponseStatusFromString (string statusString)
        {
            if(statusString.Length == 0)
            {
                return SCCAPIResponseStatus.Unknown;
            }

            if(statusString == Constants.SCCAPIResponseStatusStringOK)
            {
                return SCCAPIResponseStatus.Ok;
            }

            if(statusString == Constants.SCCAPIResponseStatusStringError)
            {
                return SCCAPIResponseStatus.Error;
            }

            return SCCAPIResponseStatus.Unknown;
        }
    }
}

