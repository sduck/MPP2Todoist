using System;

namespace MPP2Todoist.MPP
{
    public class MppServiceException : Exception
    {
        public MppServiceException(string message) : base(message)
        {
        }

        public MppServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}