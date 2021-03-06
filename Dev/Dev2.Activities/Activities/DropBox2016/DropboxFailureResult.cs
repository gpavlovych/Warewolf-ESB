using System;

namespace Dev2.Activities.DropBox2016
{
    public class DropboxFailureResult : IDropboxResult
    {
        private readonly Exception _exception;

        public DropboxFailureResult(Exception exception)
        {
            _exception = exception;
        }
        public Exception GetException()
        {
            return _exception;
        }
    }
}