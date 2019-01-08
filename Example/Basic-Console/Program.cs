//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using Hzexe.QQMusic;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using Hzexe.QQMusic.Model;

namespace Basic_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new QQMusicAPI();  //初始化一个实例
            string songName = null;
            while (string.IsNullOrEmpty(songName))
                songName = GetUserInput("\r\n请输入要搜索的歌名");

            var arg = new SearchArg() { Keywords = songName };
            arg.PageSize = 30;
            var result = api.SearchAsync(arg).Result; //搜索搜索并获取结果

            if (result.song.list.Count > 0)
            {
                Console.WriteLine($"共搜索到{result.song.list.Count}个结果");
                //为了简化示例，就取列表的第一条歌曲
                var song = result.song.list[0];
                EnumFileType type = song.file.GetAvailableFileType();//取当前歌曲可用的类型
                Console.WriteLine(type);

                //获取当前目录用来存放音乐
                string dir = AppContext.BaseDirectory;

                //要下载哪种类型的音乐呢？
                EnumFileType downloadType =0;
                downloadType &= (type & EnumFileType.Ape);
                if (downloadType == 0)
                    downloadType &= (type & EnumFileType.Flac);
                if (downloadType == 0)
                    downloadType &= (type & EnumFileType.Mp3_320k);
                if (downloadType == 0)
                    downloadType &= (type & EnumFileType.Mp3_128k);

                var t = api.downloadSongAsync(song, dir, downloadType);//建立下载的task,下载文件最大并保存到当前目录
                //可选:当然也可以尝试lrc的歌词下载下来
                var t2 = api.downloadLyricAsync(song, dir);
                Console.WriteLine("Start download:");
                while (!t.IsCompleted)
                {
                    Console.Write(".");
                    System.Threading.Thread.Sleep(500);
                }
                t2.Wait();
                Console.WriteLine();
                if (t.IsFaulted)
                    Console.WriteLine($"Error:{t.Exception.Message}");
                else
                    Console.WriteLine("Download success!");
            }
            else
            {
                Console.WriteLine("没找到你需要的歌曲");
            }
            Console.WriteLine("按任意键退出本示例");
            Console.ReadKey();
        }


        private static string GetUserInput(string tip)
        {
            Console.Write($"{tip}>");
            return Console.ReadLine();
        }

      
    }
}
