using System;
using CoreFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using PassKit;
using SafariServices;
using UIKit;

namespace Braintree
{
//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double Braintree3DSecureVersionNumber;
//		[Field ("Braintree3DSecureVersionNumber", "__Internal")]
//		double Braintree3DSecureVersionNumber { get; }
//
//		// extern const unsigned char [] Braintree3DSecureVersionString;
//		[Field ("Braintree3DSecureVersionString", "__Internal")]
//		byte[] Braintree3DSecureVersionString { get; }
//
//		// extern double BraintreeCoreVersionNumber;
//		[Field ("BraintreeCoreVersionNumber", "__Internal")]
//		double BraintreeCoreVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreeCoreVersionString;
//		[Field ("BraintreeCoreVersionString", "__Internal")]
//		byte[] BraintreeCoreVersionString { get; }
//	}

	// @interface BTClientMetadata : NSObject <NSCopying, NSMutableCopying>
	[BaseType (typeof(NSObject))]
	interface BTClientMetadata : INSCopying, INSMutableCopying
	{
		// @property (readonly, assign, nonatomic) BTClientMetadataIntegrationType integration;
		[Export ("integration", ArgumentSemantic.Assign)]
		BTClientMetadataIntegrationType Integration { get; }

		// @property (readonly, assign, nonatomic) BTClientMetadataSourceType source;
		[Export ("source", ArgumentSemantic.Assign)]
		BTClientMetadataSourceType Source { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sessionId;
		[Export ("sessionId")]
		string SessionId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull integrationString;
		[Export ("integrationString")]
		string IntegrationString { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull sourceString;
		[Export ("sourceString")]
		string SourceString { get; }

		// @property (readonly, nonatomic, strong) NSDictionary * _Nonnull parameters;
		[Export ("parameters", ArgumentSemantic.Strong)]
		NSDictionary Parameters { get; }
	}

	// @interface BTMutableClientMetadata : BTClientMetadata
	[BaseType (typeof(BTClientMetadata))]
	interface BTMutableClientMetadata
	{
		// -(void)setIntegration:(BTClientMetadataIntegrationType)integration;
		[Export ("setIntegration:")]
		void SetIntegration (BTClientMetadataIntegrationType integration);

		// -(void)setSource:(BTClientMetadataSourceType)source;
		[Export ("setSource:")]
		void SetSource (BTClientMetadataSourceType source);

		// -(void)setSessionId:(NSString * _Nonnull)sessionId;
		[Export ("setSessionId:")]
		void SetSessionId (string sessionId);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTJSONErrorDomain;
//		[Field ("BTJSONErrorDomain", "__Internal")]
//		NSString BTJSONErrorDomain { get; }
//	}

	// @interface BTJSON : NSObject
	[BaseType (typeof(NSObject))]
	interface BTJSON
	{
		// -(instancetype _Nonnull)initWithValue:(id _Nonnull)value;
		[Export ("initWithValue:")]
		IntPtr Constructor (NSObject value);

		// -(instancetype _Nonnull)initWithData:(NSData * _Nonnull)data;
		[Export ("initWithData:")]
		IntPtr Constructor (NSData data);

		// -(id _Nonnull)objectForKeyedSubscript:(NSString * _Nonnull)key;
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		// -(BTJSON * _Nonnull)objectAtIndexedSubscript:(NSUInteger)idx;
		[Export ("objectAtIndexedSubscript:")]
		BTJSON ObjectAtIndexedSubscript (nuint idx);

		// @property (readonly, assign, nonatomic) BOOL isError;
		[Export ("isError")]
		bool IsError { get; }

		// -(NSError * _Nullable)asError;
		[NullAllowed, Export ("asError")]
		NSError ToError();

		// -(NSData * _Nullable)asJSONAndReturnError:(NSError * _Nullable * _Nullable)error;
		[Export ("asJSONAndReturnError:")]
		[return: NullAllowed]
		NSData ToJSONAndReturnError ([NullAllowed] out NSError error);

		// -(NSString * _Nullable)asPrettyJSONAndReturnError:(NSError * _Nullable * _Nullable)error;
		[Export ("asPrettyJSONAndReturnError:")]
		[return: NullAllowed]
		string ToPrettyJSONAndReturnError ([NullAllowed] out NSError error);

		// -(NSString * _Nullable)asString;
		[NullAllowed, Export ("asString")]
		string ToString();

		// -(NSArray<BTJSON *> * _Nullable)asArray;
		[NullAllowed, Export ("asArray")]
		BTJSON[] ToArray();

		// -(NSDecimalNumber * _Nullable)asNumber;
		[NullAllowed, Export ("asNumber")]
		NSDecimalNumber ToNumber();

		// -(NSURL * _Nullable)asURL;
		[NullAllowed, Export ("asURL")]
		NSUrl ToURL();

		// -(NSArray<NSString *> * _Nullable)asStringArray;
		[NullAllowed, Export ("asStringArray")]
		string[] ToStringArray();

		// -(NSDictionary * _Nullable)asDictionary;
		[NullAllowed, Export ("asDictionary")]
		NSDictionary ToDictionary();

		// -(NSInteger)asIntegerOrZero;
		[Export ("asIntegerOrZero")]
		nint ToIntegerOrZero();

		// -(NSInteger)asEnum:(NSDictionary * _Nonnull)mapping orDefault:(NSInteger)defaultValue;
		[Export ("asEnum:orDefault:")]
		nint AsEnum (NSDictionary mapping, nint defaultValue);

		// @property (readonly, assign, nonatomic) BOOL isString;
		[Export ("isString")]
		bool IsString { get; }

		// @property (readonly, assign, nonatomic) BOOL isNumber;
		[Export ("isNumber")]
		bool IsNumber { get; }

		// @property (readonly, assign, nonatomic) BOOL isArray;
		[Export ("isArray")]
		bool IsArray { get; }

		// @property (readonly, assign, nonatomic) BOOL isObject;
		[Export ("isObject")]
		bool IsObject { get; }

		// @property (readonly, assign, nonatomic) BOOL isTrue;
		[Export ("isTrue")]
		bool IsTrue { get; }

		// @property (readonly, assign, nonatomic) BOOL isFalse;
		[Export ("isFalse")]
		bool IsFalse { get; }

		// @property (readonly, assign, nonatomic) BOOL isNull;
		[Export ("isNull")]
		bool IsNull { get; }
	}

	// @interface BTConfiguration : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTConfiguration
	{
		// -(instancetype _Nonnull)initWithJSON:(BTJSON * _Nonnull)json __attribute__((objc_designated_initializer));
		[Export ("initWithJSON:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTJSON json);

		// @property (readonly, nonatomic, strong) BTJSON * _Nonnull json;
		[Export ("json", ArgumentSemantic.Strong)]
		BTJSON Json { get; }

		// +(BOOL)isBetaEnabledPaymentOption:(NSString * _Nonnull)paymentOption;
		[Static]
		[Export ("isBetaEnabledPaymentOption:")]
		bool IsBetaEnabledPaymentOption (string paymentOption);

		// +(void)setBetaPaymentOption:(NSString * _Nonnull)paymentOption isEnabled:(BOOL)isEnabled;
		[Static]
		[Export ("setBetaPaymentOption:isEnabled:")]
		void SetBetaPaymentOption (string paymentOption, bool isEnabled);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTAPIClientErrorDomain;
//		[Field ("BTAPIClientErrorDomain", "__Internal")]
//		NSString BTAPIClientErrorDomain { get; }
//	}

	// @interface BTAPIClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTAPIClient
	{
		// -(instancetype _Nullable)initWithAuthorization:(NSString * _Nonnull)authorization;
		[Export ("initWithAuthorization:")]
		IntPtr Constructor (string authorization);

		// -(instancetype _Nonnull)copyWithSource:(BTClientMetadataSourceType)source integration:(BTClientMetadataIntegrationType)integration;
		[Export ("copyWithSource:integration:")]
		BTAPIClient CopyWithSource (BTClientMetadataSourceType source, BTClientMetadataIntegrationType integration);

		// -(void)fetchOrReturnRemoteConfiguration:(void (^ _Nonnull)(BTConfiguration * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("fetchOrReturnRemoteConfiguration:")]
		void FetchOrReturnRemoteConfiguration (Action<BTConfiguration, NSError> completionBlock);

		// -(void)GET:(NSString * _Nonnull)path parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("GET:parameters:completion:")]
		void GET (string path, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)POST:(NSString * _Nonnull)path parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("POST:parameters:completion:")]
		void POST (string path, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// @property (copy, nonatomic) NSString * tokenizationKey;
		[Export ("tokenizationKey")]
		string TokenizationKey { get; set; }

		// @property (copy, nonatomic) NSString * clientJWT;
		[Export ("clientJWT")]
		string ClientJWT { get; set; }

		// @property (nonatomic, strong) BTClientToken * clientToken;
		[Export ("clientToken", ArgumentSemantic.Strong)]
		BTClientToken ClientToken { get; set; }

		// @property (nonatomic, strong) BTHTTP * http;
		[Export ("http", ArgumentSemantic.Strong)]
		BTHTTP Http { get; set; }

		// @property (readonly, nonatomic, strong) BTClientMetadata * metadata;
		[Export ("metadata", ArgumentSemantic.Strong)]
		BTClientMetadata Metadata { get; }

		// @property (nonatomic, strong) BTHTTP * analyticsHttp;
		[Export ("analyticsHttp", ArgumentSemantic.Strong)]
		BTHTTP AnalyticsHttp { get; set; }
	}

	// @interface BTAppSwitch : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAppSwitch
	{
		// @property (copy, nonatomic) NSString * _Nonnull returnURLScheme;
		[Export ("returnURLScheme")]
		string ReturnURLScheme { get; set; }

		// +(instancetype _Nonnull)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		BTAppSwitch SharedInstance ();

		// +(void)setReturnURLScheme:(NSString * _Nonnull)returnURLScheme;
		[Static]
		[Export ("setReturnURLScheme:")]
		void SetReturnURLScheme (string returnURLScheme);

		// +(BOOL)handleOpenURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nullable)sourceApplication;
		[Static]
		[Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenURL (NSUrl url, [NullAllowed] string sourceApplication);

		// +(BOOL)handleOpenURL:(NSURL * _Nonnull)url options:(NSDictionary * _Nonnull)options;
		[Static]
		[Export ("handleOpenURL:options:")]
		bool HandleOpenURL (NSUrl url, NSDictionary options);

		// -(void)registerAppSwitchHandler:(Class<BTAppSwitchHandler> _Nonnull)handler;
		[Export ("registerAppSwitchHandler:")]
		void RegisterAppSwitchHandler (IBTAppSwitchHandler handler);

		// -(void)unregisterAppSwitchHandler:(Class<BTAppSwitchHandler> _Nonnull)handler;
		[Export ("unregisterAppSwitchHandler:")]
		void UnregisterAppSwitchHandler (IBTAppSwitchHandler handler);

		// -(BOOL)handleOpenURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
		[Export ("handleOpenURL:sourceApplication:")]
		bool HandleOpenURLWithSource (NSUrl url, string sourceApplication);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTAppSwitchWillSwitchNotification;
//		[Field ("BTAppSwitchWillSwitchNotification", "__Internal")]
//		NSString BTAppSwitchWillSwitchNotification { get; }
//
//		// extern NSString *const _Nonnull BTAppSwitchDidSwitchNotification;
//		[Field ("BTAppSwitchDidSwitchNotification", "__Internal")]
//		NSString BTAppSwitchDidSwitchNotification { get; }
//
//		// extern NSString *const _Nonnull BTAppSwitchWillProcessPaymentInfoNotification;
//		[Field ("BTAppSwitchWillProcessPaymentInfoNotification", "__Internal")]
//		NSString BTAppSwitchWillProcessPaymentInfoNotification { get; }
//
//		// extern NSString *const _Nonnull BTAppSwitchNotificationTargetKey;
//		[Field ("BTAppSwitchNotificationTargetKey", "__Internal")]
//		NSString BTAppSwitchNotificationTargetKey { get; }
//	}

	// @protocol BTAppSwitchDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTAppSwitchDelegate
	{
		// @required -(void)appSwitcherWillPerformAppSwitch:(id _Nonnull)appSwitcher;
		[Abstract]
		[Export ("appSwitcherWillPerformAppSwitch:")]
		void AppSwitcherWillPerformAppSwitch (NSObject appSwitcher);

		// @required -(void)appSwitcher:(id _Nonnull)appSwitcher didPerformSwitchToTarget:(BTAppSwitchTarget)target;
		[Abstract]
		[Export ("appSwitcher:didPerformSwitchToTarget:")]
		void AppSwitcher (NSObject appSwitcher, BTAppSwitchTarget target);

		// @required -(void)appSwitcherWillProcessPaymentInfo:(id _Nonnull)appSwitcher;
		[Abstract]
		[Export ("appSwitcherWillProcessPaymentInfo:")]
		void AppSwitcherWillProcessPaymentInfo (NSObject appSwitcher);
	}

	interface IBTAppSwitchHandler
	{

	}

	// @protocol BTAppSwitchHandler
	[Protocol, Model]
	interface BTAppSwitchHandler
	{
		// @required +(BOOL)canHandleAppSwitchReturnURL:(NSURL * _Nonnull)url sourceApplication:(NSString * _Nonnull)sourceApplication;
		[Static, Abstract]
		[Export ("canHandleAppSwitchReturnURL:sourceApplication:")]
		bool CanHandleAppSwitchReturnURL (NSUrl url, string sourceApplication);

		// @required +(void)handleAppSwitchReturnURL:(NSURL * _Nonnull)url;
		[Static, Abstract]
		[Export ("handleAppSwitchReturnURL:")]
		void HandleAppSwitchReturnURL (NSUrl url);

		// @optional -(BOOL)isiOSAppAvailableForAppSwitch;
		[Export ("isiOSAppAvailableForAppSwitch")]
		bool IsiOSAppAvailableForAppSwitch { get; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTClientTokenKeyVersion;
//		[Field ("BTClientTokenKeyVersion", "__Internal")]
//		NSString BTClientTokenKeyVersion { get; }
//
//		// extern NSString *const _Nonnull BTClientTokenErrorDomain;
//		[Field ("BTClientTokenErrorDomain", "__Internal")]
//		NSString BTClientTokenErrorDomain { get; }
//
//		// extern NSString *const _Nonnull BTClientTokenKeyAuthorizationFingerprint;
//		[Field ("BTClientTokenKeyAuthorizationFingerprint", "__Internal")]
//		NSString BTClientTokenKeyAuthorizationFingerprint { get; }
//
//		// extern NSString *const _Nonnull BTClientTokenKeyConfigURL;
//		[Field ("BTClientTokenKeyConfigURL", "__Internal")]
//		NSString BTClientTokenKeyConfigURL { get; }
//	}

	// @interface BTClientToken : NSObject <NSCoding, NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTClientToken : INSCoding, INSCopying
	{
		// @property (readonly, nonatomic, strong) BTJSON * _Nonnull json;
		[Export ("json", ArgumentSemantic.Strong)]
		BTJSON Json { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull authorizationFingerprint;
		[Export ("authorizationFingerprint")]
		string AuthorizationFingerprint { get; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull configURL;
		[Export ("configURL", ArgumentSemantic.Strong)]
		NSUrl ConfigURL { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull originalValue;
		[Export ("originalValue")]
		string OriginalValue { get; }

		// -(instancetype _Nullable)initWithClientToken:(NSString * _Nonnull)clientToken error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithClientToken:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (string clientToken, [NullAllowed] out NSError error);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTCustomerInputBraintreeValidationErrorsKey;
//		[Field ("BTCustomerInputBraintreeValidationErrorsKey", "__Internal")]
//		NSString BTCustomerInputBraintreeValidationErrorsKey { get; }
//
//		// extern NSString *const BTHTTPErrorDomain;
//		[Field ("BTHTTPErrorDomain", "__Internal")]
//		NSString BTHTTPErrorDomain { get; }
//
//		// extern NSString *const BTHTTPURLResponseKey;
//		[Field ("BTHTTPURLResponseKey", "__Internal")]
//		NSString BTHTTPURLResponseKey { get; }
//
//		// extern NSString *const BTHTTPJSONResponseBodyKey;
//		[Field ("BTHTTPJSONResponseBodyKey", "__Internal")]
//		NSString BTHTTPJSONResponseBodyKey { get; }
//	}

	// @interface BTLogger : NSObject
	[BaseType (typeof(NSObject))]
	interface BTLogger
	{
		// +(instancetype)sharedLogger;
		[Static]
		[Export ("sharedLogger")]
		BTLogger SharedLogger ();

		// @property (assign, nonatomic) BTLogLevel level;
		[Export ("level", ArgumentSemantic.Assign)]
		BTLogLevel Level { get; set; }

		// @property (copy, nonatomic) void (^logBlock)(BTLogLevel, NSString *);
		[Export ("logBlock", ArgumentSemantic.Copy)]
		Action<BTLogLevel, NSString> LogBlock { get; set; }
	}

	// @interface BTPostalAddress : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface BTPostalAddress : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable recipientName;
		[NullAllowed, Export ("recipientName")]
		string RecipientName { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull streetAddress;
		[Export ("streetAddress")]
		string StreetAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable extendedAddress;
		[NullAllowed, Export ("extendedAddress")]
		string ExtendedAddress { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull locality;
		[Export ("locality")]
		string Locality { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull countryCodeAlpha2;
		[Export ("countryCodeAlpha2")]
		string CountryCodeAlpha2 { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable region;
		[NullAllowed, Export ("region")]
		string Region { get; set; }
	}

	// @interface BTPaymentMethodNonce : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethodNonce
	{
		// -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nullable)description type:(NSString * _Nonnull)type;
		[Export ("initWithNonce:localizedDescription:type:")]
		IntPtr Constructor (string nonce, [NullAllowed] string description, string type);

		// -(instancetype _Nullable)initWithNonce:(NSString * _Nonnull)nonce localizedDescription:(NSString * _Nullable)description;
		[Export ("initWithNonce:localizedDescription:")]
		IntPtr Constructor (string nonce, [NullAllowed] string description);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull nonce;
		[Export ("nonce")]
		string Nonce { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull localizedDescription;
		[Export ("localizedDescription")]
		string LocalizedDescription { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull type;
		[Export ("type")]
		string Type { get; }
	}

	// @interface BTPaymentMethodNonceParser : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPaymentMethodNonceParser
	{
		// +(instancetype _Nonnull)sharedParser;
		[Static]
		[Export ("sharedParser")]
		BTPaymentMethodNonceParser SharedParser ();

		// @property (readonly, nonatomic, strong) NSArray<NSString *> * _Nonnull allTypes;
		[Export ("allTypes", ArgumentSemantic.Strong)]
		string[] AllTypes { get; }

		// -(BOOL)isTypeAvailable:(NSString * _Nonnull)type;
		[Export ("isTypeAvailable:")]
		bool IsTypeAvailable (string type);

		// -(void)registerType:(NSString * _Nonnull)type withParsingBlock:(BTPaymentMethodNonce * _Nullable (^ _Nonnull)(BTJSON * _Nonnull))jsonParsingBlock;
		[Export ("registerType:withParsingBlock:")]
		void RegisterType (string type, Func<BTJSON, BTPaymentMethodNonce> jsonParsingBlock);

		// -(BTPaymentMethodNonce * _Nullable)parseJSON:(BTJSON * _Nonnull)json withParsingBlockForType:(NSString * _Nonnull)type;
		[Export ("parseJSON:withParsingBlockForType:")]
		[return: NullAllowed]
		BTPaymentMethodNonce ParseJSON (BTJSON json, string type);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTTokenizationServiceErrorDomain;
//		[Field ("BTTokenizationServiceErrorDomain", "__Internal")]
//		NSString BTTokenizationServiceErrorDomain { get; }
//
//		// extern NSString *const _Nonnull BTTokenizationServiceViewPresentingDelegateOption;
//		[Field ("BTTokenizationServiceViewPresentingDelegateOption", "__Internal")]
//		NSString BTTokenizationServiceViewPresentingDelegateOption { get; }
//
//		// extern NSString *const _Nonnull BTTokenizationServicePayPalScopesOption;
//		[Field ("BTTokenizationServicePayPalScopesOption", "__Internal")]
//		NSString BTTokenizationServicePayPalScopesOption { get; }
//	}

	delegate void OnRegisterTypeErrorDelegate (BTPaymentMethodNonce nonce, NSError error);

	// @interface BTTokenizationService : NSObject
	[BaseType (typeof(NSObject))]
	interface BTTokenizationService
	{
		// +(instancetype _Nonnull)sharedService;
		[Static]
		[Export ("sharedService")]
		BTTokenizationService SharedService ();

		// -(void)registerType:(NSString * _Nonnull)type withTokenizationBlock:(void (^ _Nonnull)(BTAPIClient * _Nonnull, NSDictionary * _Nullable, void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable)))tokenizationBlock;
		[Export ("registerType:withTokenizationBlock:")]
		void RegisterType (string type, Action<BTAPIClient, NSDictionary, OnRegisterTypeErrorDelegate> tokenizationBlock);

		// -(BOOL)isTypeAvailable:(NSString * _Nonnull)type;
		[Export ("isTypeAvailable:")]
		bool IsTypeAvailable (string type);

		// -(void)tokenizeType:(NSString * _Nonnull)type withAPIClient:(BTAPIClient * _Nonnull)apiClient completion:(void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeType:withAPIClient:completion:")]
		void TokenizeType (string type, BTAPIClient apiClient, Action<BTPaymentMethodNonce, NSError> completion);

		// -(void)tokenizeType:(NSString * _Nonnull)type options:(NSDictionary<NSString *,id> * _Nullable)options withAPIClient:(BTAPIClient * _Nonnull)apiClient completion:(void (^ _Nonnull)(BTPaymentMethodNonce * _Nullable, NSError * _Nullable))completion;
		[Export ("tokenizeType:options:withAPIClient:completion:")]
		void TokenizeType (string type, [NullAllowed] NSDictionary<NSString, NSObject> options, BTAPIClient apiClient, Action<BTPaymentMethodNonce, NSError> completion);

		// @property (readonly, nonatomic, strong) NSArray * _Nonnull allTypes;
		[Export ("allTypes", ArgumentSemantic.Strong)]
		NSObject[] AllTypes { get; }
	}

	// @protocol BTViewControllerPresentingDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTViewControllerPresentingDelegate
	{
		// @required -(void)paymentDriver:(id _Nonnull)driver requestsPresentationOfViewController:(UIViewController * _Nonnull)viewController;
		[Abstract]
		[Export ("paymentDriver:requestsPresentationOfViewController:")]
		void RequestsPresentationOfViewController (NSObject driver, UIViewController viewController);

		// @required -(void)paymentDriver:(id _Nonnull)driver requestsDismissalOfViewController:(UIViewController * _Nonnull)viewController;
		[Abstract]
		[Export ("paymentDriver:requestsDismissalOfViewController:")]
		void RequestsDismissalOfViewController (NSObject driver, UIViewController viewController);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double BraintreeCardVersionNumber;
//		[Field ("BraintreeCardVersionNumber", "__Internal")]
//		double BraintreeCardVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreeCardVersionString;
//		[Field ("BraintreeCardVersionString", "__Internal")]
//		byte[] BraintreeCardVersionString { get; }
//	}

	// @interface BTCard : NSObject
	[BaseType (typeof(NSObject))]
	interface BTCard
	{
		// -(instancetype _Nonnull)initWithNumber:(NSString * _Nonnull)number expirationMonth:(NSString * _Nonnull)expirationMonth expirationYear:(NSString * _Nonnull)expirationYear cvv:(NSString * _Nullable)cvv;
		[Export ("initWithNumber:expirationMonth:expirationYear:cvv:")]
		IntPtr Constructor (string number, string expirationMonth, string expirationYear, [NullAllowed] string cvv);

		// -(instancetype _Nonnull)initWithParameters:(NSDictionary * _Nonnull)parameters __attribute__((objc_designated_initializer));
		[Export ("initWithParameters:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSDictionary parameters);

		// @property (copy, nonatomic) NSString * _Nullable number;
		[NullAllowed, Export ("number")]
		string Number { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationMonth;
		[NullAllowed, Export ("expirationMonth")]
		string ExpirationMonth { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable expirationYear;
		[NullAllowed, Export ("expirationYear")]
		string ExpirationYear { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable cvv;
		[NullAllowed, Export ("cvv")]
		string Cvv { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable postalCode;
		[NullAllowed, Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (assign, nonatomic) BOOL shouldValidate;
		[Export ("shouldValidate")]
		bool ShouldValidate { get; set; }
	}

	// @interface BTCardNonce : BTPaymentMethodNonce
	[BaseType (typeof(BTPaymentMethodNonce))]
	interface BTCardNonce
	{
		// @property (readonly, assign, nonatomic) BTCardNetwork cardNetwork;
		[Export ("cardNetwork", ArgumentSemantic.Assign)]
		BTCardNetwork CardNetwork { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable lastTwo;
		[NullAllowed, Export ("lastTwo")]
		string LastTwo { get; }

		// +(instancetype _Nonnull)cardNonceWithJSON:(BTJSON * _Nonnull)cardJSON;
		[Static]
		[Export ("cardNonceWithJSON:")]
		BTCardNonce CardNonceWithJSON (BTJSON cardJSON);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTCardClientErrorDomain;
//		[Field ("BTCardClientErrorDomain", "__Internal")]
//		NSString BTCardClientErrorDomain { get; }
//	}

	// @interface BTCardClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTCardClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTAPIClient apiClient);

		// -(void)tokenizeCard:(BTCard * _Nonnull)card completion:(void (^ _Nonnull)(BTCardNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("tokenizeCard:completion:")]
		void TokenizeCard (BTCard card, Action<BTCardNonce, NSError> completionBlock);

		// @property (readwrite, nonatomic, strong) BTAPIClient * apiClient;
		[Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }
	}

	// @interface BTThreeDSecureCardNonce : BTCardNonce
	[BaseType (typeof(BTCardNonce))]
	interface BTThreeDSecureCardNonce
	{
		// @property (readonly, assign, nonatomic) BOOL liabilityShifted;
		[Export ("liabilityShifted")]
		bool LiabilityShifted { get; }

		// @property (readonly, assign, nonatomic) BOOL liabilityShiftPossible;
		[Export ("liabilityShiftPossible")]
		bool LiabilityShiftPossible { get; }

		// -(instancetype _Nonnull)initWithNonce:(NSString * _Nonnull)nonce description:(NSString * _Nullable)description cardNetwork:(BTCardNetwork)cardNetwork lastTwo:(NSString * _Nullable)lastTwo threeDSecureJSON:(BTJSON * _Nonnull)threeDSecureJSON;
		[Export ("initWithNonce:description:cardNetwork:lastTwo:threeDSecureJSON:")]
		IntPtr Constructor (string nonce, [NullAllowed] string description, BTCardNetwork cardNetwork, [NullAllowed] string lastTwo, BTJSON threeDSecureJSON);
	}

	// @interface BTThreeDSecureDriver : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTThreeDSecureDriver
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient delegate:(id<BTViewControllerPresentingDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:delegate:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTAPIClient apiClient, BTViewControllerPresentingDelegate @delegate);

		// -(void)verifyCardWithNonce:(NSString * _Nonnull)nonce amount:(NSDecimalNumber * _Nonnull)amount completion:(void (^ _Nonnull)(BTThreeDSecureCardNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("verifyCardWithNonce:amount:completion:")]
		void VerifyCardWithNonce (string nonce, NSDecimalNumber amount, Action<BTThreeDSecureCardNonce, NSError> completionBlock);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BTViewControllerPresentingDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTViewControllerPresentingDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) BTAPIClient * apiClient;
		[Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureCardNonce * upgradedTokenizedCard;
		[Export ("upgradedTokenizedCard", ArgumentSemantic.Strong)]
		BTThreeDSecureCardNonce UpgradedTokenizedCard { get; set; }

		// @property (copy, nonatomic) void (^completionBlockAfterAuthenticating)(BTThreeDSecureCardNonce *, NSError *);
		[Export ("completionBlockAfterAuthenticating", ArgumentSemantic.Copy)]
		Action<BTThreeDSecureCardNonce, NSError> CompletionBlockAfterAuthenticating { get; set; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const BTThreeDSecureErrorDomain;
//		[Field ("BTThreeDSecureErrorDomain", "__Internal")]
//		NSString BTThreeDSecureErrorDomain { get; }
//
//		// extern NSString *const BTThreeDSecureInfoKey;
//		[Field ("BTThreeDSecureInfoKey", "__Internal")]
//		NSString BTThreeDSecureInfoKey { get; }
//
//		// extern NSString *const BTThreeDSecureValidationErrorsKey;
//		[Field ("BTThreeDSecureValidationErrorsKey", "__Internal")]
//		NSString BTThreeDSecureValidationErrorsKey { get; }
//	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double BraintreeApplePayVersionNumber;
//		[Field ("BraintreeApplePayVersionNumber", "__Internal")]
//		double BraintreeApplePayVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreeApplePayVersionString;
//		[Field ("BraintreeApplePayVersionString", "__Internal")]
//		byte[] BraintreeApplePayVersionString { get; }
//	}

	// @interface BTApplePayCardNonce : BTPaymentMethodNonce
	[BaseType (typeof(BTPaymentMethodNonce))]
	interface BTApplePayCardNonce
	{
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTApplePayErrorDomain;
//		[Field ("BTApplePayErrorDomain", "__Internal")]
//		NSString BTApplePayErrorDomain { get; }
//	}

	// @interface BTApplePayClient : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTApplePayClient
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient __attribute__((objc_designated_initializer));
		[Export ("initWithAPIClient:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTAPIClient apiClient);

		// -(void)tokenizeApplePayPayment:(PKPayment * _Nonnull)payment completion:(void (^ _Nonnull)(BTApplePayCardNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("tokenizeApplePayPayment:completion:")]
		void TokenizeApplePayPayment (PKPayment payment, Action<BTApplePayCardNonce, NSError> completionBlock);

		// @property (nonatomic, strong) BTAPIClient * apiClient;
		[Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }
	}

	// @interface ApplePay (BTConfiguration)
	[Category]
	[BaseType (typeof(BTConfiguration))]
	interface BTConfiguration_ApplePay
	{
		// @property (readonly, assign, nonatomic) BOOL isApplePayEnabled;
		[Export ("isApplePayEnabled")]
		bool IsApplePayEnabled();
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double BraintreeDataCollectorVersionNumber;
//		[Field ("BraintreeDataCollectorVersionNumber", "__Internal")]
//		double BraintreeDataCollectorVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreeDataCollectorVersionString;
//		[Field ("BraintreeDataCollectorVersionString", "__Internal")]
//		byte[] BraintreeDataCollectorVersionString { get; }
//	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTDataCollectorKountErrorDomain;
//		[Field ("BTDataCollectorKountErrorDomain", "__Internal")]
//		NSString BTDataCollectorKountErrorDomain { get; }
//	}

	// @interface BTDataCollector : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDataCollector
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BTDataCollectorDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTDataCollectorDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(instancetype _Nonnull)initWithEnvironment:(BTDataCollectorEnvironment)environment;
		[Export ("initWithEnvironment:")]
		IntPtr Constructor (BTDataCollectorEnvironment environment);

		// +(NSString * _Nullable)payPalClientMetadataId;
		[Static]
		[NullAllowed, Export ("payPalClientMetadataId")]
		string PayPalClientMetadataId { get; }

		// -(NSString * _Nonnull)collectCardFraudData;
		[Export ("collectCardFraudData")]
		string CollectCardFraudData();

		// -(NSString * _Nonnull)collectPayPalClientMetadataId;
		[Export ("collectPayPalClientMetadataId")]
		string CollectPayPalClientMetadataId();

		// -(NSString * _Nonnull)collectFraudData;
		[Export ("collectFraudData")]
		string CollectFraudData();

		// -(void)setFraudMerchantId:(NSString * _Nonnull)fraudMerchantId;
		[Export ("setFraudMerchantId:")]
		void SetFraudMerchantId (string fraudMerchantId);

		// -(void)setCollectorUrl:(NSString * _Nonnull)url;
		[Export ("setCollectorUrl:")]
		void SetCollectorUrl (string url);
	}

	// @protocol BTDataCollectorDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTDataCollectorDelegate
	{
		// @required -(void)dataCollectorDidComplete:(BTDataCollector * _Nonnull)dataCollector;
		[Abstract]
		[Export ("dataCollectorDidComplete:")]
		void DataCollectorDidComplete (BTDataCollector dataCollector);

		// @optional -(void)dataCollectorDidStart:(BTDataCollector * _Nonnull)dataCollector;
		[Export ("dataCollectorDidStart:")]
		void DataCollectorDidStart (BTDataCollector dataCollector);

		// @optional -(void)dataCollector:(BTDataCollector * _Nonnull)dataCollector didFailWithError:(NSError * _Nonnull)error;
		[Export ("dataCollector:didFailWithError:")]
		void DataCollector (BTDataCollector dataCollector, NSError error);
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double BraintreePayPalVersionNumber;
//		[Field ("BraintreePayPalVersionNumber", "__Internal")]
//		double BraintreePayPalVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreePayPalVersionString;
//		[Field ("BraintreePayPalVersionString", "__Internal")]
//		byte[] BraintreePayPalVersionString { get; }
//	}

	// @interface PayPal (BTConfiguration)
	[Category]
	[BaseType (typeof(BTConfiguration))]
	interface BTConfiguration_PayPal
	{
		// @property (readonly, assign, nonatomic) BOOL isPayPalEnabled;
		[Export ("isPayPalEnabled")]
		bool IsPayPalEnabled();

		// @property (readonly, assign, nonatomic) BOOL isBillingAgreementsEnabled;
		[Export ("isBillingAgreementsEnabled")]
		bool IsBillingAgreementsEnabled();
	}

	// @interface BTPayPalRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPayPalRequest
	{
		// -(instancetype _Nonnull)initWithAmount:(NSString * _Nonnull)amount;
		[Export ("initWithAmount:")]
		IntPtr Constructor (string amount);

		// @property (readonly, nonatomic, strong) NSString * _Nonnull amount;
		[Export ("amount", ArgumentSemantic.Strong)]
		string Amount { get; }

		// @property (getter = isShippingAddressRequired, nonatomic) BOOL shippingAddressRequired;
		[Export ("shippingAddressRequired")]
		bool ShippingAddressRequired { [Bind ("isShippingAddressRequired")] get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyCode;
		[NullAllowed, Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable localeCode;
		[NullAllowed, Export ("localeCode")]
		string LocaleCode { get; set; }

		// @property (nonatomic, strong) BTPostalAddress * _Nullable shippingAddressOverride;
		[NullAllowed, Export ("shippingAddressOverride", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddressOverride { get; set; }
	}

	// @interface BTPayPalAccountNonce : BTPaymentMethodNonce
	[BaseType (typeof(BTPaymentMethodNonce))]
	interface BTPayPalAccountNonce
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable email;
		[NullAllowed, Export ("email")]
		string Email { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable firstName;
		[NullAllowed, Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable lastName;
		[NullAllowed, Export ("lastName")]
		string LastName { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable phone;
		[NullAllowed, Export ("phone")]
		string Phone { get; }

		// @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable billingAddress;
		[NullAllowed, Export ("billingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress BillingAddress { get; }

		// @property (readonly, nonatomic, strong) BTPostalAddress * _Nullable shippingAddress;
		[NullAllowed, Export ("shippingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddress { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable clientMetadataId;
		[NullAllowed, Export ("clientMetadataId")]
		string ClientMetadataId { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nullable payerId;
		[NullAllowed, Export ("payerId")]
		string PayerId { get; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const _Nonnull BTPayPalDriverErrorDomain;
//		[Field ("BTPayPalDriverErrorDomain", "__Internal")]
//		NSString BTPayPalDriverErrorDomain { get; }
//	}

	// @interface BTPayPalDriver : NSObject <BTAppSwitchHandler>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTPayPalDriver : BTAppSwitchHandler
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient;
		[Export ("initWithAPIClient:")]
		IntPtr Constructor (BTAPIClient apiClient);

		// -(void)authorizeAccountWithCompletion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("authorizeAccountWithCompletion:")]
		void AuthorizeAccountWithCompletion (Action<BTPayPalAccountNonce, NSError> completionBlock);

		// -(void)authorizeAccountWithAdditionalScopes:(NSSet<NSString *> * _Nonnull)additionalScopes completion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("authorizeAccountWithAdditionalScopes:completion:")]
		void AuthorizeAccountWithAdditionalScopes (NSSet<NSString> additionalScopes, Action<BTPayPalAccountNonce, NSError> completionBlock);

		// -(void)requestOneTimePayment:(BTPayPalRequest * _Nonnull)request completion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("requestOneTimePayment:completion:")]
		void RequestOneTimePayment (BTPayPalRequest request, Action<BTPayPalAccountNonce, NSError> completionBlock);

		// -(void)requestBillingAgreement:(BTPayPalRequest * _Nonnull)request completion:(void (^ _Nonnull)(BTPayPalAccountNonce * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("requestBillingAgreement:completion:")]
		void RequestBillingAgreement (BTPayPalRequest request, Action<BTPayPalAccountNonce, NSError> completionBlock);

		[Wrap ("WeakAppSwitchDelegate")]
		[NullAllowed]
		BTAppSwitchDelegate AppSwitchDelegate { get; set; }

		// @property (nonatomic, weak) id<BTAppSwitchDelegate> _Nullable appSwitchDelegate;
		[NullAllowed, Export ("appSwitchDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAppSwitchDelegate { get; set; }

		[Wrap ("WeakViewControllerPresentingDelegate")]
		[NullAllowed]
		BTViewControllerPresentingDelegate ViewControllerPresentingDelegate { get; set; }

		// @property (nonatomic, weak) id<BTViewControllerPresentingDelegate> _Nullable viewControllerPresentingDelegate;
		[NullAllowed, Export ("viewControllerPresentingDelegate", ArgumentSemantic.Weak)]
		NSObject WeakViewControllerPresentingDelegate { get; set; }

		// @property (nonatomic, strong) BTPayPalRequestFactory * _Nonnull requestFactory;
		[Export ("requestFactory", ArgumentSemantic.Strong)]
		BTPayPalRequestFactory RequestFactory { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull returnURLScheme;
		[Export ("returnURLScheme")]
		string ReturnURLScheme { get; set; }

		// @property (nonatomic, strong) BTAPIClient * _Nullable apiClient;
		[NullAllowed, Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull clientMetadataId;
		[Export ("clientMetadataId", ArgumentSemantic.Strong)]
		string ClientMetadataId { get; set; }

		// @property (nonatomic, strong) SFSafariViewController * _Nullable safariViewController;
		[NullAllowed, Export ("safariViewController", ArgumentSemantic.Strong)]
		SFSafariViewController SafariViewController { get; set; }
	}

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern double BraintreeUIVersionNumber;
//		[Field ("BraintreeUIVersionNumber", "__Internal")]
//		double BraintreeUIVersionNumber { get; }
//
//		// extern const unsigned char [] BraintreeUIVersionString;
//		[Field ("BraintreeUIVersionString", "__Internal")]
//		byte[] BraintreeUIVersionString { get; }
//	}

	// @interface BTDropInViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface BTDropInViewController
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient;
		[Export ("initWithAPIClient:")]
		IntPtr Constructor (BTAPIClient apiClient);

		// @property (nonatomic, strong) BTPaymentRequest * _Nullable paymentRequest;
		[NullAllowed, Export ("paymentRequest", ArgumentSemantic.Strong)]
		BTPaymentRequest PaymentRequest { get; set; }

		// @property (nonatomic, strong) NSArray * _Nonnull paymentMethodNonces;
		[Export ("paymentMethodNonces", ArgumentSemantic.Strong)]
		BTPaymentMethodNonce[] PaymentMethodNonces { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BTDropInViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTDropInViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (nonatomic, strong) BTUI * _Nullable theme;
		[NullAllowed, Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }

		// -(void)fetchPaymentMethodsOnCompletion:(void (^ _Nonnull)())completionBlock;
		[Export ("fetchPaymentMethodsOnCompletion:")]
		void FetchPaymentMethodsOnCompletion (Action completionBlock);

		// @property (nonatomic, strong) BTAPIClient * _Nonnull apiClient;
		[Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }

		// @property (nonatomic, strong) BTDropInContentView * dropInContentView;
		[Export ("dropInContentView", ArgumentSemantic.Strong)]
		BTDropInContentView DropInContentView { get; set; }
	}

	// @protocol BTDropInViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTDropInViewControllerDelegate
	{
		// @required -(void)dropInViewController:(BTDropInViewController * _Nonnull)viewController didSucceedWithTokenization:(BTPaymentMethodNonce * _Nonnull)paymentMethodNonce;
		[Abstract]
		[Export ("dropInViewController:didSucceedWithTokenization:")]
		void DropInViewController (BTDropInViewController viewController, BTPaymentMethodNonce paymentMethodNonce);

		// @required -(void)dropInViewControllerDidCancel:(BTDropInViewController * _Nonnull)viewController;
		[Abstract]
		[Export ("dropInViewControllerDidCancel:")]
		void DropInViewControllerDidCancel (BTDropInViewController viewController);

		// @optional -(void)dropInViewControllerDidLoad:(BTDropInViewController * _Nonnull)viewController;
		[Export ("dropInViewControllerDidLoad:")]
		void DropInViewControllerDidLoad (BTDropInViewController viewController);

		// @optional -(void)dropInViewControllerWillComplete:(BTDropInViewController * _Nonnull)viewController;
		[Export ("dropInViewControllerWillComplete:")]
		void DropInViewControllerWillComplete (BTDropInViewController viewController);
	}

	// @interface BTPaymentRequest : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface BTPaymentRequest : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable summaryTitle;
		[NullAllowed, Export ("summaryTitle")]
		string SummaryTitle { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable summaryDescription;
		[NullAllowed, Export ("summaryDescription")]
		string SummaryDescription { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull displayAmount;
		[Export ("displayAmount")]
		string DisplayAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull callToActionText;
		[Export ("callToActionText")]
		string CallToActionText { get; set; }

		// @property (assign, nonatomic) BOOL shouldHideCallToAction;
		[Export ("shouldHideCallToAction")]
		bool ShouldHideCallToAction { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable amount;
		[NullAllowed, Export ("amount")]
		string Amount { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable currencyCode;
		[NullAllowed, Export ("currencyCode")]
		string CurrencyCode { get; set; }

		// @property (assign, nonatomic) BOOL noShipping;
		[Export ("noShipping")]
		bool NoShipping { get; set; }

		// @property (nonatomic, strong) BTPostalAddress * _Nullable shippingAddress;
		[NullAllowed, Export ("shippingAddress", ArgumentSemantic.Strong)]
		BTPostalAddress ShippingAddress { get; set; }

		// @property (nonatomic, strong) NSSet<NSString *> * _Nullable additionalPayPalScopes;
		[NullAllowed, Export ("additionalPayPalScopes", ArgumentSemantic.Strong)]
		NSSet<NSString> AdditionalPayPalScopes { get; set; }
	}

	// @interface BTUIVectorArtView : UIView
	[BaseType (typeof(UIView))]
	interface BTUIVectorArtView
	{
		// -(void)drawArt;
		[Export ("drawArt")]
		void DrawArt ();

		// @property (assign, nonatomic) CGSize artDimensions;
		[Export ("artDimensions", ArgumentSemantic.Assign)]
		CGSize ArtDimensions { get; set; }

		// -(UIImage *)imageOfSize:(CGSize)size;
		[Export ("imageOfSize:")]
		UIImage ImageOfSize (CGSize size);
	}

	// @interface BTUI : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUI
	{
		// +(BTUI *)braintreeTheme;
		[Static]
		[Export ("braintreeTheme")]
		BTUI BraintreeTheme { get; }

		// -(UIColor *)idealGray;
		[Export ("idealGray")]
		UIColor IdealGray { get; }

		// -(UIColor *)defaultTintColor;
		[Export ("defaultTintColor")]
		UIColor DefaultTintColor { get; }

		// -(UIColor *)viewBackgroundColor;
		[Export ("viewBackgroundColor")]
		UIColor ViewBackgroundColor { get; }

		// -(UIColor *)callToActionColor;
		[Export ("callToActionColor")]
		UIColor CallToActionColor { get; }

		// -(UIColor *)callToActionColorHighlighted;
		[Export ("callToActionColorHighlighted")]
		UIColor CallToActionColorHighlighted { get; }

		// -(UIColor *)disabledButtonColor;
		[Export ("disabledButtonColor")]
		UIColor DisabledButtonColor { get; }

		// -(UIColor *)titleColor;
		[Export ("titleColor")]
		UIColor TitleColor { get; }

		// -(UIColor *)detailColor;
		[Export ("detailColor")]
		UIColor DetailColor { get; }

		// -(UIColor *)borderColor;
		[Export ("borderColor")]
		UIColor BorderColor { get; }

		// -(UIColor *)textFieldTextColor;
		[Export ("textFieldTextColor")]
		UIColor TextFieldTextColor { get; }

		// -(UIColor *)textFieldPlaceholderColor;
		[Export ("textFieldPlaceholderColor")]
		UIColor TextFieldPlaceholderColor { get; }

		// -(UIColor *)sectionHeaderTextColor;
		[Export ("sectionHeaderTextColor")]
		UIColor SectionHeaderTextColor { get; }

		// -(UIColor *)textFieldFloatLabelTextColor;
		[Export ("textFieldFloatLabelTextColor")]
		UIColor TextFieldFloatLabelTextColor { get; }

		// -(UIColor *)cardHintBorderColor;
		[Export ("cardHintBorderColor")]
		UIColor CardHintBorderColor { get; }

		// -(UIColor *)errorBackgroundColor;
		[Export ("errorBackgroundColor")]
		UIColor ErrorBackgroundColor { get; }

		// -(UIColor *)errorForegroundColor;
		[Export ("errorForegroundColor")]
		UIColor ErrorForegroundColor { get; }

		// -(CGFloat)highlightedBrightnessAdjustment;
		[Export ("highlightedBrightnessAdjustment")]
		nfloat HighlightedBrightnessAdjustment { get; }

		// -(UIColor *)payBlue;
		[Export ("payBlue")]
		UIColor PayBlue { get; }

		// -(UIColor *)palBlue;
		[Export ("palBlue")]
		UIColor PalBlue { get; }

		// -(UIColor *)payPalButtonBlue;
		[Export ("payPalButtonBlue")]
		UIColor PayPalButtonBlue { get; }

		// -(UIColor *)payPalButtonActiveBlue;
		[Export ("payPalButtonActiveBlue")]
		UIColor PayPalButtonActiveBlue { get; }

		// -(UIColor *)venmoPrimaryBlue;
		[Export ("venmoPrimaryBlue")]
		UIColor VenmoPrimaryBlue { get; }

		// -(UIColor *)coinbasePrimaryBlue;
		[Export ("coinbasePrimaryBlue")]
		UIColor CoinbasePrimaryBlue { get; }

		// -(UIFont *)controlFont;
		[Export ("controlFont")]
		UIFont ControlFont { get; }

		// -(UIFont *)controlTitleFont;
		[Export ("controlTitleFont")]
		UIFont ControlTitleFont { get; }

		// -(UIFont *)controlDetailFont;
		[Export ("controlDetailFont")]
		UIFont ControlDetailFont { get; }

		// -(UIFont *)textFieldFont;
		[Export ("textFieldFont")]
		UIFont TextFieldFont { get; }

		// -(UIFont *)textFieldFloatLabelFont;
		[Export ("textFieldFloatLabelFont")]
		UIFont TextFieldFloatLabelFont { get; }

		// -(UIFont *)sectionHeaderFont;
		[Export ("sectionHeaderFont")]
		UIFont SectionHeaderFont { get; }

		// -(NSDictionary *)textFieldTextAttributes;
		[Export ("textFieldTextAttributes")]
		NSDictionary TextFieldTextAttributes { get; }

		// -(NSDictionary *)textFieldPlaceholderAttributes;
		[Export ("textFieldPlaceholderAttributes")]
		NSDictionary TextFieldPlaceholderAttributes { get; }

		// -(CGFloat)borderWidth;
		[Export ("borderWidth")]
		nfloat BorderWidth { get; }

		// -(CGFloat)cornerRadius;
		[Export ("cornerRadius")]
		nfloat CornerRadius { get; }

		// -(CGFloat)formattedEntryKerning;
		[Export ("formattedEntryKerning")]
		nfloat FormattedEntryKerning { get; }

		// -(CGFloat)horizontalMargin;
		[Export ("horizontalMargin")]
		nfloat HorizontalMargin { get; }

		// -(CGFloat)paymentButtonMinHeight;
		[Export ("paymentButtonMinHeight")]
		nfloat PaymentButtonMinHeight { get; }

		// -(CGFloat)paymentButtonMaxHeight;
		[Export ("paymentButtonMaxHeight")]
		nfloat PaymentButtonMaxHeight { get; }

		// -(CGFloat)paymentButtonWordMarkHeight __attribute__((deprecated("")));
		[Export ("paymentButtonWordMarkHeight")]
		nfloat PaymentButtonWordMarkHeight { get; }

		// -(CGFloat)quickTransitionDuration;
		[Export ("quickTransitionDuration")]
		nfloat QuickTransitionDuration { get; }

		// -(CGFloat)transitionDuration;
		[Export ("transitionDuration")]
		nfloat TransitionDuration { get; }

		// -(CGFloat)minimumVisibilityTime;
		[Export ("minimumVisibilityTime")]
		nfloat MinimumVisibilityTime { get; }

		// -(BTUIVectorArtView *)vectorArtViewForPaymentInfoType:(NSString *)typeString;
		[Export ("vectorArtViewForPaymentInfoType:")]
		BTUIVectorArtView VectorArtViewForPaymentInfoType (string typeString);

		// -(BTUIVectorArtView *)vectorArtViewForPaymentOptionType:(BTUIPaymentOptionType)type;
		[Export ("vectorArtViewForPaymentOptionType:")]
		BTUIVectorArtView VectorArtViewForPaymentOptionType (BTUIPaymentOptionType type);

		// +(BTUIPaymentOptionType)paymentOptionTypeForPaymentInfoType:(NSString *)typeString;
		[Static]
		[Export ("paymentOptionTypeForPaymentInfoType:")]
		BTUIPaymentOptionType PaymentOptionTypeForPaymentInfoType (string typeString);

		// +(UIActivityIndicatorViewStyle)activityIndicatorViewStyleForBarTintColor:(UIColor *)color;
		[Static]
		[Export ("activityIndicatorViewStyleForBarTintColor:")]
		UIActivityIndicatorViewStyle ActivityIndicatorViewStyleForBarTintColor (UIColor color);
	}

	// @interface BTUIThemedView : UIView
	[BaseType (typeof(UIView))]
	interface BTUIThemedView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTPaymentButton : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTPaymentButton
	{
		// -(instancetype _Nonnull)initWithAPIClient:(BTAPIClient * _Nonnull)apiClient completion:(void (^ _Nonnull)(BTPaymentMethodNonce * _Nonnull, NSError * _Nonnull))completion;
		[Export ("initWithAPIClient:completion:")]
		IntPtr Constructor (BTAPIClient apiClient, Action<BTPaymentMethodNonce, NSError> completion);

		// @property (nonatomic, strong) BTAPIClient * _Nonnull apiClient;
		[Export ("apiClient", ArgumentSemantic.Strong)]
		BTAPIClient ApiClient { get; set; }

		// @property (nonatomic, strong) BTPaymentRequest * _Nonnull paymentRequest;
		[Export ("paymentRequest", ArgumentSemantic.Strong)]
		BTPaymentRequest PaymentRequest { get; set; }

		// @property (copy, nonatomic) void (^ _Nonnull)(BTPaymentMethodNonce * _Nonnull, NSError * _Nonnull) completion;
		[Export ("completion", ArgumentSemantic.Copy)]
		Action<BTPaymentMethodNonce, NSError> Completion { get; set; }

		// @property (nonatomic, strong) NSOrderedSet * _Nonnull enabledPaymentOptions;
		[Export ("enabledPaymentOptions", ArgumentSemantic.Strong)]
		NSOrderedSet EnabledPaymentOptions { get; set; }

		// @property (nonatomic, strong) BTConfiguration * _Nonnull configuration;
		[Export ("configuration", ArgumentSemantic.Strong)]
		BTConfiguration Configuration { get; set; }

		[Wrap ("WeakAppSwitchDelegate")]
		[NullAllowed]
		BTAppSwitchDelegate AppSwitchDelegate { get; set; }

		// @property (nonatomic, weak) id<BTAppSwitchDelegate> _Nullable appSwitchDelegate;
		[NullAllowed, Export ("appSwitchDelegate", ArgumentSemantic.Weak)]
		NSObject WeakAppSwitchDelegate { get; set; }

		[Wrap ("WeakViewControllerPresentingDelegate")]
		[NullAllowed]
		BTViewControllerPresentingDelegate ViewControllerPresentingDelegate { get; set; }

		// @property (nonatomic, weak) id<BTViewControllerPresentingDelegate> _Nullable viewControllerPresentingDelegate;
		[NullAllowed, Export ("viewControllerPresentingDelegate", ArgumentSemantic.Weak)]
		NSObject WeakViewControllerPresentingDelegate { get; set; }

		// @property (readonly, nonatomic) BOOL hasAvailablePaymentMethod;
		[Export ("hasAvailablePaymentMethod")]
		bool HasAvailablePaymentMethod { get; }

		// @property (nonatomic, strong) id application;
		[Export ("application", ArgumentSemantic.Strong)]
		NSObject Application { get; set; }
	}

	// @interface BTUICardFormView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUICardFormView
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BTUICardFormViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTUICardFormViewDelegate> _Nullable delegate __attribute__((iboutlet));
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { get; }

		// @property (copy, nonatomic) NSString * number;
		[Export ("number")]
		string Number { get; set; }

		// @property (copy, nonatomic) NSString * cvv;
		[Export ("cvv")]
		string Cvv { get; set; }

		// @property (copy, nonatomic) NSString * postalCode;
		[Export ("postalCode")]
		string PostalCode { get; set; }

		// @property (readonly, copy, nonatomic) NSString * expirationMonth;
		[Export ("expirationMonth")]
		string ExpirationMonth { get; }

		// @property (readonly, copy, nonatomic) NSString * expirationYear;
		[Export ("expirationYear")]
		string ExpirationYear { get; }

		// -(void)setExpirationDate:(NSDate *)expirationDate;
		[Export ("setExpirationDate:")]
		void SetExpirationDate (NSDate expirationDate);

		// -(void)showTopLevelError:(NSString *)message;
		[Export ("showTopLevelError:")]
		void ShowTopLevelError (string message);

		// -(void)showErrorForField:(BTUICardFormField)field;
		[Export ("showErrorForField:")]
		void ShowErrorForField (BTUICardFormField field);

		// @property (assign, nonatomic) BOOL alphaNumericPostalCode;
		[Export ("alphaNumericPostalCode")]
		bool AlphaNumericPostalCode { get; set; }

		// @property (assign, nonatomic) BTUICardFormOptionalFields optionalFields;
		[Export ("optionalFields", ArgumentSemantic.Assign)]
		BTUICardFormOptionalFields OptionalFields { get; set; }

		// @property (assign, nonatomic) BOOL vibrate;
		[Export ("vibrate")]
		bool Vibrate { get; set; }
	}

	// @protocol BTUICardFormViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUICardFormViewDelegate
	{
		// @required -(void)cardFormViewDidChange:(BTUICardFormView *)cardFormView;
		[Abstract]
		[Export ("cardFormViewDidChange:")]
		void CardFormViewDidChange (BTUICardFormView cardFormView);

		// @optional -(void)cardFormViewDidBeginEditing:(BTUICardFormView *)cardFormView;
		[Export ("cardFormViewDidBeginEditing:")]
		void CardFormViewDidBeginEditing (BTUICardFormView cardFormView);
	}

	// @interface BTUICardHint : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUICardHint
	{
		// @property (assign, nonatomic) BTUIPaymentOptionType cardType;
		[Export ("cardType", ArgumentSemantic.Assign)]
		BTUIPaymentOptionType CardType { get; set; }

		// @property (assign, nonatomic) BTCardHintDisplayMode displayMode;
		[Export ("displayMode", ArgumentSemantic.Assign)]
		BTCardHintDisplayMode DisplayMode { get; set; }

		// @property (assign, nonatomic) BOOL highlighted;
		[Export ("highlighted")]
		bool Highlighted { get; set; }

		// -(void)setHighlighted:(BOOL)highlighted animated:(BOOL)animated;
		[Export ("setHighlighted:animated:")]
		void SetHighlighted (bool highlighted, bool animated);

		// -(void)setCardType:(BTUIPaymentOptionType)cardType animated:(BOOL)animated;
		[Export ("setCardType:animated:")]
		void SetCardType (BTUIPaymentOptionType cardType, bool animated);

		// -(void)setDisplayMode:(BTCardHintDisplayMode)displayMode animated:(BOOL)animated;
		[Export ("setDisplayMode:animated:")]
		void SetDisplayMode (BTCardHintDisplayMode displayMode, bool animated);
	}

	// @interface BTUICoinbaseButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUICoinbaseButton
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUICTAControl : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUICTAControl
	{
		// @property (copy, nonatomic) NSString * _Nullable displayAmount;
		[NullAllowed, Export ("displayAmount")]
		string DisplayAmount { get; set; }

		// @property (copy, nonatomic) NSString * _Nonnull callToAction;
		[Export ("callToAction")]
		string CallToAction { get; set; }

		// -(void)showLoadingState:(BOOL)loadingState;
		[Export ("showLoadingState:")]
		void ShowLoadingState (bool loadingState);

		// @property (nonatomic, strong) BTUI * _Nonnull theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUIPaymentMethodView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIPaymentMethodView
	{
		// @property (assign, nonatomic) BTUIPaymentOptionType type;
		[Export ("type", ArgumentSemantic.Assign)]
		BTUIPaymentOptionType Type { get; set; }

		// @property (copy, nonatomic) NSString * detailDescription;
		[Export ("detailDescription")]
		string DetailDescription { get; set; }

		// @property (getter = isProcessing, assign, nonatomic) BOOL processing;
		[Export ("processing")]
		bool Processing { [Bind ("isProcessing")] get; set; }
	}

	// @interface BTUIPayPalButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUIPayPalButton
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUISummaryView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUISummaryView
	{
		// @property (copy, nonatomic) NSString * slug;
		[Export ("slug")]
		string Slug { get; set; }

		// @property (copy, nonatomic) NSString * summary;
		[Export ("summary")]
		string Summary { get; set; }

		// @property (copy, nonatomic) NSString * amount;
		[Export ("amount")]
		string Amount { get; set; }
	}

	// @interface BTUIVenmoButton : UIControl
	[BaseType (typeof(UIControl))]
	interface BTUIVenmoButton
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUI (UIColor)
	[Category]
	[BaseType (typeof(UIColor))]
	interface UIColor_BTUI
	{
		// +(instancetype)bt_colorWithBytesR:(NSInteger)r G:(NSInteger)g B:(NSInteger)b A:(NSInteger)a;
		[Static]
		[Export ("bt_colorWithBytesR:G:B:A:")]
		UIColor Bt_colorWithBytesR (nint r, nint g, nint b, nint a);

		// +(instancetype)bt_colorWithBytesR:(NSInteger)r G:(NSInteger)g B:(NSInteger)b;
		[Static]
		[Export ("bt_colorWithBytesR:G:B:")]
		UIColor Bt_colorWithBytesR (nint r, nint g, nint b);

		// +(instancetype)bt_colorFromHex:(NSString *)hex alpha:(CGFloat)alpha;
		[Static]
		[Export ("bt_colorFromHex:alpha:")]
		UIColor Bt_colorFromHex (string hex, nfloat alpha);

		// -(instancetype)bt_adjustedBrightness:(CGFloat)adjustment;
		[Export ("bt_adjustedBrightness:")]
		UIColor Bt_adjustedBrightness (nfloat adjustment);
	}

	// @interface BTAnalyticsMetadata : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAnalyticsMetadata
	{
		// +(NSDictionary *)metadata;
		[Static]
		[Export ("metadata")]
		NSDictionary Metadata { get; }
	}

	// @interface BTHTTP : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTHTTP : INSCopying
	{
		// @property (nonatomic, strong) NSArray<NSData *> * _Nullable pinnedCertificates;
		[NullAllowed, Export ("pinnedCertificates", ArgumentSemantic.Strong)]
		NSData[] PinnedCertificates { get; set; }

		// -(instancetype _Nonnull)initWithBaseURL:(NSURL * _Nonnull)URL tokenizationKey:(NSString * _Nonnull)tokenizationKey __attribute__((objc_designated_initializer));
		[Export ("initWithBaseURL:tokenizationKey:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl URL, string tokenizationKey);

		// -(instancetype _Nonnull)initWithBaseURL:(NSURL * _Nonnull)URL authorizationFingerprint:(NSString * _Nonnull)authorizationFingerprint __attribute__((objc_designated_initializer));
		[Export ("initWithBaseURL:authorizationFingerprint:")]
		[DesignatedInitializer]
		IntPtr ConstructorWithAuthFingerprint (NSUrl URL, string authorizationFingerprint);

		// -(instancetype _Nonnull)initWithClientToken:(BTClientToken * _Nonnull)clientToken;
		[Export ("initWithClientToken:")]
		IntPtr Constructor (BTClientToken clientToken);

		// @property (nonatomic, strong) NSURLSession * _Nonnull session;
		[Export ("session", ArgumentSemantic.Strong)]
		NSUrlSession Session { get; set; }

		// @property (readonly, nonatomic, strong) NSURL * _Nonnull baseURL;
		[Export ("baseURL", ArgumentSemantic.Strong)]
		NSUrl BaseURL { get; }

		// @property (nonatomic, strong) dispatch_queue_t _Nonnull dispatchQueue;
		[Export ("dispatchQueue", ArgumentSemantic.Strong)]
		DispatchQueue DispatchQueue { get; set; }

		// -(void)GET:(NSString * _Nonnull)endpoint completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("GET:completion:")]
		void GET (string endpoint, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)GET:(NSString * _Nonnull)endpoint parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("GET:parameters:completion:")]
		void GET (string endpoint, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)POST:(NSString * _Nonnull)endpoint completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("POST:completion:")]
		void POST (string endpoint, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)POST:(NSString * _Nonnull)endpoint parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("POST:parameters:completion:")]
		void POST (string endpoint, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)PUT:(NSString * _Nonnull)endpoint completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("PUT:completion:")]
		void PUT (string endpoint, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)PUT:(NSString * _Nonnull)endpoint parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("PUT:parameters:completion:")]
		void PUT (string endpoint, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)DELETE:(NSString * _Nonnull)endpoint completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("DELETE:completion:")]
		void DELETE (string endpoint, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);

		// -(void)DELETE:(NSString * _Nonnull)endpoint parameters:(NSDictionary * _Nullable)parameters completion:(void (^ _Nullable)(BTJSON * _Nullable, NSHttpUrlResponse * _Nullable, NSError * _Nullable))completionBlock;
		[Export ("DELETE:parameters:completion:")]
		void DELETE (string endpoint, [NullAllowed] NSDictionary parameters, [NullAllowed] Action<BTJSON, NSHttpUrlResponse, NSError> completionBlock);
	}

	// @interface BTAPIPinnedCertificates : NSObject
	[BaseType (typeof(NSObject))]
	interface BTAPIPinnedCertificates
	{
		// +(NSArray *)trustedCertificates;
		[Static]
		[Export ("trustedCertificates")]
		NSObject[] TrustedCertificates { get; }
	}

	// @interface BTDropInContentView : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTDropInContentView
	{
		// @property (nonatomic, strong) BTUISummaryView * summaryView;
		[Export ("summaryView", ArgumentSemantic.Strong)]
		BTUISummaryView SummaryView { get; set; }

		// @property (nonatomic, strong) BTUICTAControl * ctaControl;
		[Export ("ctaControl", ArgumentSemantic.Strong)]
		BTUICTAControl CtaControl { get; set; }

		// @property (nonatomic, strong) BTPaymentButton * paymentButton;
		[Export ("paymentButton", ArgumentSemantic.Strong)]
		BTPaymentButton PaymentButton { get; set; }

		// @property (nonatomic, strong) UILabel * cardFormSectionHeader;
		[Export ("cardFormSectionHeader", ArgumentSemantic.Strong)]
		UILabel CardFormSectionHeader { get; set; }

		// @property (nonatomic, strong) BTUICardFormView * cardForm;
		[Export ("cardForm", ArgumentSemantic.Strong)]
		BTUICardFormView CardForm { get; set; }

		// @property (nonatomic, strong) BTUIPaymentMethodView * selectedPaymentMethodView;
		[Export ("selectedPaymentMethodView", ArgumentSemantic.Strong)]
		BTUIPaymentMethodView SelectedPaymentMethodView { get; set; }

		// @property (nonatomic, strong) UIButton * changeSelectedPaymentMethodButton;
		[Export ("changeSelectedPaymentMethodButton", ArgumentSemantic.Strong)]
		UIButton ChangeSelectedPaymentMethodButton { get; set; }

		// @property (assign, nonatomic) BOOL hideCTA;
		[Export ("hideCTA")]
		bool HideCTA { get; set; }

		// @property (assign, nonatomic) BOOL hideSummary;
		[Export ("hideSummary")]
		bool HideSummary { get; set; }

		// @property (assign, nonatomic) BTDropInContentViewStateType state;
		[Export ("state", ArgumentSemantic.Assign)]
		BTDropInContentViewStateType State { get; set; }

		// @property (assign, nonatomic) BOOL hidePaymentButton;
		[Export ("hidePaymentButton")]
		bool HidePaymentButton { get; set; }

		// -(void)setState:(BTDropInContentViewStateType)newState animate:(BOOL)animate;
		[Export ("setState:animate:")]
		void SetState (BTDropInContentViewStateType newState, bool animate);
	}

	// @interface BTDropInErrorAlert : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface BTDropInErrorAlert
	{
		// @property (copy, nonatomic) NSString * _Nonnull title;
		[Export ("title")]
		string Title { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable message;
		[NullAllowed, Export ("message")]
		string Message { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)() retryBlock;
		[NullAllowed, Export ("retryBlock", ArgumentSemantic.Copy)]
		Action RetryBlock { get; set; }

		// @property (copy, nonatomic) void (^ _Nullable)() cancelBlock;
		[NullAllowed, Export ("cancelBlock", ArgumentSemantic.Copy)]
		Action CancelBlock { get; set; }

		// @property (nonatomic, weak) UIViewController * _Nullable presentingViewController;
		[NullAllowed, Export ("presentingViewController", ArgumentSemantic.Weak)]
		UIViewController PresentingViewController { get; set; }

		// -(instancetype _Nonnull)initWithPresentingViewController:(UIViewController * _Nonnull)viewController __attribute__((objc_designated_initializer));
		[Export ("initWithPresentingViewController:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIViewController viewController);

		// -(void)show;
		[Export ("show")]
		void Show ();
	}

	// @interface BTDropInErrorState : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInErrorState
	{
		// -(instancetype)initWithError:(NSError *)error;
		[Export ("initWithError:")]
		IntPtr Constructor (NSError error);

		// @property (readonly, copy, nonatomic) NSString * errorTitle;
		[Export ("errorTitle")]
		string ErrorTitle { get; }

		// @property (readonly, nonatomic, strong) NSSet * highlightedFields;
		[Export ("highlightedFields", ArgumentSemantic.Strong)]
		NSSet HighlightedFields { get; }
	}

	// @interface BTDropInLocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInLocalizedString
	{
		// +(NSString *)DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT;
		[Static]
		[Export ("DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT")]
		string DROP_IN_CHANGE_PAYMENT_METHOD_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_OK_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_OK_BUTTON_TEXT")]
		string ERROR_ALERT_OK_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CANCEL_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_CANCEL_BUTTON_TEXT")]
		string ERROR_ALERT_CANCEL_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT")]
		string ERROR_ALERT_TRY_AGAIN_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CONNECTION_ERROR;
		[Static]
		[Export ("ERROR_ALERT_CONNECTION_ERROR")]
		string ERROR_ALERT_CONNECTION_ERROR { get; }

		// +(NSString *)DEFAULT_CALL_TO_ACTION;
		[Static]
		[Export ("DEFAULT_CALL_TO_ACTION")]
		string DEFAULT_CALL_TO_ACTION { get; }

		// +(NSString *)CARD_FORM_SECTION_HEADER;
		[Static]
		[Export ("CARD_FORM_SECTION_HEADER")]
		string CARD_FORM_SECTION_HEADER { get; }

		// +(NSString *)SELECT_PAYMENT_METHOD_TITLE;
		[Static]
		[Export ("SELECT_PAYMENT_METHOD_TITLE")]
		string SELECT_PAYMENT_METHOD_TITLE { get; }

		// +(NSString *)ERROR_SAVING_CARD_ALERT_TITLE;
		[Static]
		[Export ("ERROR_SAVING_CARD_ALERT_TITLE")]
		string ERROR_SAVING_CARD_ALERT_TITLE { get; }

		// +(NSString *)ERROR_SAVING_CARD_MESSAGE;
		[Static]
		[Export ("ERROR_SAVING_CARD_MESSAGE")]
		string ERROR_SAVING_CARD_MESSAGE { get; }

		// +(NSString *)ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE;
		[Static]
		[Export ("ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE")]
		string ERROR_SAVING_PAYMENT_METHOD_ALERT_TITLE { get; }

		// +(NSString *)ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE;
		[Static]
		[Export ("ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE")]
		string ERROR_SAVING_PAYPAL_ACCOUNT_ALERT_MESSAGE { get; }

		// +(NSString *)ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE;
		[Static]
		[Export ("ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE")]
		string ADD_PAYMENT_METHOD_VIEW_CONTROLLER_TITLE { get; }
	}

	// @interface BTDropInSelectPaymentMethodViewController : UITableViewController
	[BaseType (typeof(UITableViewController))]
	interface BTDropInSelectPaymentMethodViewController
	{
		// @property (nonatomic, strong) BTAPIClient * client;
		[Export ("client", ArgumentSemantic.Strong)]
		BTAPIClient Client { get; set; }

		// Unable to make this work correctly at the moment.
//		[Wrap ("WeakDelegate")]
//		[NullAllowed]
//		IBTDropInSelectPaymentMethodViewControllerDelegate Delegate { get; set; }
//
//		// @property (nonatomic, weak) id<BTDropInSelectPaymentMethodViewControllerDelegate> _Nullable delegate;
//		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
//		NSObject WeakDelegate { get; set; }
//
		// @property (nonatomic, strong) NSArray * paymentMethodNonces;
		[Export ("paymentMethodNonces", ArgumentSemantic.Strong)]
		BTPaymentMethodNonce[] PaymentMethodNonces { get; set; }

		// @property (assign, nonatomic) NSInteger selectedPaymentMethodIndex;
		[Export ("selectedPaymentMethodIndex")]
		nint SelectedPaymentMethodIndex { get; set; }

		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @protocol BTDropInSelectPaymentMethodViewControllerDelegate
	[Protocol, Model]
	interface BTDropInSelectPaymentMethodViewControllerDelegate
	{
		// @required -(void)selectPaymentMethodViewController:(BTDropInSelectPaymentMethodViewController *)viewController didSelectPaymentMethodAtIndex:(NSUInteger)index;
		[Abstract]
		[Export ("selectPaymentMethodViewController:didSelectPaymentMethodAtIndex:")]
		void SelectPaymentMethodViewController (BTDropInSelectPaymentMethodViewController viewController, nuint index);

		// @required -(void)selectPaymentMethodViewControllerDidRequestNew:(BTDropInSelectPaymentMethodViewController *)viewController;
		[Abstract]
		[Export ("selectPaymentMethodViewControllerDidRequestNew:")]
		void SelectPaymentMethodViewControllerDidRequestNew (BTDropInSelectPaymentMethodViewController viewController);
	}

	// @interface BTDropInUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTDropInUtil
	{
		// +(BTUIPaymentOptionType)uiForCardNetwork:(BTCardNetwork)cardNetwork;
		[Static]
		[Export ("uiForCardNetwork:")]
		BTUIPaymentOptionType UiForCardNetwork (BTCardNetwork cardNetwork);
	}

	// @interface BTKeychain : NSObject
	[BaseType (typeof(NSObject))]
	interface BTKeychain
	{
		// +(BOOL)setString:(NSString *)string forKey:(NSString *)key;
		[Static]
		[Export ("setString:forKey:")]
		bool SetString (string @string, string key);

		// +(NSString *)stringForKey:(NSString *)key;
		[Static]
		[Export ("stringForKey:")]
		string StringForKey (string key);

		// +(BOOL)setData:(NSData *)data forKey:(NSString *)key;
		[Static]
		[Export ("setData:forKey:")]
		bool SetData (NSData data, string key);

		// +(NSData *)dataForKey:(NSString *)key;
		[Static]
		[Export ("dataForKey:")]
		NSData DataForKey (string key);
	}

	// @interface PayPalOneTouchCoreResult : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalOneTouchCoreResult
	{
		// @property (readonly, assign, nonatomic) PayPalOneTouchResultType type;
		[Export ("type", ArgumentSemantic.Assign)]
		PayPalOneTouchResultType Type { get; }

		// @property (readonly, copy, nonatomic) NSDictionary * response;
		[Export ("response", ArgumentSemantic.Copy)]
		NSDictionary Response { get; }

		// @property (readonly, copy, nonatomic) NSError * error;
		[Export ("error", ArgumentSemantic.Copy)]
		NSError Error { get; }

		// @property (readonly, assign, nonatomic) PayPalOneTouchRequestTarget target;
		[Export ("target", ArgumentSemantic.Assign)]
		PayPalOneTouchRequestTarget Target { get; }
	}

	// typedef void (^PayPalOneTouchRequestPreflightCompletionBlock)(PayPalOneTouchRequestTarget);
	delegate void PayPalOneTouchRequestPreflightCompletionBlock (PayPalOneTouchRequestTarget arg0);

	// typedef void (^PayPalOneTouchRequestAdapterBlock)(BOOL, NSURL *, PayPalOneTouchRequestTarget, NSString *, NSError *);
	delegate void PayPalOneTouchRequestAdapterBlock (bool arg0, NSUrl arg1, PayPalOneTouchRequestTarget arg2, string arg3, NSError arg4);

//	[Static]
//	[Verify (ConstantsInterfaceAssociation)]
//	partial interface Constants
//	{
//		// extern NSString *const PayPalEnvironmentProduction;
//		[Field ("PayPalEnvironmentProduction", "__Internal")]
//		NSString PayPalEnvironmentProduction { get; }
//
//		// extern NSString *const PayPalEnvironmentSandbox;
//		[Field ("PayPalEnvironmentSandbox", "__Internal")]
//		NSString PayPalEnvironmentSandbox { get; }
//
//		// extern NSString *const PayPalEnvironmentMock;
//		[Field ("PayPalEnvironmentMock", "__Internal")]
//		NSString PayPalEnvironmentMock { get; }
//	}

	// @interface PayPalOneTouchRequest : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalOneTouchRequest
	{
		// -(void)getTargetApp:(PayPalOneTouchRequestPreflightCompletionBlock)completionBlock;
		[Export ("getTargetApp:")]
		void GetTargetApp (PayPalOneTouchRequestPreflightCompletionBlock completionBlock);

		// -(void)performWithAdapterBlock:(PayPalOneTouchRequestAdapterBlock)adapterBlock;
		[Export ("performWithAdapterBlock:")]
		void PerformWithAdapterBlock (PayPalOneTouchRequestAdapterBlock adapterBlock);

		// +(NSString *)tokenFromApprovalURL:(NSURL *)approvalURL;
		[Static]
		[Export ("tokenFromApprovalURL:")]
		string TokenFromApprovalURL (NSUrl approvalURL);

		// @property (readonly, nonatomic) NSString * clientID;
		[Export ("clientID")]
		string ClientID { get; }

		// @property (readonly, nonatomic) NSString * environment;
		[Export ("environment")]
		string Environment { get; }

		// @property (readonly, nonatomic) NSString * callbackURLScheme;
		[Export ("callbackURLScheme")]
		string CallbackURLScheme { get; }

		// @property (nonatomic, strong) NSDictionary * additionalPayloadAttributes;
		[Export ("additionalPayloadAttributes", ArgumentSemantic.Strong)]
		NSDictionary AdditionalPayloadAttributes { get; set; }
	}

	// @interface PayPalOneTouchAuthorizationRequest : PayPalOneTouchRequest
	[BaseType (typeof(PayPalOneTouchRequest))]
	interface PayPalOneTouchAuthorizationRequest
	{
		// +(instancetype)requestWithScopeValues:(NSSet *)scopeValues privacyURL:(NSURL *)privacyURL agreementURL:(NSURL *)agreementURL clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Static]
		[Export ("requestWithScopeValues:privacyURL:agreementURL:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchAuthorizationRequest RequestWithScopeValues (NSSet scopeValues, NSUrl privacyURL, NSUrl agreementURL, string clientID, string environment, string callbackURLScheme);

		// @property (readonly, nonatomic) NSSet * scopeValues;
		[Export ("scopeValues")]
		NSSet ScopeValues { get; }

		// @property (readonly, nonatomic) NSURL * privacyURL;
		[Export ("privacyURL")]
		NSUrl PrivacyURL { get; }

		// @property (readonly, nonatomic) NSURL * agreementURL;
		[Export ("agreementURL")]
		NSUrl AgreementURL { get; }
	}

	// @interface PayPalOneTouchCheckoutRequest : PayPalOneTouchRequest
	[BaseType (typeof(PayPalOneTouchRequest))]
	interface PayPalOneTouchCheckoutRequest
	{
		// @property (nonatomic, strong) NSString * pairingId;
		[Export ("pairingId", ArgumentSemantic.Strong)]
		string PairingId { get; set; }

		// +(instancetype)requestWithApprovalURL:(NSURL *)approvalURL clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Static]
		[Export ("requestWithApprovalURL:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchCheckoutRequest RequestWithApprovalURL (NSUrl approvalURL, string clientID, string environment, string callbackURLScheme);

		// +(instancetype)requestWithApprovalURL:(NSURL *)approvalURL pairingId:(NSString *)pairingId clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Static]
		[Export ("requestWithApprovalURL:pairingId:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchCheckoutRequest RequestWithApprovalURL (NSUrl approvalURL, string pairingId, string clientID, string environment, string callbackURLScheme);

		// @property (readonly, nonatomic) NSURL * approvalURL;
		[Export ("approvalURL")]
		NSUrl ApprovalURL { get; }
	}

	// @interface PayPalOneTouchBillingAgreementRequest : PayPalOneTouchCheckoutRequest
	[BaseType (typeof(PayPalOneTouchCheckoutRequest))]
	interface PayPalOneTouchBillingAgreementRequest
	{
	}

	// typedef void (^PayPalOneTouchCompletionBlock)(PayPalOneTouchCoreResult *);
	delegate void PayPalOneTouchCompletionBlock (PayPalOneTouchCoreResult arg0);

	// @interface PayPalOneTouchCore : NSObject
	[BaseType (typeof(NSObject))]
	interface PayPalOneTouchCore
	{
		// +(BOOL)doesApplicationSupportOneTouchCallbackURLScheme:(NSString *)callbackURLScheme;
		[Static]
		[Export ("doesApplicationSupportOneTouchCallbackURLScheme:")]
		bool DoesApplicationSupportOneTouchCallbackURLScheme (string callbackURLScheme);

		// +(BOOL)isWalletAppInstalled;
		[Static]
		[Export ("isWalletAppInstalled")]
		bool IsWalletAppInstalled { get; }

		// +(BOOL)canParseURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Static]
		[Export ("canParseURL:sourceApplication:")]
		bool CanParseURL (NSUrl url, string sourceApplication);

		// +(void)parseResponseURL:(NSURL *)url completionBlock:(PayPalOneTouchCompletionBlock)completionBlock;
		[Static]
		[Export ("parseResponseURL:completionBlock:")]
		void ParseResponseURL (NSUrl url, PayPalOneTouchCompletionBlock completionBlock);

		// +(NSString *)clientMetadataID;
		[Static]
		[Export ("clientMetadataID")]
		string ClientMetadataID { get; }

		// +(NSString *)clientMetadataID:(NSString *)pairingId;
		[Static]
		[Export ("clientMetadataID:")]
		string GetClientMetadataIDFromPairingId (string pairingId);

		// +(void)redirectURLsForCallbackURLScheme:(NSString *)callbackURLScheme withReturnURL:(NSString **)returnURL withCancelURL:(NSString **)cancelURL;
		[Static]
		[Export ("redirectURLsForCallbackURLScheme:withReturnURL:withCancelURL:")]
		void RedirectURLsForCallbackURLScheme (string callbackURLScheme, out string returnURL, out string cancelURL);

		// +(NSString *)libraryVersion;
		[Static]
		[Export ("libraryVersion")]
		string LibraryVersion { get; }
	}

	// @interface BTPayPalRequestFactory : NSObject
	[BaseType (typeof(NSObject))]
	interface BTPayPalRequestFactory
	{
		// -(PayPalOneTouchCheckoutRequest *)checkoutRequestWithApprovalURL:(NSURL *)approvalURL clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Export ("checkoutRequestWithApprovalURL:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchCheckoutRequest CheckoutRequestWithApprovalURL (NSUrl approvalURL, string clientID, string environment, string callbackURLScheme);

		// -(PayPalOneTouchBillingAgreementRequest *)billingAgreementRequestWithApprovalURL:(NSURL *)approvalURL clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Export ("billingAgreementRequestWithApprovalURL:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchBillingAgreementRequest BillingAgreementRequestWithApprovalURL (NSUrl approvalURL, string clientID, string environment, string callbackURLScheme);

		// -(PayPalOneTouchAuthorizationRequest *)requestWithScopeValues:(NSSet *)scopeValues privacyURL:(NSURL *)privacyURL agreementURL:(NSURL *)agreementURL clientID:(NSString *)clientID environment:(NSString *)environment callbackURLScheme:(NSString *)callbackURLScheme;
		[Export ("requestWithScopeValues:privacyURL:agreementURL:clientID:environment:callbackURLScheme:")]
		PayPalOneTouchAuthorizationRequest RequestWithScopeValues (NSSet scopeValues, NSUrl privacyURL, NSUrl agreementURL, string clientID, string environment, string callbackURLScheme);
	}

	// @interface BTThreeDSecureLookupResult : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureLookupResult
	{
		// @property (copy, nonatomic) NSString * PAReq;
		[Export ("PAReq")]
		string PAReq { get; set; }

		// @property (copy, nonatomic) NSString * MD;
		[Export ("MD")]
		string MD { get; set; }

		// @property (copy, nonatomic) NSURL * acsURL;
		[Export ("acsURL", ArgumentSemantic.Copy)]
		NSUrl AcsURL { get; set; }

		// @property (copy, nonatomic) NSURL * termURL;
		[Export ("termURL", ArgumentSemantic.Copy)]
		NSUrl TermURL { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureCardNonce * tokenizedCard;
		[Export ("tokenizedCard", ArgumentSemantic.Strong)]
		BTThreeDSecureCardNonce TokenizedCard { get; set; }

		// -(BOOL)requiresUserAuthentication;
		[Export ("requiresUserAuthentication")]
		bool RequiresUserAuthentication { get; }
	}

	// @interface BTWebViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface BTWebViewController
	{
		// -(instancetype _Nonnull)initWithRequest:(NSURLRequest * _Nonnull)request __attribute__((objc_designated_initializer));
		[Export ("initWithRequest:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrlRequest request);

		// -(BOOL)webView:(UIWebView * _Nonnull)webView shouldStartLoadWithRequest:(NSURLRequest * _Nonnull)request navigationType:(UIWebViewNavigationType)navigationType __attribute__((objc_requires_super));
		[Export ("webView:shouldStartLoadWithRequest:navigationType:")]
		//[RequiresSuper]
		bool WebView (UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType);

		// -(void)webViewDidStartLoad:(UIWebView * _Nonnull)webView __attribute__((objc_requires_super));
		[Export ("webViewDidStartLoad:")]
		//[RequiresSuper]
		void WebViewDidStartLoad (UIWebView webView);

		// -(void)webViewDidFinishLoad:(UIWebView * _Nonnull)webView __attribute__((objc_requires_super));
		[Export ("webViewDidFinishLoad:")]
		//[RequiresSuper]
		void WebViewDidFinishLoad (UIWebView webView);

		// -(void)webView:(UIWebView * _Nonnull)webView didFailLoadWithError:(NSError * _Nonnull)error;
		[Export ("webView:didFailLoadWithError:")]
		void WebView (UIWebView webView, NSError error);
	}

	// @interface BTThreeDSecureAuthenticationViewController : BTWebViewController
	[BaseType (typeof(BTWebViewController))]
	interface BTThreeDSecureAuthenticationViewController
	{
		// -(instancetype)initWithLookupResult:(BTThreeDSecureLookupResult *)lookupResult __attribute__((objc_designated_initializer));
		[Export ("initWithLookupResult:")]
		[DesignatedInitializer]
		IntPtr Constructor (BTThreeDSecureLookupResult lookupResult);

		[Wrap ("WeakDelegate")]
		BTThreeDSecureAuthenticationViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, strong) id<BTThreeDSecureAuthenticationViewControllerDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Strong)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol BTThreeDSecureAuthenticationViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureAuthenticationViewControllerDelegate
	{
		// @required -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didAuthenticateCard:(BTThreeDSecureCardNonce *)tokenizedCard completion:(void (^)(BTThreeDSecureViewControllerCompletionStatus))completionBlock;
		[Abstract]
		[Export ("threeDSecureViewController:didAuthenticateCard:completion:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, BTThreeDSecureCardNonce tokenizedCard, Action<BTThreeDSecureViewControllerCompletionStatus> completionBlock);

		// @required -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didFailWithError:(NSError *)error;
		[Abstract]
		[Export ("threeDSecureViewController:didFailWithError:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, NSError error);

		// @required -(void)threeDSecureViewControllerDidFinish:(BTThreeDSecureAuthenticationViewController *)viewController;
		[Abstract]
		[Export ("threeDSecureViewControllerDidFinish:")]
		void ThreeDSecureViewControllerDidFinish (BTThreeDSecureAuthenticationViewController viewController);

		// @optional -(void)threeDSecureViewController:(BTThreeDSecureAuthenticationViewController *)viewController didPresentErrorToUserForURLRequest:(NSURLRequest *)request;
		[Export ("threeDSecureViewController:didPresentErrorToUserForURLRequest:")]
		void ThreeDSecureViewController (BTThreeDSecureAuthenticationViewController viewController, NSUrlRequest request);
	}

	// @interface BTThreeDSecureLocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureLocalizedString
	{
		// +(NSString *)ERROR_ALERT_OK_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_OK_BUTTON_TEXT")]
		string ERROR_ALERT_OK_BUTTON_TEXT { get; }

		// +(NSString *)ERROR_ALERT_CANCEL_BUTTON_TEXT;
		[Static]
		[Export ("ERROR_ALERT_CANCEL_BUTTON_TEXT")]
		string ERROR_ALERT_CANCEL_BUTTON_TEXT { get; }
	}

	// @interface BTThreeDSecureResponse : NSObject
	[BaseType (typeof(NSObject))]
	interface BTThreeDSecureResponse
	{
		// @property (assign, nonatomic) BOOL success;
		[Export ("success")]
		bool Success { get; set; }

		// @property (nonatomic, strong) NSDictionary * threeDSecureInfo;
		[Export ("threeDSecureInfo", ArgumentSemantic.Strong)]
		NSDictionary ThreeDSecureInfo { get; set; }

		// @property (nonatomic, strong) BTThreeDSecureCardNonce * tokenizedCard;
		[Export ("tokenizedCard", ArgumentSemantic.Strong)]
		BTThreeDSecureCardNonce TokenizedCard { get; set; }

		// @property (copy, nonatomic) NSString * errorMessage;
		[Export ("errorMessage")]
		string ErrorMessage { get; set; }
	}

	// @interface BTUICardVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUICardVectorArtView
	{
		// @property (nonatomic, strong) UIColor * highlightColor;
		[Export ("highlightColor", ArgumentSemantic.Strong)]
		UIColor HighlightColor { get; set; }
	}

	// @interface BTUIAmExVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIAmExVectorArtView
	{
	}

	// @interface BTUIFormField : BTUIThemedView <UITextFieldDelegate, UIKeyInput>
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIFormField : IUITextFieldDelegate, IUIKeyInput
	{
		// -(void)updateAppearance;
		[Export ("updateAppearance")]
		void UpdateAppearance ();

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		BTUIFormFieldDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<BTUIFormFieldDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (assign, nonatomic) BOOL vibrateOnInvalidInput;
		[Export ("vibrateOnInvalidInput")]
		bool VibrateOnInvalidInput { get; set; }

		// @property (readonly, assign, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { get; }

		// @property (readonly, assign, nonatomic) BOOL entryComplete;
		[Export ("entryComplete")]
		bool EntryComplete { get; }

		// @property (assign, nonatomic) BOOL displayAsValid;
		[Export ("displayAsValid")]
		bool DisplayAsValid { get; set; }

		// @property (assign, nonatomic) BOOL bottomBorder;
		[Export ("bottomBorder")]
		bool BottomBorder { get; set; }

		// @property (assign, readwrite, nonatomic) BOOL backspace;
		[Export ("backspace")]
		bool Backspace { get; set; }

		// @property (copy, nonatomic) NSString * text;
		[Export ("text")]
		string Text { get; set; }

		// @property (readonly, nonatomic, strong) BTUITextField * textField;
		[Export ("textField", ArgumentSemantic.Strong)]
		BTUITextField TextField { get; }

		// @property (nonatomic, strong) UIView * accessoryView;
		[Export ("accessoryView", ArgumentSemantic.Strong)]
		UIView AccessoryView { get; set; }
	}

	// @protocol BTUIFormFieldDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUIFormFieldDelegate
	{
		// @required -(void)formFieldDidChange:(BTUIFormField *)formField;
		[Abstract]
		[Export ("formFieldDidChange:")]
		void FormFieldDidChange (BTUIFormField formField);

		// @required -(void)formFieldDidDeleteWhileEmpty:(BTUIFormField *)formField;
		[Abstract]
		[Export ("formFieldDidDeleteWhileEmpty:")]
		void FormFieldDidDeleteWhileEmpty (BTUIFormField formField);

		// @optional -(BOOL)formFieldShouldReturn:(BTUIFormField *)formField;
		[Export ("formFieldShouldReturn:")]
		bool FormFieldShouldReturn (BTUIFormField formField);

		// @optional -(void)formFieldDidBeginEditing:(BTUIFormField *)formField;
		[Export ("formFieldDidBeginEditing:")]
		void FormFieldDidBeginEditing (BTUIFormField formField);
	}

	// @interface BTUILocalizedString : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUILocalizedString
	{
		// +(NSString *)CARD_NUMBER_PLACEHOLDER;
		[Static]
		[Export ("CARD_NUMBER_PLACEHOLDER")]
		string CARD_NUMBER_PLACEHOLDER { get; }

		// +(NSString *)CVV_FIELD_PLACEHOLDER;
		[Static]
		[Export ("CVV_FIELD_PLACEHOLDER")]
		string CVV_FIELD_PLACEHOLDER { get; }

		// +(NSString *)EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR;
		[Static]
		[Export ("EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR")]
		string EXPIRY_PLACEHOLDER_FOUR_DIGIT_YEAR { get; }

		// +(NSString *)EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR;
		[Static]
		[Export ("EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR")]
		string EXPIRY_PLACEHOLDER_TWO_DIGIT_YEAR { get; }

		// +(NSString *)PAYPAL_CARD_BRAND;
		[Static]
		[Export ("PAYPAL_CARD_BRAND")]
		string PAYPAL_CARD_BRAND { get; }

		// +(NSString *)POSTAL_CODE_PLACEHOLDER;
		[Static]
		[Export ("POSTAL_CODE_PLACEHOLDER")]
		string POSTAL_CODE_PLACEHOLDER { get; }

		// +(NSString *)TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT;
		[Static]
		[Export ("TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT")]
		string TOP_LEVEL_ERROR_ALERT_VIEW_OK_BUTTON_TEXT { get; }

		// +(NSString *)CARD_TYPE_AMERICAN_EXPRESS;
		[Static]
		[Export ("CARD_TYPE_AMERICAN_EXPRESS")]
		string CARD_TYPE_AMERICAN_EXPRESS { get; }

		// +(NSString *)CARD_TYPE_DISCOVER;
		[Static]
		[Export ("CARD_TYPE_DISCOVER")]
		string CARD_TYPE_DISCOVER { get; }

		// +(NSString *)CARD_TYPE_DINERS_CLUB;
		[Static]
		[Export ("CARD_TYPE_DINERS_CLUB")]
		string CARD_TYPE_DINERS_CLUB { get; }

		// +(NSString *)CARD_TYPE_MASTER_CARD;
		[Static]
		[Export ("CARD_TYPE_MASTER_CARD")]
		string CARD_TYPE_MASTER_CARD { get; }

		// +(NSString *)CARD_TYPE_VISA;
		[Static]
		[Export ("CARD_TYPE_VISA")]
		string CARD_TYPE_VISA { get; }

		// +(NSString *)CARD_TYPE_JCB;
		[Static]
		[Export ("CARD_TYPE_JCB")]
		string CARD_TYPE_JCB { get; }

		// +(NSString *)CARD_TYPE_MAESTRO;
		[Static]
		[Export ("CARD_TYPE_MAESTRO")]
		string CARD_TYPE_MAESTRO { get; }

		// +(NSString *)CARD_TYPE_UNION_PAY;
		[Static]
		[Export ("CARD_TYPE_UNION_PAY")]
		string CARD_TYPE_UNION_PAY { get; }

		// +(NSString *)CARD_TYPE_SWITCH;
		[Static]
		[Export ("CARD_TYPE_SWITCH")]
		string CARD_TYPE_SWITCH { get; }

		// +(NSString *)CARD_TYPE_SOLO;
		[Static]
		[Export ("CARD_TYPE_SOLO")]
		string CARD_TYPE_SOLO { get; }

		// +(NSString *)CARD_TYPE_LASER;
		[Static]
		[Export ("CARD_TYPE_LASER")]
		string CARD_TYPE_LASER { get; }

		// +(NSString *)PAYMENT_METHOD_TYPE_PAYPAL;
		[Static]
		[Export ("PAYMENT_METHOD_TYPE_PAYPAL")]
		string PAYMENT_METHOD_TYPE_PAYPAL { get; }

		// +(NSString *)PAYMENT_METHOD_TYPE_COINBASE;
		[Static]
		[Export ("PAYMENT_METHOD_TYPE_COINBASE")]
		string PAYMENT_METHOD_TYPE_COINBASE { get; }

		// +(NSString *)PAYMENT_METHOD_TYPE_VENMO;
		[Static]
		[Export ("PAYMENT_METHOD_TYPE_VENMO")]
		string PAYMENT_METHOD_TYPE_VENMO { get; }
	}

	// @interface BTUICardType : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardType
	{
		// +(instancetype)cardTypeForBrand:(NSString *)brand;
		[Static]
		[Export ("cardTypeForBrand:")]
		BTUICardType CardTypeForBrand (string brand);

		// +(instancetype)cardTypeForNumber:(NSString *)number;
		[Static]
		[Export ("cardTypeForNumber:")]
		BTUICardType CardTypeForNumber (string number);

		// +(NSArray *)possibleCardTypesForNumber:(NSString *)number;
		[Static]
		[Export ("possibleCardTypesForNumber:")]
		BTUICardType[] PossibleCardTypesForNumber (string number);

		// -(BOOL)validNumber:(NSString *)number;
		[Export ("validNumber:")]
		bool ValidNumber (string number);

		// -(BOOL)completeNumber:(NSString *)number;
		[Export ("completeNumber:")]
		bool CompleteNumber (string number);

		// -(BOOL)validAndNecessarilyCompleteNumber:(NSString *)number;
		[Export ("validAndNecessarilyCompleteNumber:")]
		bool ValidAndNecessarilyCompleteNumber (string number);

		// -(BOOL)validCvv:(NSString *)cvv;
		[Export ("validCvv:")]
		bool ValidCvv (string cvv);

		// -(NSAttributedString *)formatNumber:(NSString *)input;
		[Export ("formatNumber:")]
		NSAttributedString FormatNumber (string input);

		// -(NSAttributedString *)formatNumber:(NSString *)input kerning:(CGFloat)kerning;
		[Export ("formatNumber:kerning:")]
		NSAttributedString FormatNumber (string input, nfloat kerning);

		// +(NSUInteger)maxNumberLength;
		[Static]
		[Export ("maxNumberLength")]
		nuint GetMaxNumberLength();

		// @property (readonly, copy, nonatomic) NSString * brand;
		[Export ("brand")]
		string Brand { get; }

		// @property (readonly, nonatomic, strong) NSArray * validNumberPrefixes;
		[Export ("validNumberPrefixes", ArgumentSemantic.Strong)]
		NSObject[] ValidNumberPrefixes { get; }

		// @property (readonly, nonatomic, strong) NSIndexSet * validNumberLengths;
		[Export ("validNumberLengths", ArgumentSemantic.Strong)]
		NSIndexSet ValidNumberLengths { get; }

		// @property (readonly, assign, nonatomic) NSUInteger validCvvLength;
		[Export ("validCvvLength")]
		nuint ValidCvvLength { get; }

		// @property (readonly, nonatomic, strong) NSArray * formatSpaces;
		[Export ("formatSpaces", ArgumentSemantic.Strong)]
		NSObject[] FormatSpaces { get; }

		// @property (readonly, assign, nonatomic) NSUInteger maxNumberLength;
		[Export ("maxNumberLength")]
		nuint MaxNumberLength { get; }
	}

	// @interface BTUICardCvvField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardCvvField
	{
		// @property (nonatomic, strong) BTUICardType * cardType;
		[Export ("cardType", ArgumentSemantic.Strong)]
		BTUICardType CardType { get; set; }

		// @property (copy, nonatomic) NSString * cvv;
		[Export ("cvv")]
		string Cvv { get; set; }
	}

	// @interface BTUICardExpirationValidator : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardExpirationValidator
	{
		// +(BOOL)month:(NSUInteger)month year:(NSUInteger)year validForDate:(NSDate *)date;
		[Static]
		[Export ("month:year:validForDate:")]
		bool Month (nuint month, nuint year, NSDate date);
	}

	// @interface BTUICardExpiryField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardExpiryField
	{
		// @property (readonly, nonatomic, strong) NSString * expirationMonth;
		[Export ("expirationMonth", ArgumentSemantic.Strong)]
		string ExpirationMonth { get; }

		// @property (readonly, nonatomic, strong) NSString * expirationYear;
		[Export ("expirationYear", ArgumentSemantic.Strong)]
		string ExpirationYear { get; }

		// @property (copy, nonatomic) NSString * expirationDate;
		[Export ("expirationDate")]
		string ExpirationDate { get; set; }
	}

	// @interface BTUICardExpiryFormat : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUICardExpiryFormat
	{
		// @property (copy, nonatomic) NSString * value;
		[Export ("value")]
		string Value { get; set; }

		// @property (assign, nonatomic) NSUInteger cursorLocation;
		[Export ("cursorLocation")]
		nuint CursorLocation { get; set; }

		// @property (assign, nonatomic) BOOL backspace;
		[Export ("backspace")]
		bool Backspace { get; set; }

		// -(void)formattedValue:(NSString **)value cursorLocation:(NSUInteger *)cursorLocation;
		[Export ("formattedValue:cursorLocation:")]
		unsafe void FormattedValue (out string value,ref nuint cursorLocation);
	}

	// @interface BTUICardNumberField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardNumberField
	{
		// @property (readonly, nonatomic, strong) BTUICardType * cardType;
		[Export ("cardType", ArgumentSemantic.Strong)]
		BTUICardType CardType { get; }

		// @property (nonatomic, strong) NSString * number;
		[Export ("number", ArgumentSemantic.Strong)]
		string Number { get; set; }
	}

	// @interface BTUICardPostalCodeField : BTUIFormField
	[BaseType (typeof(BTUIFormField))]
	interface BTUICardPostalCodeField
	{
		// @property (nonatomic, strong) NSString * postalCode;
		[Export ("postalCode", ArgumentSemantic.Strong)]
		string PostalCode { get; set; }

		// @property (assign, nonatomic) BOOL nonDigitsSupported;
		[Export ("nonDigitsSupported")]
		bool NonDigitsSupported { get; set; }
	}

	// @interface BTUICoinbaseMonogramCardView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUICoinbaseMonogramCardView
	{
	}

	// @interface BTUICoinbaseWordmarkVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUICoinbaseWordmarkVectorArtView
	{
		// @property (nonatomic, strong) UIColor * color;
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }
	}

	// @interface BTUICVVBackVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUICVVBackVectorArtView
	{
	}

	// @interface BTUICVVFrontVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUICVVFrontVectorArtView
	{
	}

	// @interface BTUIDinersClubVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIDinersClubVectorArtView
	{
	}

	// @interface BTUIDiscoverVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIDiscoverVectorArtView
	{
	}

	// @interface BTUIFloatLabel : BTUIThemedView
	[BaseType (typeof(BTUIThemedView))]
	interface BTUIFloatLabel
	{
		// @property (readonly, nonatomic, strong) UILabel * label;
		[Export ("label", ArgumentSemantic.Strong)]
		UILabel Label { get; }

		// -(void)showWithAnimation:(BOOL)shouldAnimate;
		[Export ("showWithAnimation:")]
		void ShowWithAnimation (bool shouldAnimate);

		// -(void)hideWithAnimation:(BOOL)shouldAnimate;
		[Export ("hideWithAnimation:")]
		void HideWithAnimation (bool shouldAnimate);
	}

	// @interface BTUITextField : UITextField
	[BaseType (typeof(UITextField))]
	interface BTUITextField
	{
		[Wrap ("WeakEditDelegate")]
		[NullAllowed]
		BTUITextFieldEditDelegate EditDelegate { get; set; }

		// @property (nonatomic, weak) id<BTUITextFieldEditDelegate> _Nullable editDelegate;
		[NullAllowed, Export ("editDelegate", ArgumentSemantic.Weak)]
		NSObject WeakEditDelegate { get; set; }
	}

	// @protocol BTUITextFieldEditDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUITextFieldEditDelegate
	{
		// @optional -(void)textFieldWillDeleteBackward:(BTUITextField *)textField;
		[Export ("textFieldWillDeleteBackward:")]
		void TextFieldWillDeleteBackward (BTUITextField textField);

		// @optional -(void)textFieldDidDeleteBackward:(BTUITextField *)textField originalText:(NSString *)originalText;
		[Export ("textFieldDidDeleteBackward:originalText:")]
		void TextFieldDidDeleteBackward (BTUITextField textField, string originalText);

		// @optional -(void)textField:(BTUITextField *)textField willInsertText:(NSString *)text;
		[Export ("textField:willInsertText:")]
		void TextField_WillInsertText (BTUITextField textField, string text);

		// @optional -(void)textField:(BTUITextField *)textField didInsertText:(NSString *)text;
		[Export ("textField:didInsertText:")]
		void TextField_DidInsertText (BTUITextField textField, string text);
	}

	// @interface BTUIHorizontalButtonStackCollectionViewFlowLayout : UICollectionViewFlowLayout
	[BaseType (typeof(UICollectionViewFlowLayout))]
	interface BTUIHorizontalButtonStackCollectionViewFlowLayout
	{
	}

	// @interface BTUIHorizontalButtonStackSeparatorLineView : UICollectionReusableView
	[BaseType (typeof(UICollectionReusableView))]
	interface BTUIHorizontalButtonStackSeparatorLineView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUIJCBVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIJCBVectorArtView
	{
	}

	// @interface BTUIMaestroVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIMaestroVectorArtView
	{
	}

	// @interface BTUIMasterCardVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIMasterCardVectorArtView
	{
	}

	// @interface BTUIPaymentButtonCollectionViewCell : UICollectionViewCell
	[BaseType (typeof(UICollectionViewCell))]
	interface BTUIPaymentButtonCollectionViewCell
	{
		// @property (nonatomic, strong) UIControl * paymentButton;
		[Export ("paymentButton", ArgumentSemantic.Strong)]
		UIControl PaymentButton { get; set; }
	}

	// @interface BTUIPayPalMonogramCardView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIPayPalMonogramCardView
	{
	}

	// @interface BTUIPayPalWordmarkVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUIPayPalWordmarkVectorArtView
	{
		// @property (nonatomic, strong) BTUI * theme;
		[Export ("theme", ArgumentSemantic.Strong)]
		BTUI Theme { get; set; }
	}

	// @interface BTUIScrollView : UIScrollView
	[BaseType (typeof(UIScrollView))]
	interface BTUIScrollView
	{
		[Wrap ("WeakScrollRectToVisibleDelegate")]
		[NullAllowed]
		BTUIScrollViewScrollRectToVisibleDelegate ScrollRectToVisibleDelegate { get; set; }

		// @property (nonatomic, weak) id<BTUIScrollViewScrollRectToVisibleDelegate> _Nullable scrollRectToVisibleDelegate;
		[NullAllowed, Export ("scrollRectToVisibleDelegate", ArgumentSemantic.Weak)]
		NSObject WeakScrollRectToVisibleDelegate { get; set; }

		// -(void)defaultScrollRectToVisible:(CGRect)rect animated:(BOOL)animated;
		[Export ("defaultScrollRectToVisible:animated:")]
		void DefaultScrollRectToVisible (CGRect rect, bool animated);
	}

	// @protocol BTUIScrollViewScrollRectToVisibleDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface BTUIScrollViewScrollRectToVisibleDelegate
	{
		// @required -(void)scrollView:(BTUIScrollView *)scrollView requestsScrollRectToVisible:(CGRect)rect animated:(BOOL)animated;
		[Abstract]
		[Export ("scrollView:requestsScrollRectToVisible:animated:")]
		void RequestsScrollRectToVisible (BTUIScrollView scrollView, CGRect rect, bool animated);
	}

	// @interface BTUIUnknownCardVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIUnknownCardVectorArtView
	{
	}

	// @interface BTUIUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUIUtil
	{
		// +(BOOL)luhnValid:(NSString *)cardNumber;
		[Static]
		[Export ("luhnValid:")]
		bool LuhnValid (string cardNumber);

		// +(NSString *)stripNonDigits:(NSString *)input;
		[Static]
		[Export ("stripNonDigits:")]
		string StripNonDigits (string input);

		// +(NSString *)stripNonExpiry:(NSString *)input;
		[Static]
		[Export ("stripNonExpiry:")]
		string StripNonExpiry (string input);
	}

	// @interface BTUIVenmoMonogramCardView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIVenmoMonogramCardView
	{
	}

	// @interface BTUIVenmoWordmarkVectorArtView : BTUIVectorArtView
	[BaseType (typeof(BTUIVectorArtView))]
	interface BTUIVenmoWordmarkVectorArtView
	{
		// @property (nonatomic, strong) UIColor * color;
		[Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }
	}

	// @interface BTUIViewUtil : NSObject
	[BaseType (typeof(NSObject))]
	interface BTUIViewUtil
	{
		// +(BTUIPaymentOptionType)paymentMethodTypeForCardType:(BTUICardType *)cardType;
		[Static]
		[Export ("paymentMethodTypeForCardType:")]
		BTUIPaymentOptionType PaymentMethodTypeForCardType (BTUICardType cardType);

		// +(NSString *)nameForPaymentMethodType:(BTUIPaymentOptionType)paymentMethodType;
		[Static]
		[Export ("nameForPaymentMethodType:")]
		string NameForPaymentMethodType (BTUIPaymentOptionType paymentMethodType);

		// +(void)vibrate;
		[Static]
		[Export ("vibrate")]
		void Vibrate ();
	}

	// @interface BTUIVisaVectorArtView : BTUICardVectorArtView
	[BaseType (typeof(BTUICardVectorArtView))]
	interface BTUIVisaVectorArtView
	{
	}

	// @interface BTURLUtils : NSObject
	[BaseType (typeof(NSObject))]
	interface BTURLUtils
	{
		// +(NSURL *)URLfromURL:(NSURL *)URL withAppendedQueryDictionary:(NSDictionary *)dictionary;
		[Static]
		[Export ("URLfromURL:withAppendedQueryDictionary:")]
		NSUrl URLfromURL (NSUrl URL, NSDictionary dictionary);

		// +(NSString *)queryStringWithDictionary:(NSDictionary *)dict;
		[Static]
		[Export ("queryStringWithDictionary:")]
		string QueryStringWithDictionary (NSDictionary dict);

		// +(NSDictionary *)dictionaryForQueryString:(NSString *)queryString;
		[Static]
		[Export ("dictionaryForQueryString:")]
		NSDictionary DictionaryForQueryString (string queryString);
	}

	// @protocol DeviceCollectorSDKDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface DeviceCollectorSDKDelegate
	{
		// @optional -(void)onCollectorStart;
		[Export ("onCollectorStart")]
		void OnCollectorStart ();

		// @optional -(void)onCollectorSuccess;
		[Export ("onCollectorSuccess")]
		void OnCollectorSuccess ();

		// @optional -(void)onCollectorError:(int)errorCode withError:(NSError *)error;
		[Export ("onCollectorError:withError:")]
		void OnCollectorError (int errorCode, NSError error);
	}

	// @interface DeviceCollectorSDK : NSObject <UIWebViewDelegate>
	[BaseType (typeof(NSObject))]
	interface DeviceCollectorSDK : IUIWebViewDelegate
	{
		// @property (nonatomic, strong) NSArray * skipList;
		[Export ("skipList", ArgumentSemantic.Strong)]
		NSObject[] SkipList { get; set; }

		// -(DeviceCollectorSDK *)initWithDebugOn:(_Bool)debugLogging;
		[Export ("initWithDebugOn:")]
		IntPtr Constructor (bool debugLogging);

		// -(void)setCollectorUrl:(NSString *)url;
		[Export ("setCollectorUrl:")]
		void SetCollectorUrl (string url);

		// -(void)setMerchantId:(NSString *)merc;
		[Export ("setMerchantId:")]
		void SetMerchantId (string merc);

		// -(void)collect:(NSString *)sessionId;
		[Export ("collect:")]
		void Collect (string sessionId);

		// -(void)setDelegate:(id<DeviceCollectorSDKDelegate>)delegate;
		[Export ("setDelegate:")]
		void SetDelegate (DeviceCollectorSDKDelegate @delegate);
	}
}
