using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace MoodAnalyzer
{
    /// <summary>
    /// Mood Analyzer Factory Class
    /// </summary>
    public class MoodAnalyzerFactory
    {
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <returns></returns>
        public static object Create_Mood_Analyser_Object()
        {
            Type type = Type.GetType("MoodAnalyzer.MoodAnalyzerApp");
            MoodAnalyzerApp new_Obj = (MoodAnalyzerApp)Activator.CreateInstance(type);
            return new_Obj;
        }

        /// <summary>
        /// Sets the fields and invoking analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="field_Name">Name of the field.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Messgae should be null
        /// or
        /// No field found
        /// </exception>
        public static string SetFields_And_InvokingAnalyseMood(string message,string field_Name)
        {
            try
            {
                MoodAnalyzerApp moodAnalyzer = new MoodAnalyzerApp();
                Type type = typeof(MoodAnalyzerApp);
                FieldInfo field = type.GetField(field_Name, BindingFlags.Public | BindingFlags.Instance);

                if (message == null)
                {
                    //throw custom exception type
                    throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELDS, "Messgae should be null");
                }
                field.SetValue(moodAnalyzer, message);
                return moodAnalyzer.message;
            }
            catch (NullReferenceException)
            {
                throw new MoodAnalyserCustomException(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELDS, "No field found");
            }
        }

        /// <summary>
        /// Invokes the analyse mood.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">Method not found</exception>
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
        /// <summary>
        /// Creates the mood analyser object.
        /// </summary>
        /// <param name="class_Name">Name of the class.</param>
        /// <param name="constructor_Name">Name of the constructor.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Wrong Custructor Name Entered
        /// or
        /// Wrong Class Name Entered
        /// </exception>
        public static object Create_Mood_Analyser_Object(string class_Name,string constructor_Name)
        {
            try
            {
                //Using Reflection class GetType
                Type type = Type.GetType("MoodAnalyzer." + class_Name);

                //if custructor name and type name matches with actual class type
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
        /// <summary>
        /// Creates the mood analyser object with parameter.
        /// </summary>
        /// <param name="class_Name">Name of the class.</param>
        /// <param name="constructor_Name">Name of the constructor.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        /// <exception cref="MoodAnalyserCustomException">
        /// Wrong Custructor Name Entered
        /// or
        /// Wrong Class Name Entered
        /// </exception>
        public static object Create_Mood_Analyser_Object_With_Parameter(string class_Name, string constructor_Name,String message)
        {

            try
            {
                //Using Reflection class GetType
                Type type = Type.GetType("MoodAnalyzer." + class_Name);
                
                
                //if custructor name and type name matches with actual class type
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
