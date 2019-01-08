//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.Text;

namespace QQMusic.hzexe.com.Model
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple =false, Inherited = false)]
    public class FileTypeAttribute : Attribute
    {
       public string Prefix { get; set; }
        public string Suffix { get; set; }

        public FileTypeAttribute(string prefix, string suffix)
        {
            Prefix = prefix;
            Suffix = suffix;
        }
    }
}
