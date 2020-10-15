using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoodAnalyzer;

namespace MoodAnalyzerTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
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
        [TestMethod]
        public void TestMethod2()
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
        [TestMethod]
        public void TestMethod3()
        {
            string expected_SadMood = "sad";
            string expected_HappyMood = "happy";
            string input_Message = null;
            object expected_Object = new MoodAnalyzerApp(input_Message);
            object actual_Object = MoodAnalyzerFactory.Create_Mood_Analyser_Object();
            Assert.AreEqual(expected_Object.GetType(), actual_Object.GetType());
            //expected_Object.Equals(actual_Object);

        }
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


    }
}
