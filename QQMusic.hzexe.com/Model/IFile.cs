//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
namespace Hzexe.QQMusic.Model
{
    public interface IFile
    {
        int? size_128 { get; set; }
        int? size_320 { get; set; }
        int? size_aac { get; set; }
        int? size_ape { get; set; }
        int? size_dts { get; set; }
        int? size_flac { get; set; }
        int? size_ogg { get; set; }
        int? size_try { get; set; }
        string strMediaMid { get; set; }
        EnumFileType GetAvailableFileType();
    }
}