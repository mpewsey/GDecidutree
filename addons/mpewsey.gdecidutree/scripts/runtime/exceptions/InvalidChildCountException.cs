using System;

namespace MPewsey.GDecidutree.Exceptions
{
    public class InvalidChildCountException : Exception
    {
        public InvalidChildCountException(string message) : base(message)
        {

        }
    }
}