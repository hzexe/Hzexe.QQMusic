//Copyright by hzexe https://github.com/hzexe
//All rights reserved
//See the LICENSE file in the project root for more information.
namespace Hzexe.QQMusic
{
    public interface ISearchArg
    {
        string Keywords { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}