using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace NUnitTestProjectTests
{
    public class Tests
    {
        private const string _userlogin = "natlisjo@gmail.com";
        private const string _userpassword = "1234567";
         
        private IWebDriver driver;
        
        [SetUp]
        public void Setup()
        {

            driver = new  OpenQA.Selenium.Edge.EdgeDriver();

           
           driver.Navigate().GoToUrl("https://www.inet.se/");         
           driver.Manage().Window.Maximize();
        }

        [Test]
        public void LoginTest()
        {

            //Assert.Pass();
            // Ladda ner home page och accept cokkies 
            var acceptCookies = driver.FindElement(By.XPath("//button[normalize-space()='Jag förstår']"));            
            acceptCookies.Click();

            //search line 
            string product = "webbkamera";
            var search = driver.FindElement(By.XPath("//input[@placeholder='Sök bland 12 039 produkter i 567 kategorier']"));
            search.SendKeys(product);

            var searchbutton = driver.FindElement(By.XPath("//span[@class='s1vsg01n fa fa-search']"));
            searchbutton.Click();


            //sortera product
            string sortby = "mest populär";
            SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//select[@aria-label='Välj sorteringsordning i produktlistan']")));
            dropDown.SelectByValue(sortby);

            string actualText = driver.FindElement(By.CssSelector(".selected-value.text-size-14")).Text;
            Assert.True(actualText.Contains(sortby), $"The expected day of the week {sortby} was not selected. The actual text was: {actualText}.");

            //choose product


            // click button "Mina Sida " och redirect to Login page
            //var myAccount = driver.FindElement(By.XPath("//span[text()='Mina sidor']"));
            //myAccount.Click();





            //     var registrateNewUser = driver.FindElement(By.XPath(" "));
            //     registrateNewUser.Click();



            //var loginName = driver.FindElement(By.CssSelector("#loginUsername"));
            //loginName.SendKeys(_userlogin);



            //var _loginPasssword = driver.FindElement(By.Id("loginPassword"));
            //_loginPasssword.SendKeys(_userpassword);
            //var continueLogin = driver.FindElement(By.XPath("//button[@id='btnLogin']"));
            //continueLogin.Click();
        }








        [TearDown]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}