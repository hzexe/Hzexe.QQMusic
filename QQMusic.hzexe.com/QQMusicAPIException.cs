using System;

namespace Hzexe.QQMusic
{
    class QQMusicAPIException : Exception
    {
        public QQMusicAPIException(string Message) : base(Message) { }
    }
}
