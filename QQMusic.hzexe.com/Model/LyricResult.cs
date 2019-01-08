//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;

namespace Hzexe.QQMusic.Model
{
    public class LyricResult
    {
        public int code { get; set; }
        public int? retcode { get; set; }
        public int? subcode { get; set; }
        public string lyric { get; set; }
        public string trans { get; set; }
    }
}
