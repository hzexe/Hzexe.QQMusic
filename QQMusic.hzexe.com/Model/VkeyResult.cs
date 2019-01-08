//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;

namespace Hzexe.QQMusic.Model
{

    public class VkeyItem
    {
        public int subcode { get; set; }
        public string songmid { get; set; }
        public string filename { get; set; }
        public string vkey { get; set; }
    }

    public class VkeyResponse
    {
        public int expiration { get; set; }
        public VkeyItem[] items { get; set; }
    }

}
