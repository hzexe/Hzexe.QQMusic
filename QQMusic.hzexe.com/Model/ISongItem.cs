//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
using System.Collections.Generic;

namespace Hzexe.QQMusic.Model
{
    public interface ISongItem
    {
        int id { get; set; }
        IAlbum album { get; set; }
        IFile file { get; set; }
        
        string title { get; set; }
        Singer2[] singer { get; set; }
    }
}