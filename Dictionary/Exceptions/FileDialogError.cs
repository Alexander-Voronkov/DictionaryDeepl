using System;

namespace Dictionary.Exceptions
{
    public class FileDialogError : Exception
    {
        public FileDialogError(string message) : base(message) { }
    }
}
