using System;

namespace Dictionary.Exceptions
{
    public class LanguageLoadError : Exception
    {
        public LanguageLoadError(string message) : base(message) { }
    }
}
