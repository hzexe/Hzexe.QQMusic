using Hzexe.QQMusic;
using Hzexe.QQMusic.Model;
using System;
using System.Runtime.InteropServices;
using Xunit;
using System.Linq;


namespace LibTest
{
    public class QQMusicAPITest
    {
        [Fact]
        public async void SearchAsyncTest()
        {
            var api = new QQMusicAPI();
            var arg = new SearchArg() { Keywords = "bye bye bye" };
            arg.PageSize = 30;
            var result = await api.SearchAsync(arg); //搜索搜索并获取结果
            Assert.NotNull(result);
            Assert.NotNull(result.song);
            Assert.NotEmpty(result.song.list);
        }


      
        /*
        //Volume2
        [Fact]
        public void TestclsSizeTest()
        {
            var arg = new Testcls();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }


        [Fact]
        public void AlbumSizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.Album();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }

        [Fact]
        public void FileSizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.File();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }
        [Fact]
        public void VolumeSizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.Volume();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }

        //[Fact]
        //public void Singer2SizeTest()
        //{
        //    var arg = new Hzexe.QQMusic.Model.Singer2();
        //    var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
        //    Assert.True(size > 0);
        //}

        [Fact]
        public void Volume2SizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.Volume2();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }

        [Fact]
        public void Action1SizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.Action1();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }

        [Fact]
        public void SearchArgSizeTest()
        {
            var arg = new SearchArg() { Keywords = "bye bye bye" };
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }
        [Fact]
        public void SongItemSizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.SongItem();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }


        [Fact]
        public void SongSizeTest()
        {
            var arg = new Hzexe.QQMusic.Model.Song();
            var size = System.Runtime.InteropServices.Marshal.SizeOf(arg);
            Assert.True(size > 0);
        }
        */

    }

    [StructLayout(LayoutKind.Explicit)]
    class Testcls
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public int[] _list;
        // public int[] list { get => _list; set => _list = value; }

    }
}
