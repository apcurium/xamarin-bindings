using System;
using ObjCRuntime;

namespace Braintree
{
	[Native]
	public enum BTClientMetadataSourceType : long
	{
		Unknown = 0,
		PayPalApp,
		PayPalBrowser,
		VenmoApp,
		Form
	}

	[Native]
	public enum BTClientMetadataIntegrationType : long
	{
		Custom,
		DropIn,
		Unknown
	}

	[Native]
	public enum BTJSONErrorCode : long
	{
		ValueUnknown = 0,
		ValueInvalid = 1,
		AccessInvalid = 2
	}

	[Native]
	public enum BTAPIClientErrorType : long
	{
		Unknown = 0,
		ConfigurationUnavailable
	}

	[Native]
	public enum BTAppSwitchTarget : long
	{
		Unknown = 0,
		NativeApp,
		WebBrowser
	}

	[Native]
	public enum BTClientTokenError : long
	{
		Unknown = 0,
		Invalid,
		UnsupportedVersion
	}

	[Native]
	public enum BTError : long
	{
		Unknown = 0,
		CustomerInputInvalid
	}

	[Native]
	public enum BTHTTPErrorCode : long
	{
		Unknown = 0,
		ResponseContentTypeNotAcceptable,
		ClientError,
		ServerError,
		MissingBaseURL
	}

	[Native]
	public enum BTLogLevel : ulong
	{
		None = 0,
		Critical = 1,
		Error = 2,
		Warning = 3,
		Info = 4,
		Debug = 5
	}

	[Native]
	public enum BTTokenizationServiceError : long
	{
		Unknown = 0,
		TypeNotRegistered
	}

	[Native]
	public enum BTCardNetwork : long
	{
		Unknown = 0,
		Amex,
		DinersClub,
		Discover,
		MasterCard,
		Visa,
		Jcb,
		Laser,
		Maestro,
		UnionPay,
		Solo,
		Switch,
		UKMaestro
	}

	[Native]
	public enum BTCardClientErrorType : long
	{
		Unknown = 0,
		Integration
	}

	[Native]
	public enum BTThreeDSecureErrorType : long
	{
		Unknown = 0,
		FailedLookup,
		FailedAuthentication,
		Integration
	}

	[Native]
	public enum BTApplePayErrorType : long
	{
		Unknown = 0,
		Unsupported,
		Integration
	}

	[Native]
	public enum BTDataCollectorEnvironment : long
	{
		Development,
		Qa,
		Sandbox,
		Production
	}

	[Native]
	public enum BTPayPalDriverErrorType : long
	{
		Unknown = 0,
		Disabled,
		IntegrationReturnURLScheme,
		AppSwitchFailed,
		InvalidConfiguration,
		InvalidRequest,
		Integration
	}

	[Native]
	public enum BTUIPaymentOptionType : long
	{
		Unknown = 0,
		Amex,
		DinersClub,
		Discover,
		MasterCard,
		Visa,
		Jcb,
		Laser,
		Maestro,
		UnionPay,
		Solo,
		Switch,
		UKMaestro,
		PayPal,
		Coinbase,
		Venmo
	}

	[Native]
	public enum BTUICardFormOptionalFields : ulong
	{
		None = 0,
		Cvv = 1 << 0,
		PostalCode = 1 << 1,
		All = Cvv | PostalCode
	}

	[Native]
	public enum BTUICardFormField : ulong
	{
		Number = 0,
		Expiration,
		Cvv,
		PostalCode
	}

	[Native]
	public enum BTCardHintDisplayMode : long
	{
		ardType,
		VVHint
	}

	[Native]
	public enum BTDropInContentViewStateType : ulong
	{
		Form = 0,
		PaymentMethodsOnFile,
		Activity
	}

	[Native]
	public enum PayPalOneTouchRequestTarget : ulong
	{
		None,
		Browser,
		OnDeviceApplication,
		Unknown
	}

	[Native]
	public enum PayPalOneTouchErrorCode : ulong
	{
		Unknown = 1000,
		ParsingFailed = 1001,
		NoTargetAppFound = 1002,
		OpenURLFailed = 1003
	}

	[Native]
	public enum PayPalOneTouchResultType : ulong
	{
		Error,
		Cancel,
		Success
	}

	[Native]
	public enum BTThreeDSecureViewControllerCompletionStatus : long
	{
		Failure = 0,
		Success
	}
}
