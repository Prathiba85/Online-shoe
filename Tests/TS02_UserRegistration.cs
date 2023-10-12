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
    public class TS02_UserRegistration
    {


        [TestMethod]
        public void TC02_UserReg_SuccessfulValidation()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            HomePage.click_SignInPortal();

            SignInPage.clickNewRegistration();
            RegistrationPage.select_Salutation();
            RegistrationPage.enter_FirstName();
            RegistrationPage.enter_LastName();
            RegistrationPage.enter_ValidEmail();
            RegistrationPage.enter_UsrName();
            RegistrationPage.enter_Password();
            RegistrationPage.click_Submit();
            Assert.AreEqual("User Registered Successfully !!!", SuccessRegistrationPage.SuccessMsg);

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();

        }
    }
}
