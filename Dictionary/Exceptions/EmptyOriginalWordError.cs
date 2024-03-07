using System;

namespace Dictionary.Exceptions
{
    public class EmptyOriginalWordError : Exception
    {
        public EmptyOriginalWordError(string message) : base(message) { }
    }
}
