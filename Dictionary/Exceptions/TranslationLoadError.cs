using System;

namespace Dictionary.Exceptions
{
    public class TranslationLoadError : Exception
    {
        public TranslationLoadError(string message) : base(message) { }
    }
}
