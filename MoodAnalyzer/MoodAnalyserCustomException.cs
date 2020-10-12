using System;
using System.Collections.Generic;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyserCustomException:Exception
    {
        
        public enum ExceptionType 
        {
            ENTERED_NULL, ENTERED_EMPTY,
            NO_SUCH_FIELDS, NO_SUCH_METHODS,
            NO_SUCH_CLASS,OBJECT_CREATION_ISSUE
        }
        public ExceptionType type;
        public MoodAnalyserCustomException(ExceptionType type,string message):base(message)
        {
            this.type = type;
        }
    }
}
