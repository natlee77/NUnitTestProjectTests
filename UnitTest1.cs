using NUnit.Framework;
using OpenQA.Selenium;
 

namespace NUnitTestProjectTests
{
    public class Tests
    {
        private const string _userlogin = "natlisjo@gmail.com";
        private const string _userpassword = "1234567";
         
        private IWebDriver driver;
        public static string driverpath = @"D:\Program Files\Mozilla\firefox.exe"; //find the web driver path

        [SetUp]
        public void Setup()
        {

            driver = new  OpenQA.Selenium.Edge.EdgeDriver();

           
           driver.Navigate().GoToUrl("https://www.obo.se/");
        //https://www.obo.se
            // https://www.zalando.se
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTest()
        {

            //Assert.Pass();
            // Ladda ner home page och accept cokkies 
            var acceptCookies = driver.FindElement(By.Id("wt-cli-accept-all-btn"));            
            acceptCookies.Click();
            // click button "Mina Sida " och redirect to Login page
            var myAccount = driver.FindElement(By.XPath("//span[text()='Mina sidor']"));
            myAccount.Click();




            //var loginName = "return window.getComputedStyle(document.querySelector('#loginUsername'),':before') ";
            //JavascriptExecutor js = (JavascriptExecutor)driver;
            // String content = (String)js.executeScript(loginName);
            // System.out.println(_userlogin);

            var loginName = driver.FindElement(By.CssSelector("input#loginUsername"));
            loginName.SendKeys(_userlogin);
            //(By.Id("loginUsername"));               
            //(By.XPath("//*[@id='loginUsername']"));


            var _loginPasssword = driver.FindElement(By.Id("loginPassword"));
            _loginPasssword.SendKeys(_userpassword);
            var continueLogin = driver.FindElement(By.XPath("//button[@id='btnLogin']"));
            continueLogin.Click();
        }




        //private readonly By _loginInputButton = By.XPath("//input[@id='loginUsername']");
        //private readonly By _loginPasswordButton = By.XPath("//input[@id='loginPassword']");


        //     var registrateNewUser = driver.FindElement(By.XPath(" "));
        //     registrateNewUser.Click();





        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}