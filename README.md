# Xamarin bindings

## Braintree v.zero iOS and Android SDKs

Documentation for [iOS](https://developers.braintreepayments.com/start/hello-client/ios/v4)  
Documentation for [Android](https://developers.braintreepayments.com/start/hello-client/android/v2)

## Square Register iOS and Android SDKs

Documentation for [iOS](https://docs.connect.squareup.com/articles/register-api-ios/)  
Documentation for [Android](https://docs.connect.squareup.com/articles/register-api-android/)   
Check both SDKs GitHub page for more information on how to make the samples work ([iOS](https://github.com/square/SquareRegisterSDK-iOS) [Android](https://github.com/square/register-android-sdk))

### To create the iOS binding:  
1. Download the code from [GitHub](https://github.com/square/SquareRegisterSDK-iOS)  
2. Build in Release for Device and Simulator  
3. Create a fat binary using lipo with the 2 resulting .frameworks [Source](http://stackoverflow.com/questions/29634466/how-to-export-fat-cocoa-touch-framework-for-simulator-and-device)

  1. Combine these 2 Frameworks using lipo by this script (replace YourFrameworkName to your Framework name)  
    ```sh
    lipo -create -output "YourFrameworkName" "Release-iphonesimulator/YourFrameworkName.framework/YourFrameworkName" "Release-iphoneos/YourFrameworkName.framework/YourFrameworkName"
    ```
  2. Replace with new binary one of the existing frameworks   
    ```sh
    cp -R Release-iphoneos/YourFrameworkName.framework ./YourFrameworkName.framework
    mv YourFrameworkName ./YourFrameworkName.framework/YourFrameworkName
    ```

## TOCropViewController iOS
A view controller that allows users to crop UIImage objects.

TOCropViewController [GitHub](https://github.com/TimOliver/TOCropViewController)

###Sample
```cs
var image = UIImage.FromFile(fileString);

var viewController = new TOCrop.TOCropViewController(image);
var rootViewController = UIApplication.SharedApplication.Delegate.GetWindow().RootViewController;
try
{
  var imageBytes = viewController.ShowCropViewAsync(rootViewController, true, null);
}
catch(TaskCancelException)
{
  // User cancelled the operation
}
```

# License

The MIT License (MIT)

Copyright (c) 2016 Apcurium Group Inc

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
