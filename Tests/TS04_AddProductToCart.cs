using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class TS04_AddProductToCart
    {


        [TestMethod]
        public void TC04_AdddProductToCart()
        {

            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("-no-sandbox");
            PropertiesCollections.driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
            PropertiesCollections.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["URL"]);

            HomePage.click_SignInPortal();

            SignInPage.enterUserName();
            SignInPage.enterPassword();
            SignInPage.clickLogin();
            ShoeTypes.clickFormalShoeCollection();
            FormalShoesTypes.Add_Product_to_Cart();
            Assert.AreEqual("Added to Cart Successfully !!!", SuccessProductToCart.SuccessMsg);

            PropertiesCollections.driver.Close();
            PropertiesCollections.driver.Quit();
        }
    }
}
