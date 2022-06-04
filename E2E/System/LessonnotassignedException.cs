//MSTest framework (Microsoft.VisualStudio.TestTools.UnitTesting)
using System.Runtime.Serialization;

namespace System
{
    [Serializable]
    internal class LessonnotassignedException : Exception
    {
        public LessonnotassignedException()
        {
        }

        public LessonnotassignedException(string? message) : base(message)
        {
        }

        public LessonnotassignedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected LessonnotassignedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}