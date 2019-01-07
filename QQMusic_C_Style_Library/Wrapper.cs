using Hzexe.QQMusic;
using Hzexe.QQMusic.Model;
using QQMusic_C_Style_Library.Model;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace QQMusic_C_Style_Library
{
    public class Wrapper
    {
        static Wrapper()
        {
            Console.WriteLine("QQMusic_C_Style_Library init success");
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


        public static bool SearchMusicByName_Inside(IntPtr SearchArgPtr,IntPtr testptr)
        {
            Console.WriteLine("SearchArgPtr:{0:X000}", SearchArgPtr);
            var api = new QQMusicAPI();
            //var searchArg = Marshal.PtrToStructure<ANative_SearchArg>(SearchArgPtr);
            //Console.WriteLine("SearchArg:{0}", getJson(searchArg));
            //searchArg.Keywords = searchArg.Keywords.TrimEnd('\0');
            try
            {
                SearchResult result = api.SearchAsync(new SearchArg { Keywords="bye bye bye"}).Result;
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