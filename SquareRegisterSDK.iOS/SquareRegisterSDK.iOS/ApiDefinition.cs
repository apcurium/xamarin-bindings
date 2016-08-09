using System;
using Foundation;
using ObjCRuntime;
using SquareRegisterSDK;

namespace SquareRegisterSDK.iOS
{
    // @interface SCCAdditions (NSError)
    [Category]
    [BaseType(typeof(NSError))]
    interface NSError_SCCAdditions
    {
        // +(NSError * _Nonnull)SCC_missingCurrencyCodeError;
        [Static]
        [Export("SCC_missingCurrencyCodeError")]
        NSError SCC_missingCurrencyCodeError { get; }

        // +(NSError * _Nonnull)SCC_unsupportedCurrencyCodeError;
        [Static]
        [Export("SCC_unsupportedCurrencyCodeError")]
        NSError SCC_unsupportedCurrencyCodeError { get; }

        // +(NSError * _Nonnull)SCC_missingRequestClientIDError;
        [Static]
        [Export("SCC_missingRequestClientIDError")]
        NSError SCC_missingRequestClientIDError { get; }

        // +(NSError * _Nonnull)SCC_invalidRequestCallbackURLError;
        [Static]
        [Export("SCC_invalidRequestCallbackURLError")]
        NSError SCC_invalidRequestCallbackURLError { get; }

        // +(NSError * _Nonnull)SCC_invalidRequestAmountError;
        [Static]
        [Export("SCC_invalidRequestAmountError")]
        NSError SCC_invalidRequestAmountError { get; }

        // +(NSError * _Nonnull)SCC_cannotPerformRequestError;
        [Static]
        [Export("SCC_cannotPerformRequestError")]
        NSError SCC_cannotPerformRequestError { get; }

        // +(NSError * _Nonnull)SCC_unableToGenerateRequestJSONError;
        [Static]
        [Export("SCC_unableToGenerateRequestJSONError")]
        NSError SCC_unableToGenerateRequestJSONError { get; }

        // +(NSError * _Nonnull)SCC_missingOrInvalidResponseDataError;
        [Static]
        [Export("SCC_missingOrInvalidResponseDataError")]
        NSError SCC_missingOrInvalidResponseDataError { get; }

        // +(NSError * _Nonnull)SCC_missingOrInvalidResponseJSONDataError;
        [Static]
        [Export("SCC_missingOrInvalidResponseJSONDataError")]
        NSError SCC_missingOrInvalidResponseJSONDataError { get; }

        // +(NSError * _Nonnull)SCC_missingOrInvalidResponseStatusError;
        [Static]
        [Export("SCC_missingOrInvalidResponseStatusError")]
        NSError SCC_missingOrInvalidResponseStatusError { get; }

        // +(NSError * _Nonnull)SCC_missingOrInvalidResponsePaymentIDError;
        [Static]
        [Export("SCC_missingOrInvalidResponsePaymentIDError")]
        NSError SCC_missingOrInvalidResponsePaymentIDError { get; }

        // +(NSError * _Nonnull)SCC_missingOrInvalidResponseErrorCodeError;
        [Static]
        [Export("SCC_missingOrInvalidResponseErrorCodeError")]
        NSError SCC_missingOrInvalidResponseErrorCodeError { get; }
    }

    // @interface SCCAPIAdditions (NSError)
    [Category]
    [BaseType(typeof(NSError))]
    interface NSError_SCCAPIAdditions
    {
        // +(NSError * _Nonnull)SCC_APIErrorWithCode:(SCCAPIErrorCode)code;
        [Static]
        [Export("SCC_APIErrorWithCode:")]
        NSError SCC_APIErrorWithCode (SCCAPIErrorCode code);
    }

    [Static]
    partial interface Constants
    {
        // extern NSString *const _Nonnull SCCErrorDomain;
        [Field("SCCErrorDomain", "__Internal")]
        NSString SCCErrorDomain { get; }

