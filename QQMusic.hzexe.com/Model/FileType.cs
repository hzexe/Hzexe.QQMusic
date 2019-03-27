//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using QQMusic.hzexe.com.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Hzexe.QQMusic.Model
{
    /// <summary>
    /// 包含的文件类型
    /// </summary>
    [Flags]
    public enum EnumFileType : int
    {
        [FileType("A000","ape")]
        Ape = 2,
        [FileType("F000", "flac")]
        Flac = 4,
        [FileType("M800", "mp3")]
        Mp3_320k = 8,
        [FileType("M500", "ape")]
        Mp3_128k = 16,
        [FileType("C400", "m4a")]
        M4a = 32,
    }


    public static class EnumFileTypeExt {
        public static U GetFileType<U,T>(this T em)
            where T: System.Enum
            where U: Attribute
        {
            Type type = em.GetType();
            FieldInfo fd = type.GetRuntimeField(em.ToString());
            if (fd == null)
                throw new NotSupportedException();
            U attrs = fd.GetCustomAttribute<U>(false);
            return attrs;
        }

        public static FileTypeAttribute GetFileType(this EnumFileType em)
        {
            return GetFileType<FileTypeAttribute, EnumFileType>(em);
        }

    }


    public interface IFiletype
    {
        string Prefix { get;  }
        string Suffix { get;  }
        int Size { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Ape : IFiletype
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Prefix = "A000";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Suffix="ape";

        public string Prefix { get=> _Prefix;}
        public string Suffix { get=> _Suffix;} 
        public int Size { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Flac : IFiletype
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Prefix = "F000";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Suffix = "flac";

        public string Prefix { get => _Prefix; }
        public string Suffix { get => _Suffix; }
        public int Size { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Mp3_320k : IFiletype
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Prefix = "M800";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Suffix = "mp3";
        public string Prefix { get => _Prefix; }
        public string Suffix { get => _Suffix; }
        public int Size { get; set; }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class Mp3_128k : IFiletype
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Prefix = "M500";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Suffix = "mp3";

        public string Prefix { get => _Prefix; }
        public string Suffix { get => _Suffix; }
        public int Size { get; set; }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class M4a : IFiletype
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Prefix = "C400";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        private string _Suffix = "m4a";

        public string Prefix { get => _Prefix; }
        public string Suffix { get => _Suffix; }
        public int Size { get; set; }
    }


}
