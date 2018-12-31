using System.IO;
using System.Threading.Tasks;
using Hzexe.QQMusic.Model;

namespace Hzexe.QQMusic
{
    public interface IQQMusicAPI
    {
        Task<bool> downloadLyricAsync(SongItem songItem, Stream outstream);
        Task<bool> downloadLyricAsync(SongItem songItem, string songdir);
        Task downloadSongAsync(SongItem songItem, Stream outstream, IFiletype downloadType);
        Task downloadSongAsync(SongItem songItem, string songdir, IFiletype downloadType);
        string GetDownloadSongUrl(SongItem songItem, IFiletype downloadType);
        Task<SearchResult> SearchAsync(SearchArg body);
    }
}