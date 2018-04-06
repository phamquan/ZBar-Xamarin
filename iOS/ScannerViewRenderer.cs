using System;
using AVFoundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ZBarBindings.Example;
using ZBarBindings.Example.iOS;
using ZBarBindings.iOS;

[assembly: ExportRenderer(typeof(ScannerView), typeof(ScannerViewRenderer))]
namespace ZBarBindings.Example.iOS
{
    public class ScannerViewRenderer : ViewRenderer<ScannerView, ZBarReaderView>
    {

        ZBarReaderView mScannerView;

        public ScannerViewRenderer() : base()
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ScannerView> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                mScannerView = new ZBarReaderView();
                mScannerView.ReaderDelegate = new xxx();
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

        private class xxx : ZBarReaderViewDelegate
        {
            public override void ReaderView(ZBarReaderView readerView, ZBarSymbolSet symbols, UIImage image)
            {
                try
                {
                    foreach (var sym in symbols.ToArray)
                    {
                        try
                        {
                            //var s = ObjCRuntime.Runtime.GetNSObject<ZBarSymbol>(sym.Handle);
                            System.Diagnostics.Debug.WriteLine(sym.Data);
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("For: " + ex.Message);
                        }
                    }
                }
                catch(Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }


		public override void MovedToWindow()
		{
            base.MovedToWindow();

            mScannerView.ShowsFPS = true;
            var session = mScannerView.Session;
            session.SessionPreset = AVCaptureSession.PresetHigh;
            mScannerView.Start();
		}
	}
}
