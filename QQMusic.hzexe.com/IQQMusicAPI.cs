using System.IO;
using System.Threading.Tasks;
using Hzexe.QQMusic.Model;

namespace Hzexe.QQMusic
{
    public interface IQQMusicAPI
    {
        Task<bool> downloadLyricAsync(ISongItem songItem, Stream outstream);
        Task<bool> downloadLyricAsync(ISongItem songItem, string songdir);
        Task downloadSongAsync(ISongItem songItem, Stream outstream, EnumFileType downloadType);
        Task downloadSongAsync(ISongItem songItem, string songdir, EnumFileType downloadType);
        string GetDownloadSongUrl(in ISongItem songItem, in EnumFileType downloadType);
        Task<SearchResult> SearchAsync(ISearchArg body);
    }
}