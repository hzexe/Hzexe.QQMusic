//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_Native_Library.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Native_SearchResult
    {
        public int curnum;
        public int curpage;
        public int totalnum;
    }
    /*
    struct Native_SearchResult{
         int curnum;
    int curpage;
    int totalnum;
    Native_SongItem* Psong;
    }
    */
}
