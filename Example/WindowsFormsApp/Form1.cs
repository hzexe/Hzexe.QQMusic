using Hzexe.QQMusic;
using Hzexe.QQMusic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        QQMusicAPI api = null;
        Vlc.DotNet.Core.VlcMediaPlayer mediaPlayer;
        Lrc lrc = null;

        public Form1()
        {
            InitializeComponent();
            api = new QQMusicAPI();
            var dir = new FileInfo(this.GetType().Assembly.Location).Directory.FullName;
            var libDirectory = new DirectoryInfo(Path.Combine(dir, "libvlc", IntPtr.Size == 4 ? "win-x86" : "win-x64"));

            var options = new string[]
            {
                // VLC options can be given here. Please refer to the VLC command line documentation.
            };

            mediaPlayer = new Vlc.DotNet.Core.VlcMediaPlayer(libDirectory);
            mediaPlayer.Buffering += MediaPlayer_Buffering;
            mediaPlayer.EndReached += MediaPlayer_EndReached;
            mediaPlayer.MediaChanged += MediaPlayer_MediaChanged;
            mediaPlayer.Playing += MediaPlayer_Playing;
            mediaPlayer.Stopped += MediaPlayer_Stopped;
            mediaPlayer.TimeChanged += MediaPlayer_TimeChanged;
            this.FormClosing += (a, b) => mediaPlayer.Dispose();
        }

        private void MediaPlayer_TimeChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerTimeChangedEventArgs e)
        {
            if (lrc != null)
            {
                var kv = lrc.LrcWord.Keys.Where(x => x < e.NewTime).LastOrDefault();
                if (kv > 0)
                {
                    string word = lrc.LrcWord[kv];
                    doform(() => toolStripStatusLabel2.Text = word);
                }
            }
            doform(() => toolStripProgressBar1.Value = (int)(mediaPlayer.Position * toolStripProgressBar1.Maximum));
        }

        private void MediaPlayer_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            doform(() => toolStripStatusLabel1.Text = "已停止");
        }

        private void MediaPlayer_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
        {
            doform(() => toolStripStatusLabel1.Text = "播放中");
            var m = mediaPlayer.GetMedia();
            string desc = m.Title;


            doform(() => toolStripStatusLabel2.Text = desc);
        }

        private void MediaPlayer_MediaChanged(object sender, Vlc.DotNet.Core.VlcMediaPlayerMediaChangedEventArgs e)
        {
            doform(() => toolStripStatusLabel1.Text = "切换音乐");
        }

        private void MediaPlayer_EndReached(object sender, Vlc.DotNet.Core.VlcMediaPlayerEndReachedEventArgs e)
        {
            doform(() => toolStripStatusLabel1.Text = "已停止");
            doform(() => toolStripStatusLabel2.Text = "");
        }

        private void MediaPlayer_Buffering(object sender, Vlc.DotNet.Core.VlcMediaPlayerBufferingEventArgs e)
        {

        }

        private void doform(Action action)
        {
            this.Invoke(action);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //textBox1
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                var arg = new SearchArg() { Keywords = textBox1.Text.Trim() };
                arg.PageSize = 100;
                var result = await api.SearchAsync(arg); //搜索搜索并获取结果

                if (result.song.list.Count > 0)
                {
                    Console.WriteLine($"共搜索到{result.song.list.Count}个结果");

                    this.tableModelBindingSource.DataSource = result.song.list.Select(x => new TableModel
                    {
                        AlbumName = x.album.name,
                        Name = x.name,
                        Singer = string.Join("、", x.singer.Select(xx => xx.name).ToArray()),
                        SongItem = x,
                        Ape = (x.file.size_ape.HasValue && x.file.size_ape.Value > 0) ? "下载" : null,
                        Flac = (x.file.size_flac.HasValue && x.file.size_flac.Value > 0) ? "下载" : null,
                        Mp3_128k = (x.file.size_128.HasValue && x.file.size_128.Value > 0) ? "下载" : null,
                        Mp3_320k = (x.file.size_320.HasValue && x.file.size_320.Value > 0) ? "下载" : null,
                    });


                    //为了简化示例，就取列表的第一条歌曲
                    var song = result.song.list[0];
                    Hzexe.QQMusic.Model.IFiletype[] type = song.file.GetAvailableFileType();//取当前歌曲可用的类型
                }
                else
                {
                    this.tableModelBindingSource.DataSource = typeof(TableModel);
                    Console.WriteLine("没找到你需要的歌曲");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (0 > e.RowIndex) return;
            Hzexe.QQMusic.Model.SongItem si = (dataGridView1.Rows[e.RowIndex].DataBoundItem as TableModel).SongItem;
            var col = dataGridView1.Columns[e.ColumnIndex];

            Action<IFiletype, SongItem> fun = new Action<IFiletype, SongItem>((ext, obj) =>
            {
                string musicfilename = $"{obj.title}-{obj.singer[0].name}.{ext.Suffix}";
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.CheckFileExists = false;
                saveFileDialog1.DefaultExt = ext.Suffix;
                saveFileDialog1.OverwritePrompt = true;
                saveFileDialog1.ValidateNames = true;
                saveFileDialog1.Tag = new { si = obj, ft = ext };
                saveFileDialog1.Filter = $"{ext.Suffix}(*.{ext.Suffix})|*.{ext.Suffix}";
                saveFileDialog1.FileName = musicfilename;
                saveFileDialog1.ShowDialog();
            });

            if ("Ape" == col.DataPropertyName)
            {
                fun(new Ape(), si);
            }
            else if ("Flac" == col.DataPropertyName)
            {
                fun(new Flac(), si);
            }
            else if ("Mp3_320k" == col.DataPropertyName)
            {
                fun(new Mp3_320k(), si);
            }
            else if ("Mp3_128k" == col.DataPropertyName)
            {
                fun(new Mp3_128k(), si);
            }
            else if ("Play" == col.DataPropertyName)
            {
                string url = api.GetDownloadSongUrl(si, si.file.GetAvailableFileType().First());
                mediaPlayer.SetMedia(new Uri(url));

                Task.Run(async () =>
                {
                    //尝试载歌词
                    var ms = new System.IO.MemoryStream();
                    if (await api.downloadLyricAsync(si, ms))
                    {
                        ms.Position = 0;
                        lrc = Lrc.InitLrc(ms);
                    }
                    else
                    {
                        lrc = null;
                    }
                    ms.Dispose();
                    mediaPlayer.Play();
                });
            }
        }

        private void Sfd_FileOk(object sender, CancelEventArgs e)
        {
            var tag = saveFileDialog1.Tag as dynamic;
            var si = tag.si as SongItem;
            IFiletype type = tag.ft as IFiletype;

            Task.Run(async () =>
            {
                var stream = saveFileDialog1.OpenFile();
                await api.downloadSongAsync(si, stream, type);
                stream.Dispose();
                //await api.downloadLyricAsync(si, new FileInfo(saveFileDialog1.FileName).Directory.FullName);
                MessageBox.Show("下载完成");
            });

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/hzexe/Hzexe.QQMusic");
            }
            catch { }
        }
    }
}
