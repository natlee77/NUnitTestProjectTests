﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace NUnitTestProjectTests
{
    public class Tests
    {
        private const string _userlogin = "natlisjo@gmail.com";
        private const string _userpassword = "1234567";
        private const string _usertelefon = "+46735000000";
        private const string _userPersonnummer = "197106255248";
        private const string _firstName = "Jonson";
        private const string _lastName = "Jonson";
        private const string _userAdress= "Karlskogagatan";
        private const string _userPostNummer = "69333";
        private const string _userPostStade = "Karlskoga";
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {

            driver = new  OpenQA.Selenium.Edge.EdgeDriver();

           
           driver.Navigate().GoToUrl("https://www.inet.se/");         
           driver.Manage().Window.Maximize();


          
        }
        //public   void WaitForElementLoad(By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        wait.Until(ExpectedConditions.ElementIsVisible(by));
        //    }
        //}
        [Test]
        public void LoginTest()
        {
            
            //Assert.Pass();
            // Ladda ner home page och accept cokkies 
            var acceptCookies = driver.FindElement(By.XPath("//button[normalize-space()='Jag förstår']"));            
            acceptCookies.Click();
           
            //search line 
            string product = "webbkamera";
            var search = driver.FindElement(By.XPath("//input[@class='ia1wvbu form-control']"));
            search.SendKeys(product);

            var searchbutton = driver.FindElement(By.XPath("//span[@class='s1vsg01n fa fa-search']"));
            searchbutton.Click();


            //sortera product
            //string sortby = "Mest populär";
            //SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@aria-label='Välj sorteringsordning i produktlistan']")));
            //dropDown.SelectByValue(sortby);

            //string actualText = driver.FindElement(By.CssSelector(".selected")).Text;
            //Assert.True(actualText.Contains(sortby), $"The expected value {sortby} was not selected. The actual text was: {actualText}.");

            //choose product for review
            var product1 = driver.FindElement(By.XPath("//h4[normalize-space()='Logitech C920 HD Pro']"));
            product1.Click();


            // Add to shoping cart 
            var addProduct1ToShoppingCart = driver.FindElement(By.XPath("//button[normalize-space()='Köp']"));
            addProduct1ToShoppingCart.Click();
            //addProduct1ToShoppingCart.WaitForElementLoad(By.XPath("//button[normalize-space()='Köp']",10));
            Thread.Sleep(3000);



            // go to Kassa 
            var toShoppingCart = driver.FindElement(By.LinkText("Till kassan"));
            toShoppingCart.Click();



            // change amount of product  + -     
            var addAmount = driver.FindElement(By.XPath("//button[normalize-space()='+']"));
            addAmount.Click();
            Thread.Sleep(3000);
            var lessAmount = driver.FindElement(By.XPath("//button[normalize-space()='-']"));
            lessAmount.Click();
            Thread.Sleep(3000);



            //       registrate New User Info
            var loginEmail = driver.FindElement(By.XPath("//input[@id='email']"));
            loginEmail.SendKeys(_userlogin);
            Thread.Sleep(2000);

            var loginTelefon = driver.FindElement(By.XPath("//input[@id='cellPhone']"));
            loginTelefon.SendKeys(_usertelefon);
            Thread.Sleep(2000);

            var loginPersonNummer = driver.FindElement(By.XPath("//input[@id='organizationNo']"));
             loginPersonNummer.SendKeys(_userPersonnummer);
            Thread.Sleep(2000);

            var loginFirstName = driver.FindElement(By.XPath("//input[@id='firstName']"));
            loginFirstName.SendKeys(_firstName);
            Thread.Sleep(2000);

            var loginLastName = driver.FindElement(By.XPath("//input[@id='lastName']"));
             loginLastName.SendKeys(_lastName);
            Thread.Sleep(2000);

            var loginAdress = driver.FindElement(By.XPath("//input[@id='streetAddress']"));
            loginAdress.SendKeys(_userAdress);
            Thread.Sleep(2000);

            var loginPostNummer = driver.FindElement(By.XPath("//input[@id='zipCode']"));
            loginPostNummer.SendKeys(_userPostNummer);
            Thread.Sleep(2000);

            var loginPostStade = driver.FindElement(By.XPath("//input[@class='f1tuanv9 form-control']"));
            loginPostStade.SendKeys(_userPostStade);
            Thread.Sleep(2000);

            //var registrateNewUser = driver.FindElement(By.XPath("//button[@type='submit']"));
            //registrateNewUser.Click();

            // Login in  MyAccount

            var loginInAccount = driver.FindElement(By.XPath("//label[@class='lnp1qmo']"));
            loginInAccount.Click();

            var loginName = driver.FindElement(By.XPath("//input[@id='login.email']"));
            loginName.SendKeys(_userlogin);

            var _loginPasssword = driver.FindElement(By.XPath("//input[@id='password']"));
            _loginPasssword.SendKeys(_userpassword);

            var continueLogin = driver.FindElement(By.XPath("//button[normalize-space()='Logga in']"));
            continueLogin.Click();
        }








        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}