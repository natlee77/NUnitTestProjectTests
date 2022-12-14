using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI; 
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace NUnitTestProjectTests
{ 
    public class Tests
    {
      
        public const string BaseUrlHttps = "https://www.inet.se/";

        private const string _userlogin = "natl999o@gmail.com";
        private const string _userpassword = "1234567";
        private const string _usertelefon = "+46735000000";
        private const string _userPersonnummer = "190006250000";
        private const string _firstName = "Jonson";
        private const string _lastName = "Jonson";
        private const string _userAdress= "Karlskogagatan";
        private const string _userPostNummer = "69333";
        private const string _userPostStade = "Karlskoga";

        private IWebDriver driver;
        
        [SetUp]  // before each
        public void Setup()
        {
           driver = new  OpenQA.Selenium.Edge.EdgeDriver();           
           driver.Manage().Window.Maximize();

          
        }
 
       

        [Test]
        public void HomePageTest()
        {
            driver.Navigate().GoToUrl(BaseUrlHttps);
            Assert.That(driver.Url, Is.EqualTo(BaseUrlHttps));
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
            string sortby = "Mest populär";
            SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@aria-label='Välj sorteringsordning i produktlistan']")));
            dropDown.SelectByText(sortby);  
            Thread.Sleep(2000);
           

            //choose product for review
            var product1 = driver.FindElement(By.XPath("//h4[normalize-space()='Logitech C920 HD Pro']"));          
            Assert.That(driver.FindElement(By.XPath("//h4[normalize-space()='Logitech C920 HD Pro']")).Text, Is.EqualTo("Logitech C920 HD Pro"));
            product1.Click();

            // check if picture 
            var logittechImage = driver.FindElements(By.XPath("//img[@class='ibv243h']"));
            Assert.True(logittechImage.Count > 0);

            // Add to shoping cart 
            var addProduct1ToShoppingCart = driver.FindElement(By.XPath("//button[normalize-space()='Köp']"));
            addProduct1ToShoppingCart.Click();            
            Thread.Sleep(2000);


            // go to Kassa 
            var toShoppingCart = driver.FindElement(By.LinkText("Till kassan"));
            toShoppingCart.Click();
             
         

            // change amount of product  + -     
            var addAmount = driver.FindElement(By.XPath("//button[normalize-space()='+']"));
            addAmount.Click();
            Thread.Sleep(2000);
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

            var takeAdressByPersonNummer = driver.FindElements(By.XPath("//button[normalize-space()='Hämta adress']"));
            Assert.True(takeAdressByPersonNummer.Count > 0); 

            var loginAdress = driver.FindElement(By.XPath("//input[@id='streetAddress']"));
            loginAdress.SendKeys(_userAdress);
            Thread.Sleep(2000);

            var loginPostNummer = driver.FindElement(By.XPath("//input[@id='zipCode']"));
            loginPostNummer.SendKeys(_userPostNummer);
            Thread.Sleep(2000);

            var loginPostStade = driver.FindElement(By.XPath("//input[@class='f1tuanv9 form-control']"));
            loginPostStade.SendKeys(_userPostStade);
            Thread.Sleep(2000);

             var registrateNewUser = driver.FindElements(By.XPath("//button[@type='submit']"));
             Assert.True(registrateNewUser.Count > 0);
            //registrateNewUser.Click();                                              
        }


                  /***   * Tests login feature  */

        [Test]
        public void LoginTest()
        {

            driver.Navigate().GoToUrl(BaseUrlHttps);
            Assert.That(driver.Url, Is.EqualTo(BaseUrlHttps));
            driver.FindElement(By.XPath("//button[normalize-space()='Jag förstår']")).Click();

            // Login in  MyAccount   

            driver.FindElement(By.XPath("//label[normalize-space()='Min sida']")).Click();            
            Thread.Sleep(2000);

            var loginName = driver.FindElement(By.XPath("//input[@id='login.email']"));
            loginName.SendKeys(_userlogin);
            Thread.Sleep(2000);

            var _loginPasssword = driver.FindElement(By.XPath("//input[@id='password']"));
            _loginPasssword.SendKeys(_userpassword);
            Thread.Sleep(2000);

            var continueLogin = driver.FindElements(By.XPath("//button[normalize-space()='Logga in']"));
            Assert.True(continueLogin.Count > 0);
             
        }
        [TearDown] // efter each
        public void TearDown()
        {
            driver.Quit();
            
        }
       
    }
}