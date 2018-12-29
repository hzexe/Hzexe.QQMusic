using System;
using System.Collections.Generic;
using System.Text;

namespace Hzexe.QQMusic.Model
{
    public interface IFiletype
    {
        string Prefix { get; set; }
        string Suffix { get; set; }
        int Size { get; set; }
    }


    public class Ape : IFiletype
    {
        public string Prefix { get; set; } = "A000";
        public string Suffix { get; set; } = "ape";
        public int Size { get; set; }
    }

    public class Flac : IFiletype
    {
        public string Prefix { get; set; } = "F000";
        public string Suffix { get; set; } = "flac";
        public int Size { get; set; }
    }

    public class Mp3_320k : IFiletype
    {
        public string Prefix { get; set; } = "M800";
        public string Suffix { get; set; } = "mp3";
        public int Size { get; set; }
    }

    public class Mp3_128k : IFiletype
    {
        public string Prefix { get; set; } = "M500";
        public string Suffix { get; set; } = "mp3";
        public int Size { get; set; }
    }
}
