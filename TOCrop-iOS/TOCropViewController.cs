using System;
using System.Threading.Tasks;
using UIKit;

namespace TOCrop
{
    public partial class TOCropViewController
    {
        /// <summary>
        /// Shows the crop view async.
        /// </summary>
        /// <returns>The crop view async.</returns>
        /// <param name="rootViewController">Root view controller.</param>
        /// <param name="isAnimated">If set to <c>true</c> is animated.</param>
        /// <param name="completionHandler">Completion handler.</param>
        public Task<byte[]> ShowCropViewAsync(UIViewController rootViewController, bool isAnimated, Action completionHandler)
        {
            var cropViewDelegate = new CropViewControllerDelegate();
            this.Delegate = cropViewDelegate;
            rootViewController.PresentViewController(this, isAnimated, completionHandler);

            return cropViewDelegate.GetResult();
        }
    }
}

