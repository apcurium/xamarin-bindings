using ObjCRuntime;

[assembly: LinkWith (
    "libTOCropViewController.a",
    LinkTarget.Simulator | LinkTarget.Arm64 | LinkTarget.ArmV7, 
    "-ObjC",
    SmartLink = true, 
    ForceLoad = true, 
    IsCxx = true)]
