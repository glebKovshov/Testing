using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SocialNetwork.Pages;
using System.Windows;

namespace UnitTestSocialNetwork
{
    [TestClass]
    public class UnitTestAuth
    {
        private SocialNetwork.Pages.Authorization page = new Authorization(true);
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
        public void AuthTest_WithValidData()
        {
            Assert.IsTrue(page.SignIn("testuser", "testpassword"));
        }
        [TestMethod]
        public void AuthTest_WithInvalidData()
        {
            Assert.IsFalse(page.SignIn("testuser1", "testpassword2"));
        }
        [TestMethod]
        public void AuthTest_WithEmptyData()
        {
            Assert.IsFalse(page.SignIn("", ""));
        }

    }

}