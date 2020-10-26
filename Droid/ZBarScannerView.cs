using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Hardware;
using Android.OS;
using Android.Text;
using Java.Lang;
using Java.Nio.Charset;
using ME.Dm7.Barcodescanner.Core;
//using Android.Util;
using Net.Sourceforge.Zbar;
using Xamarin.Forms;
using static ZBarBindings.Example.Droid.ZBarScannerView;
using Image = Net.Sourceforge.Zbar.Image;

namespace ZBarBindings.Example.Droid
{
    public class ZBarScannerView : ME.Dm7.Barcodescanner.Core.BarcodeScannerView
    {

        private static string TAG = "ZBarScannerView";

        public interface ResultHandler
        {
            void handleResult(Result rawResult);
        }

        private ImageScanner mScanner;
        private List<BarcodeFormat> mFormats;
        private ResultHandler mResultHandler;

        public ZBarScannerView(Context context) : base(context)
        {
            setupScanner();
        }

        public ZBarScannerView(Context context, Android.Util.IAttributeSet attributeSet) : base(context, attributeSet)
        {

            setupScanner();
        }

        public void setFormats(List<BarcodeFormat> formats)
        {
            mFormats = formats;
            setupScanner();
        }

        public void setResultHandler(ResultHandler resultHandler)
        {
            mResultHandler = resultHandler;
        }

        public ICollection<BarcodeFormat> getFormats()
        {
            if (mFormats == null)
            {
                return BarcodeFormat.ALL_FORMATS;
            }
            return mFormats;
        }

        public void setupScanner()
        {
            mScanner = new ImageScanner();
            mScanner.SetConfig(0, Config.XDensity, 3);
            mScanner.SetConfig(0, Config.YDensity, 3);

            mScanner.SetConfig(Symbol.None, Config.Enable, 0);
            foreach (var format in getFormats())
            {
                mScanner.SetConfig(format.Id, Config.Enable, 1);
            }
        }

        public override void OnPreviewFrame(byte[] data, Android.Hardware.Camera camera)
        {

            if (mResultHandler == null)
            {
                return;
            }

            try
            {
                Camera.Parameters parameters = camera.GetParameters();
                parameters.FocusMode = Camera.Parameters.FocusModeContinuousPicture;

                Camera.Size size = parameters.PreviewSize;
                int width = size.Width;
                int height = size.Height;

                if (DisplayUtils.GetScreenOrientation(Context) == (int)Android.Content.Res.Orientation.Portrait)
                {
                    int rotationCount = this.RotationCount;
                    if (rotationCount == 1 || rotationCount == 3)
                    {
                        int tmp = width;
                        width = height;
                        height = tmp;
                    }
                    data = GetRotatedData(data, camera);
                }

                Android.Graphics.Rect rect = GetFramingRectInPreview(width, height);
                Image barcode = new Image(width, height, "Y800");
                barcode.SetData(data);
                barcode.SetCrop(rect.Left, rect.Top, rect.Width(), rect.Height());

                int result = mScanner.ScanImage(barcode);

                if (result != 0)
                {
                    SymbolSet syms = mScanner.Results;
                    Result rawResult = new Result();
                    foreach (Symbol sym in syms.ToArray())
                    {
                        // In order to retreive QR codes containing null bytes we need to
                        // use getDataBytes() rather than getData() which uses C strings.
                        // Weirdly ZBar transforms all data to UTF-8, even the data returned
                        // by getDataBytes() so we have to decode it as UTF-8.
                        string symData;
                        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.Build.VERSION_CODES.Kitkat)
                        {
                            symData = new Java.Lang.String(sym.GetDataBytes(), StandardCharsets.Utf8).ToString();
                        }
                        else
                        {
                            symData = sym.Data;
                        }
                        if (!TextUtils.IsEmpty(symData))
                        {
                            rawResult.Contents = symData;
                            rawResult.BarcodeFormat = BarcodeFormat.getFormatById(sym.Type);
                            break;
                        }
                    }

                    Handler handler = new Handler(Looper.MainLooper);
                    handler.Post(new Runnable(() =>
                    {
                        // Stopping the preview can take a little long.
                        // So we want to set result handler to null to discard subsequent calls to
                        // onPreviewFrame.
                        ResultHandler tmpResultHandler = mResultHandler;
                        mResultHandler = null;

                        StopCameraPreview();
                        if (tmpResultHandler != null)
                        {
                            tmpResultHandler.handleResult(rawResult);
                        }
                    }));
                }
                else
                {
                    camera.SetOneShotPreviewCallback(this);
                }
            }
            catch (RuntimeException e)
            {
                // TODO: Terrible hack. It is possible that this method is invoked after camera is released.
                //Log.e(TAG, e.toString(), e);
            }
        }

        public void resumeCameraPreview(ResultHandler resultHandler)
        {
            mResultHandler = resultHandler;
            base.ResumeCameraPreview();
        }



    }
}
