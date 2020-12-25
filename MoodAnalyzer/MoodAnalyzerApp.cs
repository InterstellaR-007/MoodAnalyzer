using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoodAnalyzer
{
    /// <summary>
    /// Mood Analyzer Application
    /// </summary>
    public class MoodAnalyzerApp
    {
        //String member
        public String message;

        public MoodAnalyzerApp()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MoodAnalyzerApp"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public MoodAnalyzerApp(String message)
        {
            this.message = message;
        }

        /// <summary>
        /// Analyses the mood.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Input is Empty
        /// or
        /// Input is NULL
        /// </exception>
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
