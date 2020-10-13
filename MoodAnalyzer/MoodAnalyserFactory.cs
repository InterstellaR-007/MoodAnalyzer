using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyzer
{
    public class MoodAnalyserFactory
    {
        public static object Create_Mood_Analyser_Object()
        {
            Type type = Type.GetType("MoodAnalyzer.MoodAnalyzerApp");
            MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type);
            return new_Obj;
        }
        public static object Create_Mood_Analyser_Object(string class_Name)
        {

            if (class_Name.Equals("MoodAnalyzerApp")) 
            {

                    Type type = Type.GetType("MoodAnalyzer." + class_Name);
                    MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type);
                    return new_Obj;
            }
            else
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "No such Class found");
            }
            
        }
    }
}
