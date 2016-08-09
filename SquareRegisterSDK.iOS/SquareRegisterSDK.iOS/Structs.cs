using System;
using System.Runtime.InteropServices;
using Foundation;
using ObjCRuntime;
using SquareRegisterSDK;
using UIKit;

namespace SquareRegisterSDK.iOS
{
    [Native]
    public enum SCCErrorCode : long
    {
        Unknown = 0,
        MissingCurrencyCode,
        UnsupportedCurrencyCode,
        MissingRequestClientID,
        InvalidRequestCallbackURL,
        InvalidRequestAmount,
        CannotPerformRequest,
        UnableToGenerateRequestJSON,
        MissingOrInvalidResponseData,
        MissingOrInvalidResponseJSONData,
        MissingOrInvalidResponseStatus,
        MissingOrInvalidResponsePaymentID,
        MissingOrInvalidResponseErrorCode
    }

    [Native]
    public enum SCCAPIErrorCode : long
    {
        Unknown = 0,
        PaymentCanceled,
        PayloadMissingOrInvalid,
        AppNotLoggedIn,
        LoginCodeInvalidOrExpired,
        MerchantIDMismatch,
        UserNotActivated,
        CurrencyMissingOrInvalid,
        CurrencyUnsupported,
        CurrencyMismatch,
        AmountMissingOrInvalid,
        AmountTooSmall,
        AmountTooLarge,
        InvalidTenderType,
        UnsupportedTenderType,
        CouldNotPerform,
        NoNetworkConnection,
        ClientNotAuthorizedForUser
    }

    static class CFunctions
    {
        // extern SCCAPIErrorCode SCCAPIErrorCodeFromString (NSString * _Nullable errorCodeString);
        [DllImport ("__Internal")]
        static extern SCCAPIErrorCode SCCAPIErrorCodeFromString (NSString errorCodeString);

        // extern NSString * _Nullable NSStringFromSCCAPIErrorCode (SCCAPIErrorCode errorCode);
        [DllImport ("__Internal")]
        static extern NSString NSStringFromSCCAPIErrorCode (SCCAPIErrorCode errorCode);

        // extern NSArray * _Nonnull NSArrayOfTenderTypeStringsFromSCCAPIRequestTenderTypes (SCCAPIRequestTenderTypes tenderTypes);
        [DllImport ("__Internal")]
        static extern NSObject[] NSArrayOfTenderTypeStringsFromSCCAPIRequestTenderTypes (SCCAPIRequestTenderTypes tenderTypes);

        // extern SCCAPIResponseStatus SCCAPIResponseStatusFromString (NSString * _Nullable statusString);
        [DllImport ("__Internal")]
        static extern SCCAPIResponseStatus SCCAPIResponseStatusFromString (NSString statusString);
    }

    [Native]
    public enum SCCAPIRequestTenderTypes : ulong
    {
        All = (9223372036854775807UL * 2 + 1),
        Card = 1 << 0
    }

    [Native]
    public enum SCCAPIResponseStatus : uint
    {
        Unknown = 0,
        Ok,
        Error
    }
}

