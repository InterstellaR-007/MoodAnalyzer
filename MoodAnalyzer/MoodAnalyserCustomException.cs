using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    /// <summary>
    /// Mood Analyzer Custom Exception class
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class MoodAnalyserCustomException:Exception
    {

        /// <summary>
        /// Enum Exception type
        /// </summary>
        public enum ExceptionType 
        {
            ENTERED_NULL, ENTERED_EMPTY,
            NO_SUCH_FIELDS, NO_SUCH_METHODS,
            NO_SUCH_CLASS,OBJECT_CREATION_ISSUE
        }
        public ExceptionType type;
        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyserCustomException"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        public MoodAnalyserCustomException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
