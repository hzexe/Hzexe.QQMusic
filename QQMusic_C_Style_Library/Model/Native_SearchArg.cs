using Hzexe.QQMusic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_C_Style_Library.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ANative_SearchArg
    {
        public int Page;
        public int PageSize;
        [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
        private string Keywords;
    }
}
