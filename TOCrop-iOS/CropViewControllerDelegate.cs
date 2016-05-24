using System;
using System.Threading.Tasks;
using UIKit;

namespace TOCrop
{
    public class CropViewControllerDelegate : TOCropViewControllerDelegate
    {
        private readonly TaskCompletionSource<byte[]> _taskCompletionSource;

        public CropViewControllerDelegate()
        {
            _taskCompletionSource = new TaskCompletionSource<byte[]>();
        }

        public override void DidCropToImage(TOCropViewController cropViewController, 
            UIImage image, CoreGraphics.CGRect cropRect, nint angle)
        {
            var imageBytes = image.AsPNG().ToArray();
            _taskCompletionSource.SetResult(imageBytes);

            cropViewController.DismissViewController(true, null);
        }

        public override void DidFinishCancelled(TOCropViewController cropViewController, bool cancelled)
        {
            _taskCompletionSource.SetCanceled();
            cropViewController.DismissViewController(true, null);
        }

        public Task<byte[]> GetResult()
        {
            return _taskCompletionSource.Task;
        }
    }
}

