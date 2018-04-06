using System;
using System.Drawing;
using AVFoundation;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace ZBarBindings.iOS
{
    // The first step to creating a binding is to add your native library ("libNativeLibrary.a")
    // to the project by right-clicking (or Control-clicking) the folder containing this source
    // file and clicking "Add files..." and then simply select the native library (or libraries)
    // that you want to bind.
    //
    // When you do that, you'll notice that MonoDevelop generates a code-behind file for each
    // native library which will contain a [LinkWith] attribute. MonoDevelop auto-detects the
    // architectures that the native library supports and fills in that information for you,
    // however, it cannot auto-detect any Frameworks or other system libraries that the
    // native library may depend on, so you'll need to fill in that information yourself.
    //
    // Once you've done that, you're ready to move on to binding the API...
    //
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, int index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     IntPtr Constructor (ElmoMuppet elmo);
    //
    // For more information, see http://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/
    //

    /*******************************************************************************
        ZBarSymbol
        
        MonoTouch wrapper for Obj-C wrapper for ZBar result types
    */

    // @interface ZBarSymbol : NSObject
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ZBarSymbol
    {
        // @property (readonly, nonatomic) int type;
        [Export("type")]
        int Type { get; set; }

        // @property (readonly, nonatomic) NSString * typeName;
        [Export("typeName")]
        string TypeName { get; set; }

        // @property (readonly, nonatomic) NSUInteger configMask;
        [Export("configMask")]
        nuint ConfigMask { get; set; }

        // @property (readonly, nonatomic) NSUInteger modifierMask;
        [Export("modifierMask")]
        nuint ModifierMask { get; set; }

        // @property (readonly, nonatomic) NSString * data;
        [Export("data")]
        string Data { get; set; }

        // @property (readonly, nonatomic) int quality;
        [Export("quality")]
        int Quality { get; set; }

        // @property (readonly, nonatomic) int count;
        [Export("count")]
        int Count { get; set; }

        // @property (readonly, nonatomic) int orientation;
        [Export("orientation")]
        int Orientation { get; set; }

        // @property (readonly, nonatomic) ZBarSymbolSet * components;
        [Export("components")]
        ZBarSymbolSet Components { get; set; }

        // @property (readonly, nonatomic) const int * zbarSymbol;
        //[Export("zbarSymbol")]
        //unsafe int* ZbarSymbol { get; set; }

        // @property (readonly, nonatomic) CGRect bounds;
        [Export("bounds")]
        CGRect Bounds { get; set; }

        // -(id)initWithSymbol:(id)symbol;
        //[Export("initWithSymbol:")]
        //IntPtr Constructor(NSObject symbol);

        // +(NSString *)nameForType:(id)type;
        [Static]
        [Export("nameForType:")]
        string NameForType(NSObject type);
    }

    /*******************************************************************************
        ZBarSymbolSet
        
        MonoTouch wrapper for Obj-C wrapper for ZBar result types
    */

    // @interface ZBarSymbolSet : NSObject <NSFastEnumeration>
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ZBarSymbolSet
    {
        // @property (readonly, nonatomic) int count;
        [Export("count")]
        int Count { get; }

        // @property (readonly, nonatomic) const zbar_symbol_set_t *zbarSymbolSet;
        [Export("zbarSymbolSet")]
        IntPtr InnerNativeSymbolSetHandle { get; }

        // @property (nonatomic) BOOL filterSymbols;
        [Export("filterSymbols")]
        bool FilterEnabled { get; set; }

        // -(NSArray *)toArray;
        [Export("toArray")]
        ZBarSymbol[] ToArray { get; }
    }

    // @interface ZBarReaderController : UIImagePickerController <UINavigationControllerDelegate, UIImagePickerControllerDelegate>
    [Protocol]
    [BaseType(typeof(UIImagePickerController))]
    interface ZBarReaderController : IUINavigationControllerDelegate, IUIImagePickerControllerDelegate
    {
        // @property (readonly, nonatomic) ZBarImageScanner * scanner;
        [Export("scanner")]
        ZBarImageScanner Scanner { get; }

        //[Wrap("WeakReaderDelegate")]
        //ZBarReaderDelegate ReaderDelegate { get; set; }

        // @property (assign, nonatomic) id<ZBarReaderDelegate> readerDelegate;
        [NullAllowed, Export("readerDelegate", ArgumentSemantic.Assign)]
        NSObject WeakReaderDelegate { get; set; }

        // @property (nonatomic) BOOL showsZBarControls;
        [Export("showsZBarControls")]
        bool ShowsZBarControls { get; set; }

        // @property (nonatomic) BOOL showsHelpOnFail;
        [Export("showsHelpOnFail")]
        bool ShowsHelpOnFail { get; set; }

        // @property (nonatomic) ZBarReaderControllerCameraMode cameraMode;
        [Export("cameraMode", ArgumentSemantic.Assign)]
        ZBarReaderControllerCameraMode CameraMode { get; set; }

        // @property (nonatomic) BOOL tracksSymbols;
        [Export("tracksSymbols")]
        bool TracksSymbols { get; set; }

        // @property (nonatomic) BOOL takesPicture;
        [Export("takesPicture")]
        bool TakesPicture { get; set; }

        // @property (nonatomic) BOOL enableCache;
        [Export("enableCache")]
        bool EnableCache { get; set; }

        // @property (nonatomic) CGRect scanCrop;
        [Export("scanCrop", ArgumentSemantic.Assign)]
        CGRect ScanCrop { get; set; }

        // @property (nonatomic) NSInteger maxScanDimension;
        [Export("maxScanDimension")]
        nint MaxScanDimension { get; set; }

        // -(void)showHelpWithReason:(NSString *)reason;
        [Export("showHelpWithReason:")]
        void ShowHelpWithReason(string reason);

        // -(id<NSFastEnumeration>)scanImage:(CGImageRef)image;
        //[Export("scanImage:")]
        //unsafe NSFastEnumeration ScanImage(CGImageRef* image);
    }

// @protocol ZBarReaderDelegate <UIImagePickerControllerDelegate>
    [Protocol, Model]
    interface ZBarReaderDelegate : IUIImagePickerControllerDelegate
    {
        // @optional -(void)readerControllerDidFailToRead:(ZBarReaderController *)reader withRetry:(BOOL)retry;
        [Export("readerControllerDidFailToRead:withRetry:")]
        void WithRetry(ZBarReaderController reader, bool retry);
    }

    // @interface ZBarReaderViewController : UIViewController
    [Protocol]
    [BaseType(typeof(UIViewController))]
    interface ZBarReaderViewController
    {
        // @property (readonly, nonatomic) ZBarImageScanner * scanner;
        [Export("scanner")]
        ZBarImageScanner Scanner { get; }

        //[Wrap("WeakReaderDelegate")]
        //ZBarReaderDelegate ReaderDelegate { get; set; }

        // @property (assign, nonatomic) id<ZBarReaderDelegate> readerDelegate;
        [NullAllowed, Export("readerDelegate", ArgumentSemantic.Assign)]
        NSObject WeakReaderDelegate { get; set; }

        // @property (nonatomic) BOOL showsZBarControls;
        [Export("showsZBarControls")]
        bool ShowsZBarControls { get; set; }

        // @property (nonatomic) BOOL tracksSymbols;
        [Export("tracksSymbols")]
        bool TracksSymbols { get; set; }

        // @property (nonatomic) NSUInteger supportedOrientationsMask;
        [Export("supportedOrientationsMask")]
        nuint SupportedOrientationsMask { get; set; }

        // @property (nonatomic) CGRect scanCrop;
        [Export("scanCrop", ArgumentSemantic.Assign)]
        CGRect ScanCrop { get; set; }

        // @property (retain, nonatomic) UIView * cameraOverlayView;
        [Export("cameraOverlayView", ArgumentSemantic.Retain)]
        UIView CameraOverlayView { get; set; }

        // @property (nonatomic) CGAffineTransform cameraViewTransform;
        [Export("cameraViewTransform", ArgumentSemantic.Assign)]
        CGAffineTransform CameraViewTransform { get; set; }

        // -(void)showHelpWithReason:(NSString *)reason;
        [Export("showHelpWithReason:")]
        void ShowHelpWithReason(string reason);

        // -(void)takePicture;
        [Export("takePicture")]
        void TakePicture();

        // +(BOOL)isCameraDeviceAvailable:(UIImagePickerControllerCameraDevice)cameraDevice;
        [Static]
        [Export("isCameraDeviceAvailable:")]
        bool IsCameraDeviceAvailable(UIImagePickerControllerCameraDevice cameraDevice);

        // +(BOOL)isFlashAvailableForCameraDevice:(UIImagePickerControllerCameraDevice)cameraDevice;
        [Static]
        [Export("isFlashAvailableForCameraDevice:")]
        bool IsFlashAvailableForCameraDevice(UIImagePickerControllerCameraDevice cameraDevice);

        // +(NSArray *)availableCaptureModesForCameraDevice:(UIImagePickerControllerCameraDevice)cameraDevice;
        [Static]
        [Export("availableCaptureModesForCameraDevice:")]
        //[Verify(StronglyTypedNSArray)]
        NSObject[] AvailableCaptureModesForCameraDevice(UIImagePickerControllerCameraDevice cameraDevice);

        // @property (nonatomic) UIImagePickerControllerCameraDevice cameraDevice;
        [Export("cameraDevice", ArgumentSemantic.Assign)]
        UIImagePickerControllerCameraDevice CameraDevice { get; set; }

        // @property (nonatomic) UIImagePickerControllerCameraFlashMode cameraFlashMode;
        [Export("cameraFlashMode", ArgumentSemantic.Assign)]
        UIImagePickerControllerCameraFlashMode CameraFlashMode { get; set; }

        // @property (nonatomic) UIImagePickerControllerCameraCaptureMode cameraCaptureMode;
        [Export("cameraCaptureMode", ArgumentSemantic.Assign)]
        UIImagePickerControllerCameraCaptureMode CameraCaptureMode { get; set; }

        // @property (nonatomic) UIImagePickerControllerQualityType videoQuality;
        [Export("videoQuality", ArgumentSemantic.Assign)]
        UIImagePickerControllerQualityType VideoQuality { get; set; }

        // @property (readonly, nonatomic) ZBarReaderView * readerView;
        [Export("readerView")]
        ZBarReaderView ReaderView { get; }

        // @property (nonatomic) BOOL enableCache;
        [Export("enableCache")]
        bool EnableCache { get; set; }

        // @property (nonatomic) UIImagePickerControllerSourceType sourceType;
        [Export("sourceType", ArgumentSemantic.Assign)]
        UIImagePickerControllerSourceType SourceType { get; set; }

        // @property (nonatomic) BOOL allowsEditing;
        [Export("allowsEditing")]
        bool AllowsEditing { get; set; }

        // @property (nonatomic) BOOL allowsImageEditing;
        [Export("allowsImageEditing")]
        bool AllowsImageEditing { get; set; }

        // @property (nonatomic) BOOL showsCameraControls;
        [Export("showsCameraControls")]
        bool ShowsCameraControls { get; set; }

        // @property (nonatomic) BOOL showsHelpOnFail;
        [Export("showsHelpOnFail")]
        bool ShowsHelpOnFail { get; set; }

        // @property (nonatomic) ZBarReaderControllerCameraMode cameraMode;
        [Export("cameraMode", ArgumentSemantic.Assign)]
        ZBarReaderControllerCameraMode CameraMode { get; set; }

        // @property (nonatomic) BOOL takesPicture;
        [Export("takesPicture")]
        bool TakesPicture { get; set; }

        // @property (nonatomic) NSInteger maxScanDimension;
        [Export("maxScanDimension")]
        nint MaxScanDimension { get; set; }

        // +(BOOL)isSourceTypeAvailable:(UIImagePickerControllerSourceType)sourceType;
        [Static]
        [Export("isSourceTypeAvailable:")]
        bool IsSourceTypeAvailable(UIImagePickerControllerSourceType sourceType);
    }

    // @interface ZBarImage : NSObject
    //[BaseType(typeof(NSObject))]
    //interface ZBarImage
    //{
    //    // @property (nonatomic) unsigned long format;
    //    [Export("format")]
    //    nuint Format { }

    //    // @property (nonatomic) unsigned int sequence;
    //    [Export("sequence")]
    //    uint Sequence { }

    //    // @property (nonatomic) CGSize size;
    //    [Export("size", ArgumentSemantic.Assign)]
    //    CGSize Size { }

    //    // @property (nonatomic) CGRect crop;
    //    [Export("crop", ArgumentSemantic.Assign)]
    //    CGRect Crop { }

    //    // @property (readonly, nonatomic) const void * data;
    //    [Export("data")]
    //    unsafe void* Data { }

    //    // @property (readonly, nonatomic) unsigned long dataLength;
    //    [Export("dataLength")]
    //    nuint DataLength { }

    //    // @property (copy, nonatomic) ZBarSymbolSet * symbols;
    //    [Export("symbols", ArgumentSemantic.Copy)]
    //    ZBarSymbolSet Symbols { }

    //    // @property (readonly, nonatomic) int * zbarImage;
    //    [Export("zbarImage")]
    //    unsafe int* ZbarImage { }

    //    // @property (readonly, nonatomic) UIImage * UIImage;
    //    [Export("UIImage")]
    //    UIImage UIImage { }

    //    // -(id)initWithImage:(id)image;
    //    [Export("initWithImage:")]
    //    IntPtr Constructor(NSObject image);

    //    // -(id)initWithCGImage:(CGImageRef)image;
    //    [Export("initWithCGImage:")]
    //    unsafe IntPtr Constructor(CGImageRef* image);

    //    // -(id)initWithCGImage:(CGImageRef)image size:(CGSize)size;
    //    [Export("initWithCGImage:size:")]
    //    unsafe IntPtr Constructor(CGImageRef* image, CGSize size);

    //    // -(id)initWithCGImage:(CGImageRef)image crop:(CGRect)crop size:(CGSize)size;
    //    [Export("initWithCGImage:crop:size:")]
    //    unsafe IntPtr Constructor(CGImageRef* image, CGRect crop, CGSize size);

    //    // -(void)setData:(const void *)data withLength:(unsigned long)length;
    //    [Export("setData:withLength:")]
    //    unsafe void SetData(void* data, nuint length);

    //    // -(UIImage *)UIImageWithOrientation:(UIImageOrientation)imageOrientation;
    //    [Export("UIImageWithOrientation:")]
    //    UIImage UIImageWithOrientation(UIImageOrientation imageOrientation);

    //    // -(void)cleanup;
    //    [Export("cleanup")]
    //    void Cleanup();

    //    // +(unsigned long)fourcc:(NSString *)format;
    //    [Static]
    //    [Export("fourcc:")]
    //    nuint Fourcc(string format);
    //}

    // @interface ZBarImageScanner : NSObject
    [Protocol]
    [BaseType(typeof(NSObject))]
    interface ZBarImageScanner
    {
        // @property (nonatomic) BOOL enableCache;
        [Export("enableCache")]
        bool EnableCache { get; set; }

        // @property (readonly, nonatomic) ZBarSymbolSet * results;
        [Export("results")]
        ZBarSymbolSet Results { get; set; }

        // -(void)parseConfig:(NSString *)configStr;
        [Export("parseConfig:")]
        void ParseConfig(string configStr);

        // -(void)setSymbology:(id)symbology config:(id)config to:(int)value;
        [Export("setSymbology:config:to:")]
        void SetSymbology(NSObject symbology, NSObject config, int value);

        // -(NSInteger)scanImage:(ZBarImage *)image;
        //[Export("scanImage:")]
        //nint ScanImage(ZBarImage image);
    }

    // @protocol ZBarReaderViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface ZBarReaderViewDelegate
    {
        // @required -(void)readerView:(ZBarReaderView *)readerView didReadSymbols:(ZBarSymbolSet *)symbols fromImage:(UIImage *)image;
        [Abstract]
        [Export("readerView:didReadSymbols:fromImage:")]
        void ReaderView(ZBarReaderView readerView, ZBarSymbolSet symbols, UIImage image);

        // @optional -(void)readerViewDidStart:(ZBarReaderView *)readerView;
        [Export("readerViewDidStart:")]
        void ReaderViewDidStart(ZBarReaderView readerView);

        // @optional -(void)readerView:(ZBarReaderView *)readerView didStopWithError:(NSError *)error;
        [Export("readerView:didStopWithError:")]
        void ReaderView(ZBarReaderView readerView, NSError error);
    }

    // @interface ZBarReaderView : UIView
    //[Protocol]
    [BaseType(typeof(UIView))]
    interface ZBarReaderView
    {
        // -(id)initWithImageScanner:(ZBarImageScanner *)imageScanner;
        [Export("initWithImageScanner:")]
        IntPtr Constructor(ZBarImageScanner imageScanner);

        // -(void)start;
        [Export("start")]
        void Start();

        // -(void)stop;
        [Export("stop")]
        void Stop();

        // -(void)flushCache;
        [Export("flushCache")]
        void FlushCache();

        // -(void)willRotateToInterfaceOrientation:(UIInterfaceOrientation)orient duration:(NSTimeInterval)duration;
        [Export("willRotateToInterfaceOrientation:duration:")]
        void WillRotateToInterfaceOrientation(UIInterfaceOrientation orient, double duration);

        [Wrap("WeakReaderDelegate")]
        ZBarReaderViewDelegate ReaderDelegate { get; set; }

        // @property (assign, nonatomic) id<ZBarReaderViewDelegate> readerDelegate;
        [NullAllowed, Export("readerDelegate", ArgumentSemantic.Assign)]
        NSObject WeakReaderDelegate { get; set; }

        // @property (readonly, nonatomic) ZBarImageScanner * scanner;
        [Export("scanner")]
        ZBarImageScanner Scanner { get; }

        // @property (nonatomic) BOOL tracksSymbols;
        [Export("tracksSymbols")]
        bool TracksSymbols { get; set; }

        // @property (retain, nonatomic) UIColor * trackingColor;
        [Export("trackingColor", ArgumentSemantic.Retain)]
        UIColor TrackingColor { get; set; }

        // @property (nonatomic) BOOL allowsPinchZoom;
        [Export("allowsPinchZoom")]
        bool AllowsPinchZoom { get; set; }

        // @property (nonatomic) NSInteger torchMode;
        [Export("torchMode")]
        nint TorchMode { get; set; }

        // @property (nonatomic) BOOL showsFPS;
        [Export("showsFPS")]
        bool ShowsFPS { get; set; }

        // @property (nonatomic) CGFloat zoom;
        [Export("zoom")]
        nfloat Zoom { get; set; }

        // -(void)setZoom:(CGFloat)zoom animated:(BOOL)animated;
        [Export("setZoom:animated:")]
        void SetZoom(nfloat zoom, bool animated);

        // @property (nonatomic) CGFloat maxZoom;
        [Export("maxZoom")]
        nfloat MaxZoom { get; set; }

        // @property (nonatomic) CGRect scanCrop;
        [Export("scanCrop", ArgumentSemantic.Assign)]
        CGRect ScanCrop { get; set; }

        // @property (nonatomic) CGAffineTransform previewTransform;
        [Export("previewTransform", ArgumentSemantic.Assign)]
        CGAffineTransform PreviewTransform { get; set; }

        // @property (retain, nonatomic) AVCaptureDevice * device;
        [Export("device", ArgumentSemantic.Retain)]
        AVCaptureDevice Device { get; set; }

        // @property (readonly, nonatomic) AVCaptureSession * session;
        [Export("session")]
        AVCaptureSession Session { get; }

        // @property (readonly, nonatomic) ZBarCaptureReader * captureReader;
        //[Export("captureReader")]
        //ZBarCaptureReader CaptureReader { get; }

        // @property (nonatomic) BOOL enableCache;
        [Export("enableCache")]
        bool EnableCache { get; set; }
    }
}
