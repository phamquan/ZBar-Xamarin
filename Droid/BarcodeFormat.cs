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

        public readonly static List<BarcodeFormat> ALL_FORMATS = new List<BarcodeFormat>
        {
            BarcodeFormat.QRCODE
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
