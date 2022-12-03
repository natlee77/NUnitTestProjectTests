using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace NUnitTestProjectTests
{
    public class Tests
    {
        private const string _userlogin = "natlisjo@gmail.com";
        private const string _userpassword = "1234567";

        //static FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\abcd\Downloads\geckodriver-v0.13.0-win64", "geckodriver.exe");
        //service.FirefoxBinaryPath= @"D:\Program Files\Mozilla\firefox.exe";
        //service.Port = 64444;        
        //service.HideCommandPromptWindow = true;
        //service.SuppressInitialDiagnosticInformation = true;


        IWebDriver Driver = new FirefoxDriver();

        private IWebDriver driver;
        public static string driverpath = @"D:\Program Files\Mozilla\firefox.exe"; //find the web driver path

        [SetUp]
        public void Setup()
        {

            driver = new FirefoxDriver(driverpath);
                         //OpenQA.Selenium.Edge.EdgeDriver();

           
           driver.Navigate().GoToUrl("https://www.obo.se/");
        //https://www.obo.se
            // https://www.zalando.se
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTest()
        {

            ////Assert.Pass();
            var acceptCookies = driver.FindElement(By.Id("wt-cli-accept-all-btn"));
            ////(By.XPath("//button[@id='uc-btn-deny-banner']"));
            ////
            acceptCookies.Click();

            var signIn = driver.FindElement(By.XPath("//span[text()='Mina sidor']"));
            signIn.Click();




            //var loginName = "return window.getComputedStyle(document.querySelector('#loginUsername'),':before') ";
            //JavascriptExecutor js = (JavascriptExecutor)driver;
            // String content = (String)js.executeScript(loginName);
            // System.out.println(_userlogin);

            var loginName = driver.FindElement(By.CssSelector("input#loginUsername"));
            loginName.SendKeys(_userlogin);
            //(By.Id("loginUsername"));               
            //(By.XPath("//*[@id='loginUsername']"));
             

            //var _loginPasssword = driver.FindElement(By.Id("loginPassword"));
            // _loginPasssword..SendKeys(_userpassword);
            //var  continueLogin = driver.FindElement(By.XPath("//button[@id='btnLogin']"));
            //continueLogin.Click();
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