//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;

namespace Hzexe.QQMusic
{
    public class SearchArg : ISearchArg
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 400;
        public string Keywords { get; set; }
    }
}
