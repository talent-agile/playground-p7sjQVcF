using System;

namespace Exceptions
{
    public interface ILog
    {
        void LogException(Exception ex);
    }
}