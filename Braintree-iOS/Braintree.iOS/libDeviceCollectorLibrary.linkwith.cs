using ObjCRuntime;

[assembly: LinkWith ("libDeviceCollectorLibrary.a", LinkTarget.Simulator 
	| LinkTarget.Simulator64 
	| LinkTarget.Arm64
	| LinkTarget.ArmV7, 
	ForceLoad = true,
	Frameworks = "Accelerate SystemConfiguration Security AudioToolbox CoreLocation AVFoundation CoreMedia Foundation MessageUI MobileCoreServices UIKit",
	IsCxx = true)] 
