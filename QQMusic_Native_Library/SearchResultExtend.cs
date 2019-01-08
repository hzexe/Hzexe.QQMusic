//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using Hzexe.QQMusic.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using QQMusic_C_Style_Library.Model;
using System.Runtime.InteropServices;

namespace QQMusic_C_Style_Library
{
    public static class SearchResultExtend
    {
        /// <summary>
        /// 封装SearchResult到托管字节数组，以避免内存泄露
        /// </summary>
        /// <param name="searchResult"></param>
        /// <returns></returns>
        /// <remarks>结成一个前面是Native_SearchResult后面是Native_SongItem数组的结构</remarks>
        public static byte[] ToBytes(SearchResult searchResult)
        {
            int itemsSize = Marshal.SizeOf(typeof(Native_SongItem));
            int allsize = Marshal.SizeOf(typeof(Native_SearchResult))
                + itemsSize * searchResult.song.list.Count;
            byte[] buff = new byte[allsize];
            unsafe
            {
                fixed (byte* v = &buff[0])
                {
                    int index = 0;
                    IntPtr ptr = new IntPtr(v);
                    WriteTo(searchResult, ptr, ref index);
                }
            }
            return buff;
        }
        public static void WriteTo(SearchResult searchResult, IntPtr dataPtr, ref int offset)
        {
            Model.Native_SearchResult nrt = new Native_SearchResult();
            nrt.curnum = searchResult.song.list.Count();
            nrt.curpage = searchResult.song.curpage;
            nrt.totalnum = searchResult.song.totalnum;
            int itemsSize = Marshal.SizeOf(typeof(Native_SongItem));
            Marshal.StructureToPtr(nrt, dataPtr, false);
            offset += Marshal.SizeOf(typeof(Native_SearchResult));

            var list = searchResult.song.list
                   .Select(x =>
                       new Native_SongItem
                       {
                           album_name = x.album?.name,
                           file_strMediaMid = x.file?.strMediaMid,
                           singer_name = string.Join(",", x.singer.Select(xx => xx.name)),
                           fileType = x.file.GetAvailableFileType(),
                           name=x.name,
                           id=x.id
                       }
                   )
                   .ToList();
            for (int i = 0; i < list.Count; i++)
            {
                IntPtr nptr = dataPtr + offset;
                Marshal.StructureToPtr(list[i], nptr, true);
                offset += itemsSize;
            }
        }

        public static ISongItem ToSongItem(Native_SongItem si)
        {
            return new SongItem()
            {
                album = new Album() { name = si.album_name.RemoveUnicodeEnd() },
                file = new File() { strMediaMid=si.file_strMediaMid.RemoveUnicodeEnd() },
                name=si.name.RemoveUnicodeEnd(),
                title= si.name.RemoveUnicodeEnd(),
                singer = si.singer_name.RemoveUnicodeEnd().Split(',').Select(x=>new Singer2 { name=x}).ToArray(),
            };
        }
        /// <summary>
        /// 去掉marshl unicode字符尾部存在多余字符的情况
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string RemoveUnicodeEnd(this string p)
        {
            if (string.IsNullOrEmpty(p))
                return p;
            var spl = "\u0000";
            int index = p.IndexOf(spl);
            if (index > -1)
                return p.Substring(0, index);
            return p;
        }


        private static EnumFileType GetEnumFileType(IFiletype ft)
        {
            switch (ft.Prefix)
            {
                case "A000":
                    return EnumFileType.Ape;
                case "F000":
                    return EnumFileType.Flac;
                case "M800":
                    return EnumFileType.Mp3_320k;
                case "M500":
                    return EnumFileType.Mp3_128k;
                default:
                    throw new NotImplementedException("未实现的媒体格式");
            }
        }

        private static EnumFileType GetEnumFileType(IEnumerable<IFiletype> fts)
        {
            var items = fts.Select(GetEnumFileType);
            EnumFileType e = items.First();
            items.Skip(1).ToList().ForEach(x => e |= x);
            return e;
        }

    }
}
