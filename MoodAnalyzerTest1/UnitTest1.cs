using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerTest1
{
    /// <summary>
    /// Unit Test Class for Mood Analyzer Project
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Givens the null input throws entered null exception when mood analyzer application is invoked.
        /// </summary>
        [TestMethod]
        public void GivenNullInput_ThrowsEnteredNullException_WhenMoodAnalyzerAppIsInvoked()
        {
            string expected_SadMood = "sad";
            string expected_HappyMood = "happy";

            string input_Message = null;
            try
            {
                MoodAnalyzerApp m1 = new MoodAnalyzerApp(input_Message);
                string output_Mood = m1.Analyse_Mood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.ENTERED_NULL, e.type);
            }
        }
        /// <summary>
        /// Givens the empty input throws entered empty exception when mood analyzer application is invoked.
        /// </summary>
        [TestMethod]
        public void GivenEmptyInput_ThrowsEnteredEmptyException_WhenMoodAnalyzerAppIsInvoked()
        {
            string expected_SadMood = "sad";
            string expected_HappyMood = "happy";
            string input_Message = string.Empty;
            try
            {
                MoodAnalyzerApp m1 = new MoodAnalyzerApp(input_Message);
                string output_Mood = m1.Analyse_Mood();
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.ENTERED_EMPTY, e.type);
            }
        }

        /// <summary>
        /// Givens the improper class name return mood analyser object using parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenImproperClassName_ReturnMoodAnalyserObject_UsingParameterizedConstructor()
        {
            
            string input_Message = null;
            string class_Name = "WrongMoodAnalyzerApp";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                object expected_Object = new MoodAnalyzerApp(input_Message);
                object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object(class_Name,constructor_Name);
            }
            catch(MoodAnalyserCustomException e) 
            { 
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS,e.type);
            //expected_Object.Equals(actual_Object);
            }

        }

        /// <summary>
        /// Givens the improper constructor name return mood analyser object using parameterized constructor.
        /// </summary>
        [TestMethod]
        public void GivenImproperConstructorName_ReturnMoodAnalyserObject_UsingParameterizedConstructor()
        {
            
            string input_Message = null;
            string class_Name = "MoodAnalyzerApp";
            string constructor_Name = "WrongMoodAnalyzerApp";
            try
            {
                object expected_Object = new MoodAnalyzerApp(input_Message);
                object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object(class_Name, constructor_Name);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
                //expected_Object.Equals(actual_Object);
            }

        }

        /// <summary>
        /// Givens the proper paramter return mood analyser object using message paramter.
        /// </summary>
        [TestMethod]
        public void GivenProperParamter_ReturnMoodAnalyserObject_UsingMessageParamter()
        {
            
            string input_Message = "I am kinda Sad";
            string class_Name = "MoodAnalyzerApp";
            string constructor_Name = "MoodAnalyzerApp";
            
            object expected_Object = new MoodAnalyzerApp(input_Message);
            object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object_With_Parameter(class_Name, constructor_Name,input_Message);
            
            Assert.AreEqual(actual_Object.GetType(),expected_Object.GetType());
               

        }

        /// <summary>
        /// Givens the wrong class name return mood analyser object using message paramter.
        /// </summary>
        [TestMethod]
        public void GivenWrongClassName_ReturnMoodAnalyserObject_UsingMessageParamter()
        {

            string input_Message = "I am kinda Sad";
            string class_Name = "WrongMoodAnalyzerApp";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {

                object expected_Object = new MoodAnalyzerApp(input_Message);
                object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object_With_Parameter(class_Name, constructor_Name, input_Message);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_CLASS, e.type);
            }
        }

        /// <summary>
        /// Givens the wrong constructor name return mood analyser object using message paramter.
        /// </summary>
        [TestMethod]
        public void GivenWrongConstructorName_ReturnMoodAnalyserObject_UsingMessageParamter()
        {

            string input_Message = "I am kinda Sad";
            string class_Name = "MoodAnalyzerApp";
            string constructor_Name = "WrongMoodAnalyzerApp";
            try
            {

                object expected_Object = new MoodAnalyzerApp(input_Message);
                object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object_With_Parameter(class_Name, constructor_Name, input_Message);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
            }
        }

        /// <summary>
        /// Givens the mood analyser object invoke analyze mood information using message paramter.
        /// </summary>
        [TestMethod]
        public void GivenMoodAnalyserObject_InvokeAnalyzeMoodInfo_UsingMessageParamter()
        {
            string expected = "sad";
            string actual = "";
            string input_Message = "I am kinda sad";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "Analyse_Mood";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {

                actual = MoodAnalyzerFactory.InvokeAnalyseMood(input_Message, method_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
            }
        }
        /// <summary>
        /// Givens the happy message invoke analyze mood method using message paramter.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_InvokeAnalyzeMoodMethod_UsingMessageParamter()
        {
            string expected = "Happy";
            string actual = "";
            string input_Message = "I am kinda Happy";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "Analyse_Mood";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                actual = MoodAnalyzerFactory.InvokeAnalyseMood(input_Message, method_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
            }
        }
        /// <summary>
        /// Givens the name of the happy message invoke analyze mood method using wrong method.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_InvokeAnalyzeMoodMethod_UsingWrongMethodName()
        {
            string expected = "Happy";
            string actual = "";
            string input_Message = "I am kinda Happy";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "WrongAnalyse_Mood";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                actual = MoodAnalyzerFactory.InvokeAnalyseMood(input_Message, method_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
            }
        }


        /// <summary>
        /// Givens the happy message set field value using invoke method.
        /// </summary>
        [TestMethod]
        public void GivenHappyMessage_SetFieldValue_UsingInvokeMethod()
        {
            string expected = "Happy";
            string actual ;
            string input_Message = "Happy";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "WrongAnalyse_Mood";
            string field_Name = "message";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                actual = MoodAnalyzerFactory.SetFields_And_InvokingAnalyseMood(input_Message, field_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_METHODS, e.type);
            }
        }

        /// <summary>
        /// Givens the wrong field name set field value using field information.
        /// </summary>
        [TestMethod]
        public void GivenWrongFieldName_SetFieldValue_UsingFieldInfo()
        {
            string expected = "Happy";
            string actual = "";
            string input_Message = "Happy";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "WrongAnalyse_Mood";
            string field_Name = "WrongMessageField";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                actual = MoodAnalyzerFactory.SetFields_And_InvokingAnalyseMood(input_Message, field_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELDS, e.type);
            }
        }

        
        [TestMethod]
        public void GivenEmptyFieldInput_SetFieldValue_UsingFieldInfo()
        {
            string expected = "Happy";
            string actual = "";
            string input_Message = "I am kinda Sad";
            string class_Name = "MoodAnalyzerApp";
            string method_Name = "WrongAnalyse_Mood";
            string field_Name = "";
            string constructor_Name = "MoodAnalyzerApp";
            try
            {
                actual = MoodAnalyzerFactory.SetFields_And_InvokingAnalyseMood(input_Message, field_Name);
                Assert.AreEqual(expected, actual);
            }
            catch (MoodAnalyserCustomException e)
            {
                Assert.AreEqual(MoodAnalyserCustomException.ExceptionType.NO_SUCH_FIELDS, e.type);
            }
        }




    }
}
