namespace Hzexe.QQMusic
{
    public interface ISearchArg
    {
        string Keywords { get; set; }
        int Page { get; set; }
        int PageSize { get; set; }
    }
}