using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyzer
{
    public class MoodAnalyzerFactory
    {
        public static object Create_Mood_Analyser_Object()
        {
            Type type = Type.GetType("MoodAnalyzer.MoodAnalyzerApp");
            MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type);
            return new_Obj;
        }

        public static string InvokeAnalyseMood(string message,string methodName)
        {
            try
            {
                Type type = Type.GetType("MoodAnalyzer.MoodAnalyzerApp");
                object moodAnalyseObj = MoodAnalyzerFactory.Create_Mood_Analyser_Object_With_Parameter("MoodAnalyzerApp", "MoodAnalyzerApp", message);
                MethodInfo analyseMoodInfo = type.GetMethod(methodName);
                object mood = analyseMoodInfo.Invoke(moodAnalyseObj, null);
                return mood.ToString();
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, "Method not found");
            }
        }
        public static object Create_Mood_Analyser_Object(string class_Name,string constructor_Name)
        {
            try
            {

                Type type = Type.GetType("MoodAnalyzer." + class_Name);
                //ConstructorInfo get_Constructor_Name = type.GetConstructor();

                if (class_Name.Equals(type.Name) && class_Name.Equals(constructor_Name))
                {
                    MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type);
                    return new_Obj;
                }
                else if (class_Name.Equals(type.Name) && !class_Name.Equals(constructor_Name))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, "Wrong Custructor Name Entered");
                }
            }
            catch(NullReferenceException) 
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Wrong Class Name Entered");
            }
            return null;

        }
        public static object Create_Mood_Analyser_Object_With_Parameter(string class_Name, string constructor_Name,String message)
        {

            try
            {

                Type type = Type.GetType("MoodAnalyzer." + class_Name);
                //ConstructorInfo get_Constructor_Name = type.GetConstructor(new[] { typeof(string)});
                

                if (class_Name.Equals(type.Name) && class_Name.Equals(constructor_Name))
                {
                    MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type,message);
                    return new_Obj;
                }
                else if (class_Name.Equals(type.Name) && !class_Name.Equals(constructor_Name))
                {
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, "Wrong Custructor Name Entered");
                }
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, "Wrong Class Name Entered");
            }
            return null;

        }
    }
}
