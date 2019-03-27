//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class TableModel
    {
        [DisplayName("歌名")]
        public string Name { get; set; }
        [DisplayName("专辑")]
        public string AlbumName { get; set; }
        [DisplayName("歌手")]
        public string Singer { get; set; }

        [DisplayName("Api格式")]
        public string Ape { get; set; }
        [DisplayName("Flac格式")]
        public string Flac { get; set; }
        [DisplayName("Mp3_320k")]
        public string Mp3_320k { get; set; }
        [DisplayName("M4a")]
        public string M4a { get; set; }
        [DisplayName("Api格式")]
        public string Mp3_128k { get; set; }
        [DisplayName("高质量试听")]
        public string Play { get; set; } = "试听";

        public Hzexe.QQMusic.Model.SongItem SongItem { get; set; }
    }
}
