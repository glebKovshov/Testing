using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SocialNetwork.Pages;
using System.Windows;

namespace UnitTestSocialNetwork
{
    
    [TestClass]
    public class UnitTestReg
    {
        private SocialNetwork.Pages.Registration page = new Registration(true);

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            if (System.Windows.Application.Current == null)
            {
                new SocialNetwork.App();
            }
            var uri = new Uri("/SocialNetwork;component/Styles.xaml", UriKind.RelativeOrAbsolute);

            Application.Current.Resources.MergedDictionaries.Add(
                new ResourceDictionary { Source = uri }
            );
        }
        [TestMethod]
        public void TestReg_WithEmptyData()
        {
            Assert.IsFalse(page.SignUp("", "", "", ""));
        }
        [TestMethod]
        public void TestReg_WithOnlyLogin()
        {
            Assert.IsFalse(page.SignUp("testlogin", "", "", ""));
        }
        [TestMethod]
        public void TestReg_WithoutPassword()
        {
            Assert.IsFalse(page.SignUp("testlogin", "testlogin@testlogin.com", "", ""));
        }
        [TestMethod]
        public void TestReg_WithoutConfirmPassword()
        {
            Assert.IsFalse(page.SignUp("testlogin", "testlogin@testlogin.com", "password", ""));
        }
        [TestMethod]
        public void TestReg_WithDifferentPasswords()
        {
            Assert.IsFalse(page.SignUp("testlogin", "testlogin@testlogin.com", "password", "password1"));
        }
        [TestMethod]
        public void TestReg_WithValidData()
        {
            Assert.IsTrue(page.SignUp("testlogin", "testlogin@testlogin.com", "password", "password"));
        }
        [TestMethod]
        public void TestReg_WithCreatedUser()
        {
            Assert.IsFalse(page.SignUp("kovshovgleb", "testlogin@testlogin.com", "password", "password"));
        }
    }
}
