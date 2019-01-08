//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using Hzexe.QQMusic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_C_Style_Library.Model
{
    public static class  m{
        public const UnmanagedType t = UnmanagedType.ByValTStr;
    }


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Native_SongItem
    {
        public int id;
        [MarshalAs(m.t, SizeConst = 32)]
        public string file_strMediaMid;

        [MarshalAs(m.t, SizeConst = 64)]
        public string album_name;

        [MarshalAs(m.t, SizeConst = 64)]
        public string name;

        /// <summary>
        /// 多个用逗号分隔
        /// </summary>
        [MarshalAs(m.t, SizeConst = 64)]
        public string singer_name;   //多个用逗号分开

        /// <summary>
        /// 文件类型
        /// </summary>
        [MarshalAs(UnmanagedType.I4)]
        public EnumFileType fileType;   
    }
}
