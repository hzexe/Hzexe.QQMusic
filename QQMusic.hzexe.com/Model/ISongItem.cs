using System.Collections.Generic;

namespace Hzexe.QQMusic.Model
{
    public interface ISongItem
    {
        int id { get; set; }
        IAlbum album { get; set; }
        IFile file { get; set; }
        
        string title { get; set; }
        List<Singer2> singer { get; set; }
    }
}