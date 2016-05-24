using System;
using System.Threading.Tasks;
using UIKit;

namespace TOCrop
{
    public partial class TOCropViewController
    {
        /// <summary>
        /// Shows the crop view and wait for the user's input.
        /// </summary>
        /// <returns>Returns a byte array of the cropped photo or throws an OperationCancelledException if the user cancelled.</returns>
        /// <param name="rootViewController">Root view controller.</param>
        /// <param name="isAnimated">If set to <c>true</c> is animated.</param>
        /// <param name="completionHandler">Completion handler.</param>
        /// <exception cref="System.OperationCanceledException">Thrown when the user hits cancel</exception>
        public Task<byte[]> ShowCropViewAsync(UIViewController rootViewController, bool isAnimated, Action completionHandler)
        {
            var cropViewDelegate = new CropViewControllerDelegate();
            this.Delegate = cropViewDelegate;
            rootViewController.PresentViewController(this, isAnimated, completionHandler);

            return cropViewDelegate.GetResult();
        }
    }
}

