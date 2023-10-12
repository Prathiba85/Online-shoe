﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineShoePortal.PageObjects;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoePortal.Tests
{
    [TestClass]
    public class TS03_UserLogin
    {


        [TestMethod]
        public void TC03_UserLogin_ErrValidation()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            HomePage.click_SignInPortal();

            SignInPage.clickLogin();
            Assert.AreEqual("Both Username and Password field are required", SignInPage.txtUsrPwdErrorMsg);

            SignInPage.enterUserName();
            SignInPage.clickLogin();
            Assert.AreEqual("Both Username and Password field are required", SignInPage.txtUsrPwdErrorMsg);

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();
        }
    }
}
