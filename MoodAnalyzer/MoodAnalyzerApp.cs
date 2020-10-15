using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodAnalyzer
{
    public class MoodAnalyzerApp
    {
        private String message;

        public MoodAnalyzerApp()
        {
        }

        public MoodAnalyzerApp(String message)
        {
            this.message = message;
        }

        public String Analyse_Mood()
        {
            try
            {
                if (message.Contains("sad"))
                {
                    return "sad";
                }
                if (message==string.Empty)
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.ENTERED_EMPTY, "Input is Empty");
                }
                else
                    return "Happy";
            }
            catch(NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.ENTERED_NULL, "Input is NULL");
            }
            

        }
    }
}
