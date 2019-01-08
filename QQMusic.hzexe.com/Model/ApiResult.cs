//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;

namespace Hzexe.QQMusic.Model
{
    public class ApiResult<T>
        where T:new()
    {
        public int code { get; set; }
        public T data { get; set; }
        public string message { get; set; }
        public string notice { get; set; }
        public int subcode { get; set; }
        public int time { get; set; }
        public string tips { get; set; }
    }
}
