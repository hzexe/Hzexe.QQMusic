//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.

using Hzexe.QQMusic;
using Hzexe.QQMusic.Model;
using QQMusic_Native_Library.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_Native_Library
{
    public class Wrapper
    {
        static Wrapper()
        {
            string copy = @"
Copyright by hzexe https://github.com/hzexe
All rights reserved
See the LICENSE file in the project root for more information.
";

            Console.WriteLine(copy);
        }
        static void Main(string[] args)
        {
            
        }

        [NativeCallable(EntryPoint = "test", CallingConvention = CallingConvention.Cdecl)]
        public static IntPtr test()
        {
            return Marshal.StringToHGlobalAnsi("Hello World");

        }

        [NativeCallable(EntryPoint = "SearchMusicByName", CallingConvention = CallingConvention.StdCall)]
        public static bool SearchMusicByName(IntPtr SearchArgPtr, IntPtr testptr)
        {
            return SearchMusicByName_Inside(SearchArgPtr, testptr);
        }

        [NativeCallable(EntryPoint = "DownloadMusic", CallingConvention = CallingConvention.StdCall)]
        public static bool DownloadMusic(IntPtr Native_SongItemPtr, EnumFileType type, IntPtr dirPtr, int dirlength)
        {
            return DownloadMusic_Inside(Native_SongItemPtr, type, dirPtr, dirlength);
        }
       
        public static bool DownloadMusic_Inside(IntPtr Native_SongItemPtr, EnumFileType type, IntPtr dirPtr,int dirlength)
        {
            try
            {
                Native_SongItem nsi = Marshal.PtrToStructure<Native_SongItem>(Native_SongItemPtr);
                string dir = null;
                unsafe {
                    dir = new string((char*)dirPtr.ToPointer(),0,dirlength);
               }
                Console.WriteLine($"准备下载{nsi.name.RemoveUnicodeEnd()}到{dir}");
                //转换
                ISongItem si = SearchResultExtend.ToSongItem(nsi);
                var api = new QQMusicAPI();
                api.downloadSongAsync(si, dir, type).Wait();
                api.downloadLyricAsync(si, dir).Wait();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }


        public static bool SearchMusicByName_Inside(IntPtr SearchArgPtr,IntPtr testptr)
        {
            //Console.WriteLine("SearchArgPtr:{0:X}", SearchArgPtr);
            var api = new QQMusicAPI();
            var searchArg = Marshal.PtrToStructure<ANative_SearchArg>(SearchArgPtr);
            try
            {
                SearchResult result = api.SearchAsync(searchArg).Result;
                int offset = 0;
                SearchResultExtend.WriteTo(result, testptr,ref offset);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
        [NativeCallable(EntryPoint = "testMarshalArray", CallingConvention = CallingConvention.StdCall)]
        public static void testMarshalArray(IntPtr testptr)
        {
            var test = new MarshalArrayTestClass();
            test.abc = new int[] { 1, 2 };
            Marshal.StructureToPtr<MarshalArrayTestClass>(test, testptr, false);

        }


        private static string getJson<T>(T obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public class MarshalArrayTestClass
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public int[] abc;
    }
}