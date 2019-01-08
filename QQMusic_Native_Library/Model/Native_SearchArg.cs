//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using Hzexe.QQMusic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_Native_Library.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class ANative_SearchArg:ISearchArg
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        [MarshalAs(m.t, SizeConst = 64)]
        private string keywords;

        public string Keywords { get => keywords; set => keywords = value; }
    }
}
