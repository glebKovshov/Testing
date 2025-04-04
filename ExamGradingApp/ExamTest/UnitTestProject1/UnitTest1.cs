using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExamGradingApp;
using System.Security.Principal;

namespace ExamGradingAppTest
{
    [TestClass]
    public class UnitTest1
    {
        MainWindow window = new ExamGradingApp.MainWindow();
        [TestMethod]
        public void TestWithMaxValues()
        {
            Assert.AreEqual(window.GetGrade(80), window.Calculate(22, 38, 20));
        }
        [TestMethod]
        public void TestWithAverageValues()
        {
            Assert.AreEqual(window.GetGrade(67), window.Calculate(22, 30, 15));
        }
        [TestMethod]
        public void TestWithZeroValues()
        {
            Assert.AreEqual(window.GetGrade(0), window.Calculate(0, 0, 0));
        }
        [TestMethod]
        public void TestWithInvalidValues()
        {
            Assert.AreEqual("None", window.Calculate(100, 0, 0));
        }
        [TestMethod]
        public void TestWithNegativeValues()
        {
            Assert.AreEqual("None", window.Calculate(-5, 20, -1));
        }
    }
}
