using System;

namespace DesignPatternsDemo
{
    public class CoordinateOutOfRangeException : Exception
    {
        public CoordinateOutOfRangeException() : base(string.Empty)
        {
        }

        public CoordinateOutOfRangeException(string message) : base(message)
        {
        }

        public CoordinateOutOfRangeException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
