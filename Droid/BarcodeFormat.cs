using System;
using System.Collections.Generic;
using Net.Sourceforge.Zbar;

namespace ZBarBindings.Example.Droid
{
    public class BarcodeFormat
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public BarcodeFormat(int id, string Name)
        {
            this.Id = id;
            this.Name = Name;
        }

        public readonly static BarcodeFormat NONE  = new BarcodeFormat(Symbol.None, "NONE");

        public readonly static BarcodeFormat QRCODE = new BarcodeFormat(Symbol.Qrcode, "QRCODE");
        public readonly static BarcodeFormat BARCODE_39 = new BarcodeFormat(Symbol.Code39, "CODE39");
        public readonly static BarcodeFormat BARCODE_128 = new BarcodeFormat(Symbol.Code128, "CODE128");

        public readonly static List<BarcodeFormat> ALL_FORMATS = new List<BarcodeFormat>
        {
            BarcodeFormat.QRCODE,
            BarcodeFormat.BARCODE_39,
            BarcodeFormat.BARCODE_128
        };

        public static BarcodeFormat getFormatById(int id)
        {
            foreach (BarcodeFormat format in ALL_FORMATS)
            {
                if (format.Id == id)
                {
                    return format;
                }
            }
            return BarcodeFormat.NONE;
        }
    }
}
