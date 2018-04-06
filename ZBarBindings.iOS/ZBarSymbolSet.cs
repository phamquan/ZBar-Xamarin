using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ZBarBindings.iOS
{
    //public partial class ZBarSymbolSet : IEnumerable<ZBarSymbol>
    //{
    //    public IEnumerator<ZBarSymbol> GetEnumerator()
    //    {
    //        IntPtr symbol;
    //        if (FilterEnabled)
    //            symbol = zbar_symbol_set_first_symbol(this.InnerNativeSymbolSetHandle);
    //        else
    //            symbol = zbar_symbol_set_first_unfiltered(this.InnerNativeSymbolSetHandle);

    //        while (symbol != IntPtr.Zero)
    //        {
    //            yield return new ZBarSymbol(symbol, 0);
    //            symbol = zbar_symbol_next(symbol);
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    [DllImport("__Internal")]
    //    private extern static IntPtr zbar_symbol_next(IntPtr zBarSymbol);

    //    [DllImport("__Internal")]
    //    private extern static IntPtr zbar_symbol_set_first_symbol(IntPtr zbarSymbolSet);

    //    [DllImport("__Internal")]
    //    private extern static IntPtr zbar_symbol_set_first_unfiltered(IntPtr zbarSymbolSet);
    //}
}