        // extern NSString *const _Nonnull SCCAPIErrorDomain;
        [Field("SCCAPIErrorDomain", "__Internal")]
        NSString SCCAPIErrorDomain { get; }

        // extern NSString *const _Nonnull SCCAPIErrorUserInfoCodeStringKey;
        [Field("SCCAPIErrorUserInfoCodeStringKey", "__Internal")]
        NSString SCCAPIErrorUserInfoCodeStringKey { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringPaymentCanceled;
        [Field("SCCAPIErrorStringPaymentCanceled", "__Internal")]
        NSString SCCAPIErrorStringPaymentCanceled { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringPayloadMissingOrInvalid;
        [Field("SCCAPIErrorStringPayloadMissingOrInvalid", "__Internal")]
        NSString SCCAPIErrorStringPayloadMissingOrInvalid { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringAppNotLoggedIn;
        [Field("SCCAPIErrorStringAppNotLoggedIn", "__Internal")]
        NSString SCCAPIErrorStringAppNotLoggedIn { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringLoginCodeInvalidOrExpired;
        [Field("SCCAPIErrorStringLoginCodeInvalidOrExpired", "__Internal")]
        NSString SCCAPIErrorStringLoginCodeInvalidOrExpired { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringMerchantIDMismatch;
        [Field("SCCAPIErrorStringMerchantIDMismatch", "__Internal")]
        NSString SCCAPIErrorStringMerchantIDMismatch { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringClientNotAuthorizedForUser;
        [Field("SCCAPIErrorStringClientNotAuthorizedForUser", "__Internal")]
        NSString SCCAPIErrorStringClientNotAuthorizedForUser { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringUserNotActivated;
        [Field("SCCAPIErrorStringUserNotActivated", "__Internal")]
        NSString SCCAPIErrorStringUserNotActivated { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringCurrencyMissingOrInvalid;
        [Field("SCCAPIErrorStringCurrencyMissingOrInvalid", "__Internal")]
        NSString SCCAPIErrorStringCurrencyMissingOrInvalid { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringCurrencyUnsupported;
        [Field("SCCAPIErrorStringCurrencyUnsupported", "__Internal")]
        NSString SCCAPIErrorStringCurrencyUnsupported { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringCurrencyMismatch;
        [Field("SCCAPIErrorStringCurrencyMismatch", "__Internal")]
        NSString SCCAPIErrorStringCurrencyMismatch { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringAmountMissingOrInvalid;
        [Field("SCCAPIErrorStringAmountMissingOrInvalid", "__Internal")]
        NSString SCCAPIErrorStringAmountMissingOrInvalid { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringAmountTooSmall;
        [Field("SCCAPIErrorStringAmountTooSmall", "__Internal")]
        NSString SCCAPIErrorStringAmountTooSmall { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringAmountTooLarge;
        [Field("SCCAPIErrorStringAmountTooLarge", "__Internal")]
        NSString SCCAPIErrorStringAmountTooLarge { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringInvalidTenderType;
        [Field("SCCAPIErrorStringInvalidTenderType", "__Internal")]
        NSString SCCAPIErrorStringInvalidTenderType { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringUnsupportedTenderType;
        [Field("SCCAPIErrorStringUnsupportedTenderType", "__Internal")]
        NSString SCCAPIErrorStringUnsupportedTenderType { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringCouldNotPerform;
        [Field("SCCAPIErrorStringCouldNotPerform", "__Internal")]
        NSString SCCAPIErrorStringCouldNotPerform { get; }

        // extern NSString *const _Nonnull SCCAPIErrorStringNoNetworkConnection;
        [Field("SCCAPIErrorStringNoNetworkConnection", "__Internal")]
        NSString SCCAPIErrorStringNoNetworkConnection { get; }

        // extern NSString *const _Nonnull SCCAPIRequestClientIDKey;
        [Field("SCCAPIRequestClientIDKey", "__Internal")]
        NSString SCCAPIRequestClientIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestAmountMoneyKey;
        [Field("SCCAPIRequestAmountMoneyKey", "__Internal")]
        NSString SCCAPIRequestAmountMoneyKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestCallbackURLKey;
        [Field("SCCAPIRequestCallbackURLKey", "__Internal")]
        NSString SCCAPIRequestCallbackURLKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestLoginCodeKey;
        [Field("SCCAPIRequestLoginCodeKey", "__Internal")]
        NSString SCCAPIRequestLoginCodeKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestStateKey;
        [Field("SCCAPIRequestStateKey", "__Internal")]
        NSString SCCAPIRequestStateKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestMerchantIDKey;
        [Field("SCCAPIRequestMerchantIDKey", "__Internal")]
        NSString SCCAPIRequestMerchantIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestNotesKey;
        [Field("SCCAPIRequestNotesKey", "__Internal")]
        NSString SCCAPIRequestNotesKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestOptionsKey;
        [Field("SCCAPIRequestOptionsKey", "__Internal")]
        NSString SCCAPIRequestOptionsKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestOptionsClearDefaultFeesKey;
        [Field("SCCAPIRequestOptionsClearDefaultFeesKey", "__Internal")]
        NSString SCCAPIRequestOptionsClearDefaultFeesKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestOptionsSupportedTenderTypesKey;
        [Field("SCCAPIRequestOptionsSupportedTenderTypesKey", "__Internal")]
        NSString SCCAPIRequestOptionsSupportedTenderTypesKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestOptionsAutoReturnKey;
        [Field("SCCAPIRequestOptionsAutoReturnKey", "__Internal")]
        NSString SCCAPIRequestOptionsAutoReturnKey { get; }

        // extern NSString *const _Nonnull SCCAPIRequestOptionsTenderTypeStringCard;
        [Field("SCCAPIRequestOptionsTenderTypeStringCard", "__Internal")]
        NSString SCCAPIRequestOptionsTenderTypeStringCard { get; }

        // extern NSString *const _Nonnull SCCAPIResponseDataKey;
        [Field("SCCAPIResponseDataKey", "__Internal")]
        NSString SCCAPIResponseDataKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseStatusKey;
        [Field("SCCAPIResponseStatusKey", "__Internal")]
        NSString SCCAPIResponseStatusKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseErrorCodeKey;
        [Field("SCCAPIResponseErrorCodeKey", "__Internal")]
        NSString SCCAPIResponseErrorCodeKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponsePaymentIDKey;
        [Field("SCCAPIResponsePaymentIDKey", "__Internal")]
        NSString SCCAPIResponsePaymentIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseTransactionIDKey;
        [Field("SCCAPIResponseTransactionIDKey", "__Internal")]
        NSString SCCAPIResponseTransactionIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseClientTransactionIDKey;
        [Field("SCCAPIResponseClientTransactionIDKey", "__Internal")]
        NSString SCCAPIResponseClientTransactionIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseOfflinePaymentIDKey;
        [Field("SCCAPIResponseOfflinePaymentIDKey", "__Internal")]
        NSString SCCAPIResponseOfflinePaymentIDKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseStateKey;
        [Field("SCCAPIResponseStateKey", "__Internal")]
        NSString SCCAPIResponseStateKey { get; }

        // extern NSString *const _Nonnull SCCAPIResponseStatusStringOK;
        [Field("SCCAPIResponseStatusStringOK", "__Internal")]
        NSString SCCAPIResponseStatusStringOK { get; }

        // extern NSString *const _Nonnull SCCAPIResponseStatusStringError;
        [Field("SCCAPIResponseStatusStringError", "__Internal")]
        NSString SCCAPIResponseStatusStringError { get; }

        // extern NSString *const _Nonnull SCCMoneyRequestDictionaryAmountKey;
        [Field("SCCMoneyRequestDictionaryAmountKey", "__Internal")]
        NSString SCCMoneyRequestDictionaryAmountKey { get; }

        // extern NSString *const _Nonnull SCCMoneyRequestDictionaryCurrencyCodeKey;
        [Field("SCCMoneyRequestDictionaryCurrencyCodeKey", "__Internal")]
        NSString SCCMoneyRequestDictionaryCurrencyCodeKey { get; }

        // extern double SquareRegisterSDKVersionNumber;
        [Field("SquareRegisterSDKVersionNumber", "__Internal")]
        double SquareRegisterSDKVersionNumber { get; }

        // extern const unsigned char [] SquareRegisterSDKVersionString;
        [Field("SquareRegisterSDKVersionString", "__Internal")]
        IntPtr SquareRegisterSDKVersionString { get; }
    }

    // @interface SCCAPIConnection : NSObject
    [BaseType(typeof(NSObject))]
    interface SCCAPIConnection
    {
        // +(BOOL)canPerformRequest:(SCCAPIRequest * _Nonnull)request error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("canPerformRequest:error:")]
        bool CanPerformRequest (SCCAPIRequest request, [NullAllowed] out NSError error);

        // +(BOOL)performRequest:(SCCAPIRequest * _Nonnull)request error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("performRequest:error:")]
        bool PerformRequest (SCCAPIRequest request, [NullAllowed] out NSError error);
    }

    // @interface  (SCCAPIConnection)
    [Category]
    [BaseType(typeof(SCCAPIConnection))]
    [DisableDefaultCtor]
    interface SCCAPIConnection_
    {
    }

    // @interface SCCAPIRequest : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCCAPIRequest : INSCopying
    {
        // +(void)setClientID:(NSString * _Nullable)clientID;
        [Static]
        [Export("setClientID:")]
        void SetClientID ([NullAllowed] string clientID);

        // +(instancetype _Nullable)requestWithCallbackURL:(NSURL * _Nonnull)callbackURL amount:(SCCMoney * _Nonnull)amount userInfoString:(NSString * _Nullable)userInfoString merchantID:(NSString * _Nullable)merchantID notes:(NSString * _Nullable)notes supportedTenderTypes:(SCCAPIRequestTenderTypes)supportedTenderTypes clearsDefaultFees:(BOOL)clearsDefaultFees returnAutomaticallyAfterPayment:(BOOL)autoreturn error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("requestWithCallbackURL:amount:userInfoString:merchantID:notes:supportedTenderTypes:clearsDefaultFees:returnAutomaticallyAfterPayment:error:")]
        [return: NullAllowed]
        SCCAPIRequest RequestWithCallbackURL (NSUrl callbackURL, SCCMoney amount, [NullAllowed] string userInfoString, [NullAllowed] string merchantID, [NullAllowed] string notes, SCCAPIRequestTenderTypes supportedTenderTypes, bool clearsDefaultFees, bool autoreturn, [NullAllowed] out NSError error);

        // @property (readonly, copy, nonatomic) NSString * _Nonnull clientID;
        [Export("clientID")]
        string ClientID { get; }

        // @property (readonly, copy, nonatomic) NSURL * _Nonnull callbackURL;
        [Export("callbackURL", ArgumentSemantic.Copy)]
        NSUrl CallbackURL { get; }

        // @property (readonly, copy, nonatomic) SCCMoney * _Nonnull amount;
        [Export("amount", ArgumentSemantic.Copy)]
        SCCMoney Amount { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable userInfoString;
        [NullAllowed, Export("userInfoString")]
        string UserInfoString { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable merchantID;
        [NullAllowed, Export("merchantID")]
        string MerchantID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable notes;
        [NullAllowed, Export("notes")]
        string Notes { get; }

        // @property (readonly, assign, nonatomic) SCCAPIRequestTenderTypes supportedTenderTypes;
        [Export("supportedTenderTypes", ArgumentSemantic.Assign)]
        SCCAPIRequestTenderTypes SupportedTenderTypes { get; }

        // @property (readonly, assign, nonatomic) BOOL clearsDefaultFees;
        [Export("clearsDefaultFees")]
        bool ClearsDefaultFees { get; }

        // @property (readonly, assign, nonatomic) BOOL returnsAutomaticallyAfterPayment;
        [Export("returnsAutomaticallyAfterPayment")]
        bool ReturnsAutomaticallyAfterPayment { get; }

        // -(BOOL)isEqualToAPIRequest:(SCCAPIRequest * _Nullable)request;
        [Export("isEqualToAPIRequest:")]
        bool IsEqualToAPIRequest ([NullAllowed] SCCAPIRequest request);
    }

    // @interface  (SCCAPIRequest)
    [Category]
    [BaseType(typeof(SCCAPIRequest))]
    [DisableDefaultCtor]
    interface SCCAPIRequest_
    {
    }

    // @interface Serialization (SCCAPIRequest)
    [Category]
    [BaseType(typeof(SCCAPIRequest))]
    interface SCCAPIRequest_Serialization
    {
        // -(NSURL * _Nullable)APIRequestURLWithError:(NSError * _Nullable * _Nullable)error;
        [Export("APIRequestURLWithError:")]
        [return: NullAllowed]
        NSUrl APIRequestURLWithError ([NullAllowed] out NSError error);
    }

    // @interface SCCAPIResponse : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCCAPIResponse : INSCopying
    {
        // +(instancetype _Nullable)responseWithResponseURL:(NSURL * _Nonnull)URL error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("responseWithResponseURL:error:")]
        [return: NullAllowed]
        SCCAPIResponse ResponseWithResponseURL (NSUrl URL, [NullAllowed] out NSError error);

        // @property (readonly, copy, nonatomic) NSString * _Nullable userInfoString;
        [NullAllowed, Export("userInfoString")]
        string UserInfoString { get; }

        // @property (readonly, copy, nonatomic) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Copy)]
        NSError Error { get; }

        // @property (readonly, getter = isSuccessResponse, assign, nonatomic) BOOL successResponse;
        [Export("successResponse")]
        bool SuccessResponse { [Bind("isSuccessResponse")] get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable paymentID;
        [NullAllowed, Export("paymentID")]
        string PaymentID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable offlinePaymentID;
        [NullAllowed, Export("offlinePaymentID")]
        string OfflinePaymentID { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable transactionID;
        [NullAllowed, Export("transactionID")]
        string TransactionID { get; }

        // -(BOOL)isEqualToAPIResponse:(SCCAPIResponse * _Nullable)response;
        [Export("isEqualToAPIResponse:")]
        bool IsEqualToAPIResponse ([NullAllowed] SCCAPIResponse response);
    }

    // @interface  (SCCAPIResponse)
    [Category]
    [BaseType(typeof(SCCAPIResponse))]
    [DisableDefaultCtor]
    interface SCCAPIResponse_
    {
    }

    // @interface SCCMoney : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface SCCMoney : INSCopying
    {
        // +(instancetype _Nullable)moneyWithAmountCents:(NSInteger)amountCents currencyCode:(NSString * _Nonnull)currencyCode error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("moneyWithAmountCents:currencyCode:error:")]
        [return: NullAllowed]
        SCCMoney MoneyWithAmountCents (nint amountCents, string currencyCode, [NullAllowed] out NSError error);

        // @property (readonly, assign, nonatomic) NSInteger amountCents;
        [Export("amountCents")]
        nint AmountCents { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nonnull currencyCode;
        [Export("currencyCode")]
        string CurrencyCode { get; }

        // -(BOOL)isEqualToSCCMoney:(SCCMoney * _Nullable)money;
        [Export("isEqualToSCCMoney:")]
        bool IsEqualToSCCMoney ([NullAllowed] SCCMoney money);
    }

    // @interface  (SCCMoney)
    [Category]
    [BaseType(typeof(SCCMoney))]
    [DisableDefaultCtor]
    interface SCCMoney_
    {
    }

    // @interface Serialization (SCCMoney)
    [Category]
    [BaseType(typeof(SCCMoney))]
    interface SCCMoney_Serialization
    {
        // -(NSDictionary * _Nonnull)requestDictionaryRepresentation;
        [Export("requestDictionaryRepresentation")]
        NSDictionary RequestDictionaryRepresentation ();
    }
}

