using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Hzexe.QQMusic.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("LibTest")]
namespace Hzexe.QQMusic
{

    public class QQMusicAPI : IQQMusicAPI
    {
        const int uin = 5008611; //随便写个QQ号码
        const string guid = "1234567890";  //随机的一个字符串

        private readonly Task<string> vkTask;
        protected string vkey;

        public QQMusicAPI()
        {
            vkTask = GetVkeyAsync();
        }


        private static async Task<T> GetHttpAsync<T>(string url)
            where T : new()
        {
            using (var clinet = new HttpClient())
            {
                var response = await clinet.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<ApiResult<T>>(json);
                if (res.code != 0)
                    throw new QQMusicAPIException(res.message ?? json);
                return res.data;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        /// <exception cref="QQMusicAPIException"></exception>
        public async Task<SearchResult> SearchAsync(SearchArg body)
        {
            var url = $"http://c.y.qq.com/soso/fcgi-bin/client_search_cp?ct=24&qqmusic_ver=1298&new_json=1&remoteplace=txt.yqq.center&t=0&aggr=1&cr=1&catZhida=1&lossless=0&flag_qc=0&p={body.Page}&n={body.PageSize}&w={body.Keywords}&jsonpCallback=searchCallbacksong2020&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq&needNewCode=0";
            return await GetHttpAsync<SearchResult>(url);
        }
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetVkeyAsync()
        {
            var url = $"http://c.y.qq.com/base/fcgi-bin/fcg_music_express_mobile3.fcg?g_tk=0&loginUin=${uin}&hostUin=0&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq&needNewCode=0&cid=205361747&uin={uin}&songmid=003a1tne1nSz1Y&filename=C400003a1tne1nSz1Y.m4a&guid={guid}";
            var res = await GetHttpAsync<VkeyResponse>(url);
            //Trace.Assert(res.items.Length > 0, "Get vkey falt...");
            return res.items[0].vkey;
        }


        /// <summary>
        /// 获取音乐下载连接地址
        /// </summary>
        /// <param name="songItem">音乐对象</param>
        /// <param name="downloadType">文件类型</param>
        /// <returns>url</returns>
        public string GetDownloadSongUrl(SongItem songItem, IFiletype downloadType)
        {
            if (string.IsNullOrEmpty(vkey))
            {
                if (!vkTask.IsCompleted)
                    vkTask.Wait();
                vkey = vkTask.Result;
            }
            var url = $"http://streamoc.music.tc.qq.com/{downloadType.Prefix}{songItem.file.strMediaMid}.{downloadType.Suffix}?vkey={vkey}&guid={guid}&uin={uin}&fromtag=8";
            return url;

        }

        /// <summary>
        /// 下载歌词
        /// </summary>
        /// <param name="songItem"></param>
        /// <param name="outstream">存放的流</param>
        /// <returns>是否成功</returns>
        public async Task<bool> downloadLyricAsync(SongItem songItem, System.IO.Stream outstream)
        {
            int songid = songItem.id;
            var url = $"https://c.y.qq.com/lyric/fcgi-bin/fcg_query_lyric_new.fcg?-=MusicJsonCallback_lrc&pcachetime={DateTime.Now.ToFileTimeUtc()}&songmid={songItem.file.strMediaMid}&g_tk=5381&loginUin=0&hostUin=0&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq.json&needNewCode=0";
            //命名规则
            string lrcfilename = $"{songItem.title}-{songItem.singer[0].name}.lrc";
            var clinet = new HttpClient();
            clinet.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            clinet.DefaultRequestHeaders.Add("referer", "https://y.qq.com/portal/player.html");

            try
            {
                var response = await clinet.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<LyricResult>(json);
                if (res.code == 0)
                {
                    var bstr = res.lyric;
                    var data = Convert.FromBase64String(bstr);
                    await outstream.WriteAsync(data, 0, data.Length);
                    // System.IO.File.WriteAllBytes(lrcfilename, data);
                }
                return res.code == 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                clinet.Dispose();
            }
        }

        /// <summary>
        /// 下载歌词
        /// </summary>
        /// <param name="songItem"></param>
        /// <param name="songdir"></param>
        /// <returns>是否成功</returns>
        public async Task<bool> downloadLyricAsync(SongItem songItem, string songdir)
        {
            int songid = songItem.id;
            var url = $"https://c.y.qq.com/lyric/fcgi-bin/fcg_query_lyric_new.fcg?-=MusicJsonCallback_lrc&pcachetime={DateTime.Now.ToFileTimeUtc()}&songmid={songItem.file.strMediaMid}&g_tk=5381&loginUin=0&hostUin=0&format=json&inCharset=utf8&outCharset=utf-8&notice=0&platform=yqq.json&needNewCode=0";
            //命名规则
            string lrcfilename = $"{songItem.title}-{songItem.singer[0].name}.lrc";
            var clinet = new HttpClient();
            clinet.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/71.0.3578.98 Safari/537.36");
            clinet.DefaultRequestHeaders.Add("referer", "https://y.qq.com/portal/player.html");

            try
            {
                var response = await clinet.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
                var res = JsonConvert.DeserializeObject<LyricResult>(json);
                if (res.code == 0)
                {
                    var bstr = res.lyric;
                    var data = Convert.FromBase64String(bstr);
                    System.IO.File.WriteAllBytes(lrcfilename, data);
                }
                return res.code == 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                clinet.Dispose();
            }
        }

        /// <summary>
        /// 下载音乐文件存放在指定的流
        /// </summary>
        /// <param name="songItem">指定的歌曲</param>
        /// <param name="outstream">存放音乐文件的流</param>
        /// <param name="vkey">音乐对象</param>
        /// <param name="downloadType">文件类型</param>
        /// <returns>Task</returns>
        public async Task downloadSongAsync(SongItem songItem, System.IO.Stream outstream, IFiletype downloadType)
        {
            var url = GetDownloadSongUrl(songItem, downloadType);
            var clinet = new HttpClient();
            try
            {
                var response = await clinet.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
                await response.Content.CopyToAsync(outstream);
            }
            catch
            {
                throw;
            }
            finally
            {
                clinet.Dispose();
            }
        }

        /// <summary>
        /// 下载音乐文件
        /// </summary>
        /// <param name="songItem">指定的歌曲</param>
        /// <param name="songdir">存放指定的目录</param>
        /// <param name="vkey">音乐对象</param>
        /// <param name="downloadType">文件类型</param>
        /// <returns>Task</returns>
        public async Task downloadSongAsync(SongItem songItem, string songdir, IFiletype downloadType)
        {
            //命名规则
            string musicfilename = $"{songItem.title}-{songItem.singer[0].name}.{downloadType.Suffix}";
            System.IO.Stream fs = null;
            try
            {
                string filefull = System.IO.Path.Combine(songdir, musicfilename);
                fs = System.IO.File.OpenWrite(filefull);
                await downloadSongAsync(songItem, fs, downloadType);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (null != fs)
                    fs.Dispose();
            }
        }
    }


    public class SearchArg
    {
        public int Page { get; set; } = 0;
        public int PageSize { get; set; } = 400;
        public string Keywords { get; set; }
    }
}
