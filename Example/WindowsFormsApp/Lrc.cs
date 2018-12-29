using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    //http://www.cnblogs.com/liuxiaobo93/p/3896914.html
    public class Lrc
    {
        /// <summary>
        /// 歌曲
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 艺术家
        /// </summary>
        public string Artist { get; set; }
        /// <summary>
        /// 专辑
        /// </summary>
        public string Album { get; set; }
        /// <summary>
        /// 歌词作者
        /// </summary>
        public string LrcBy { get; set; }
        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        public SortedDictionary<long, string> LrcWord = new SortedDictionary<long, string>();

        /// <summary>
        /// 获得歌词信息
        /// </summary>
        /// <param name="LrcPath">歌词路径</param>
        /// <returns>返回歌词信息(Lrc实例)</returns>
        /// <summary>
        /// 获得歌词信息
        /// </summary>
        /// <param name="LrcPath">歌词路径</param>
        /// <returns>返回歌词信息(Lrc实例)</returns>
        public static Lrc InitLrc(string LrcPath)
        {
            Lrc lrc = new Lrc();
            SortedDictionary<long, string> dicword = new SortedDictionary<long, string>();
            using (FileStream fs = new FileStream(LrcPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string line;
                using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("[ti:"))
                        {
                            lrc.Title = SplitInfo(line);
                        }
                        else if (line.StartsWith("[ar:"))
                        {
                            lrc.Artist = SplitInfo(line);
                        }
                        else if (line.StartsWith("[al:"))
                        {
                            lrc.Album = SplitInfo(line);
                        }
                        else if (line.StartsWith("[by:"))
                        {
                            lrc.LrcBy = SplitInfo(line);
                        }
                        else if (line.StartsWith("[offset:"))
                        {
                            lrc.Offset = SplitInfo(line);
                        }
                        else
                        {
                            try
                            {
                                Regex regexword = new Regex(@".*\](.*)");
                                Match mcw = regexword.Match(line);
                                string word = mcw.Groups[1].Value;
                                Regex regextime = new Regex(@"\[([0-9.:]*)\]", RegexOptions.Compiled);
                                MatchCollection mct = regextime.Matches(line);
                                foreach (Match item in mct)
                                {
                                    long time =(long) TimeSpan.Parse("00:" + item.Groups[1].Value).TotalMilliseconds;
                                    dicword.Add(time, word);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            lrc.LrcWord = dicword;
            return lrc;
        }

        public static Lrc InitLrc(Stream fs)
        {
            Lrc lrc = new Lrc();
            SortedDictionary<long, string> dicword = new SortedDictionary<long, string>();

            string line;
            using (StreamReader sr = new StreamReader(fs, Encoding.UTF8))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.StartsWith("[ti:"))
                    {
                        lrc.Title = SplitInfo(line);
                    }
                    else if (line.StartsWith("[ar:"))
                    {
                        lrc.Artist = SplitInfo(line);
                    }
                    else if (line.StartsWith("[al:"))
                    {
                        lrc.Album = SplitInfo(line);
                    }
                    else if (line.StartsWith("[by:"))
                    {
                        lrc.LrcBy = SplitInfo(line);
                    }
                    else if (line.StartsWith("[offset:"))
                    {
                        lrc.Offset = SplitInfo(line);
                    }
                    else
                    {
                        try
                        {
                            Regex regexword = new Regex(@".*\](.*)");
                            Match mcw = regexword.Match(line);
                            string word = mcw.Groups[1].Value;
                            Regex regextime = new Regex(@"\[([0-9.:]*)\]", RegexOptions.Compiled);
                            MatchCollection mct = regextime.Matches(line);
                            foreach (Match item in mct)
                            {
                                long time =(long) TimeSpan.Parse("00:" + item.Groups[1].Value).TotalMilliseconds;
                                dicword.Add(time, word);
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }
                }

            }
            lrc.LrcWord = dicword;
            return lrc;
        }

        /// <summary>
        /// 处理信息(私有方法)
        /// </summary>
        /// <param name="line"></param>
        /// <returns>返回基础信息</returns>
        static string SplitInfo(string line)
        {
            return line.Substring(line.IndexOf(":") + 1).TrimEnd(']');
        }
    }
    //一行代码：Lrc lrc = Lrc.InitLrc("test.lrc");
}
