using System;
using Android.Content;
using Android.OS;
using Android.Widget;
using ME.Dm7.Barcodescanner.Core;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ZBarBindings.Example;
using ZBarBindings.Example.Droid;

[assembly: ExportRenderer(typeof(ScannerView), typeof(ScannerViewRenderer))]
namespace ZBarBindings.Example.Droid
{

    public class ScannerViewRenderer : ViewRenderer<ScannerView, ZBarScannerView>, ZBarScannerView.ResultHandler
    {
        ZBarScannerView mScannerView;

        public ScannerViewRenderer(Context context) : base(context)
        {
        }

        public void handleResult(Result rawResult)
        {
            Toast.MakeText(Context, rawResult.Contents, ToastLength.Short).Show();
            var handler = new Handler();
            handler.PostDelayed(() =>
            {
                this.mScannerView.resumeCameraPreview(this);
            }, 2000);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ScannerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                mScannerView = new ZBarScannerView(Context);
                SetNativeControl(mScannerView);
            }
            if (e.OldElement != null)
            {
                // Unsubscribe
                //uiCameraPreview.Tapped -= OnCameraPreviewTapped;
            }
            if (e.NewElement != null)
            {
                // Subscribe
                //uiCameraPreview.Tapped += OnCameraPreviewTapped;
            }
        }

		protected override void OnAttachedToWindow()
		{
            base.OnAttachedToWindow();

            mScannerView.setResultHandler(this);
            mScannerView.StartCamera();
		}

	}
}
