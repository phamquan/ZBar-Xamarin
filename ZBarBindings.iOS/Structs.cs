using System;

namespace ZBarBindings.iOS
{
    // orientation set support
    // #define ZBarOrientationMask(orient) (1 << orient)
    // #define ZBarOrientationMaskAll \
    //      (ZBarOrientationMask(UIInterfaceOrientationPortrait) | \
    //      ZBarOrientationMask(UIInterfaceOrientationPortraitUpsideDown) | \
    //      ZBarOrientationMask(UIInterfaceOrientationLandscapeLeft) | \
    //      ZBarOrientationMask(UIInterfaceOrientationLandscapeRight))
    //
    //  namespace MonoTouch.UIKit
    //  {
    //      public enum UIInterfaceOrientation
    //      {
    //          Portrait = 1,
    //          PortraitUpsideDown = 2,
    //          LandscapeLeft = 4,
    //          LandscapeRight = 3
    //      }
    //  }
    public enum ZBarOrientation
    {
        Portrait = 2,
        PortraitUpsideDown = 4,
        LandscapeRight = 8,
        LandscapeLeft = 16,
        All = Portrait | PortraitUpsideDown | LandscapeLeft | LandscapeRight
    }
    
    // /** decoded symbol type. */
    //  typedef enum zbar_symbol_type_e {
    //    ZBAR_NONE        =      0,  /**< no symbol decoded */
    //    ZBAR_PARTIAL     =      1,  /**< intermediate status */
    //    ZBAR_EAN2        =      2,  /**< GS1 2-digit add-on */
    //    ZBAR_EAN5        =      5,  /**< GS1 5-digit add-on */
    //    ZBAR_EAN8        =      8,  /**< EAN-8 */
    //    ZBAR_UPCE        =      9,  /**< UPC-E */
    //    ZBAR_ISBN10      =     10,  /**< ISBN-10 (from EAN-13). @since 0.4 */
    //    ZBAR_UPCA        =     12,  /**< UPC-A */
    //    ZBAR_EAN13       =     13,  /**< EAN-13 */
    //    ZBAR_ISBN13      =     14,  /**< ISBN-13 (from EAN-13). @since 0.4 */
    //    ZBAR_COMPOSITE   =     15,  /**< EAN/UPC composite */
    //    ZBAR_I25         =     25,  /**< Interleaved 2 of 5. @since 0.4 */
    //    ZBAR_DATABAR     =     34,  /**< GS1 DataBar (RSS). @since 0.11 */
    //    ZBAR_DATABAR_EXP =     35,  /**< GS1 DataBar Expanded. @since 0.11 */
    //    ZBAR_CODE39      =     39,  /**< Code 39. @since 0.4 */
    //    ZBAR_PDF417      =     57,  /**< PDF417. @since 0.6 */
    //    ZBAR_QRCODE      =     64,  /**< QR Code. @since 0.10 */
    //    ZBAR_CODE93      =     93,  /**< Code 93. @since 0.11 */
    //    ZBAR_CODE128     =    128,  /**< Code 128 */
    //
    //} zbar_symbol_type_t;
    public enum ZBarSymbolType
    {
        All             = 0,
        Partial         = 1,
        EAN2            = 2,
        EAN5            = 5,
        EAN8            = 8,
        UPCE            = 9,
        ISBN10          = 10,
        UPCA            = 12,
        EAN13           = 13,
        ISBN13          = 14,
        COMPOSITE       = 15,
        Interleaved25   = 25,
        DataBar         = 34,
        DataBarExpanded = 35,
        Code39          = 39,
        PDF417          = 57,
        QRCode          = 64,
        Code93          = 93,
        Code128         = 128
    }
    
    //  /** decoded symbol coarse orientation.
    //   * @since 0.11
    //   */
    //  typedef enum zbar_orientation_e {
    //      ZBAR_ORIENT_UNKNOWN = -1,   /**< unable to determine orientation */
    //      ZBAR_ORIENT_UP,             /**< upright, read left to right */
    //      ZBAR_ORIENT_RIGHT,          /**< sideways, read top to bottom */
    //      ZBAR_ORIENT_DOWN,           /**< upside-down, read right to left */
    //      ZBAR_ORIENT_LEFT,           /**< sideways, read bottom to top */
    //  } zbar_orientation_t;
    // public enum ZBarOrientation2
    // {
    //      TODO: This is different to the ZBarOrientation enum above. This one
    //      is used as the detected symbol orientation (output) where as the one
    //      above is used to define what orientations are supported before scanning
    //      (input). Ideally this library will re-use the same enum and provide 
    //      translation as the integer values do no match.
    // }
    
    // /** decoder configuration options.
    // * @since 0.4
    // */
    //  typedef enum zbar_config_e {
    //      ZBAR_CFG_ENABLE = 0,        /**< enable symbology/feature */
    //      ZBAR_CFG_ADD_CHECK,         /**< enable check digit when optional */
    //      ZBAR_CFG_EMIT_CHECK,        /**< return check digit when present */
    //      ZBAR_CFG_ASCII,             /**< enable full ASCII character set */
    //      ZBAR_CFG_NUM,               /**< number of boolean decoder configs */
    //  
    //      ZBAR_CFG_MIN_LEN = 0x20,    /**< minimum data length for valid decode */
    //      ZBAR_CFG_MAX_LEN,           /**< maximum data length for valid decode */
    //  
    //      ZBAR_CFG_UNCERTAINTY = 0x40,/**< required video consistency frames */
    //  
    //      ZBAR_CFG_POSITION = 0x80,   /**< enable scanner to collect position data */
    //  
    //      ZBAR_CFG_X_DENSITY = 0x100, /**< image scanner vertical scan density */
    //      ZBAR_CFG_Y_DENSITY,         /**< image scanner horizontal scan density */
    //  } zbar_config_t;
    public enum ZBarConfig
    {
        Enabled     = 0,
        AddCheck,
        EmitCheck,
        ASCII,
        ConfigCount,
        MinLength   = 0x20,
        MaxLength,
        Uncertainty = 0x40,
        Position    = 0x80,
        XDensity    = 0x100,
        YDensity
    }
    
    //  /** decoder symbology modifier flags.
    //   * @since 0.11
    //   */
    //  typedef enum zbar_modifier_e {
    //      /** barcode tagged as GS1 (EAN.UCC) reserved
    //       * (eg, FNC1 before first data character).
    //       * data may be parsed as a sequence of GS1 AIs
    //       */
    //      ZBAR_MOD_GS1 = 0,
    //  
    //      /** barcode tagged as AIM reserved
    //       * (eg, FNC1 after first character or digit pair)
    //       */
    //      ZBAR_MOD_AIM,
    //  
    //      /** number of modifiers */
    //      ZBAR_MOD_NUM,
    //  } zbar_modifier_t;
    public enum ZBarModifier
    {
        GS1         = 0,
        AIM,
        Number
    }

    public enum ZBarReaderControllerCameraMode : uint
{
    Default = 0,
    Sampling,
    Sequence
}

}
