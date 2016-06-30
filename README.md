# Xamarin bindings

## Braintree v.zero iOS and Android SDKs

Documentation for [iOS](https://developers.braintreepayments.com/start/hello-client/ios/v4)  
Documentation for [Android](https://developers.braintreepayments.com/start/hello-client/android/v2)

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
