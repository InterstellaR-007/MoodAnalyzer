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
    }
}
