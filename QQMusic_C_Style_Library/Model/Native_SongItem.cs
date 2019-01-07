using Hzexe.QQMusic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_C_Style_Library.Model
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct Native_SongItem
    {
        [MarshalAs(UnmanagedType.LPStr, SizeConst = 16)]
        public string file_strMediaMid;

        [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
        public string album_name;

        /// <summary>
        /// 多个用逗号分隔
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
        public string singer_name;   //多个用逗号分开

        /// <summary>
        /// 文件类型
        /// </summary>
        [MarshalAs(UnmanagedType.I4, SizeConst = 64)]
        public EnumFileType fileType;   
    }
}
