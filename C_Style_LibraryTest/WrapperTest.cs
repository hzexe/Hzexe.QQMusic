using Hzexe.QQMusic;
using Hzexe.QQMusic.Model;
using QQMusic_C_Style_Library;
using QQMusic_C_Style_Library.Model;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace C_Style_LibraryTest
{
    public class WrapperTest
    {
        private void sizeTest<T>(T cls) where T : new()
        {
            Assert.True(Marshal.SizeOf(cls) > 0);
        }
        [Fact]
        public void DownloadMusic_InsideTest()
        {
            ANative_SearchArg s = new ANative_SearchArg();
            s.Keywords = "bye bye bye";
            IntPtr sptr = Marshal.AllocHGlobal(Marshal.SizeOf(s));
            var api = new QQMusicAPI();
            //SearchResult result = api.SearchAsync(new SearchArg() { Keywords = "bye bye bye" }).Result;
            Marshal.StructureToPtr(s, sptr, false);
            byte[] buff = new byte[10000];
            unsafe
            {
                fixed (byte* v = &buff[0])
                {
                    IntPtr ptr = new IntPtr(v);
                    Wrapper.SearchMusicByName_Inside(sptr, ptr);
                    Native_SearchResult* f = (Native_SearchResult*)(ptr);
                    var songItem = Marshal.PtrToStructure<Native_SongItem>(ptr + 12);
                    Assert.Equal("Lovestoned", songItem.singer_name);
                    string dir = @"";
                    var dirptr = Marshal.StringToCoTaskMemUni(dir);
                    var r = Wrapper.DownloadMusic_Inside(ptr + 12, EnumFileType.Mp3_128k, dirptr, dir.Length);
                    Assert.True(r);
                }
            }
        }


        [Fact]
        public void SearchMusicByName_InsideTest()
        {
            ANative_SearchArg s = new ANative_SearchArg();
            s.Keywords = "bye bye bye";
            IntPtr sptr = Marshal.AllocHGlobal(Marshal.SizeOf(s));
            var api = new QQMusicAPI();
            //SearchResult result = api.SearchAsync(new SearchArg() { Keywords = "bye bye bye" }).Result;
            Marshal.StructureToPtr(s, sptr, false);
            byte[] buff = new byte[10000];
            unsafe
            {
                fixed (byte* v = &buff[0])
                {
                    IntPtr ptr = new IntPtr(v);
                    Wrapper.SearchMusicByName_Inside(sptr, ptr);
                    Native_SearchResult* f = (Native_SearchResult*)(ptr);
                    var songItem = Marshal.PtrToStructure<Native_SongItem>(ptr + 12);
                    Assert.Equal("Lovestoned", songItem.singer_name);


                }
            }
        }


        

        [Fact]
        public void Native_SongItemSizeTest()
        {
            sizeTest(new Native_SongItem());
        }

        [Fact]
        public void Native_SearchArgSizeTest()
        {
            sizeTest(new ANative_SearchArg());
        }

        [Fact]
        public void Native_SearchResultSizeTest()
        {
            sizeTest(new Native_SearchResult());
        }

        [Fact]
        public void MarshalNative_SearchResultTest()
        {
            var si = new[]{
                new Native_SongItem() {
                album_name="中文专辑1",
                fileType=EnumFileType.Ape| EnumFileType.Mp3_320k,
                file_strMediaMid="xx8979x898x9x8",
                singer_name="中文歌手1,中文歌手2"
            },
                new Native_SongItem() {
                album_name="中文专辑2",
                fileType=EnumFileType.Ape,
                file_strMediaMid="yyyyyyy",
                singer_name="中文歌手3,中文歌手4"
            }
            };



            sizeTest(new Native_SearchResult());
        }
    }
}
