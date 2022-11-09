using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using CompetitionTaskMars.Utilities;
using CompetitionTaskMars.Utilities;
using static CompetitionTaskMars.Utilities.GlobalDefinitions;

namespace CompetitionTaskMars.Pages
{
    public class SignIn:CommonDriver
    {
        //private IWebDriver driver;
        /*public  SignIn(IWebDriver driver)
        {

        //initial driver object
           driver = driver;
        
            PageFactory.InitElements(driver,this);
        }*/
        //Find signin button

        public IWebElement SignInButton => driver.FindElement(By.XPath("//div/div/div[1]/div/a"));
        
        //find username
        public IWebElement UserName => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[1]/input"));
        
        //find password
        public IWebElement PassWord => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[2]/input"));

        //Find Login button
        public IWebElement LoginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        public IWebElement Loginmessage => driver.FindElement(By.XPath("//div/div[1]/div[2]/div/span"));

        public void NavigatetoHomepage()
        {
            
            Thread.Sleep(2000);
           
           
               GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "signIn");
           // GlobalDefinitions.WaitToBeClickable(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a", 5);
            driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            SignInButton.Click();
            UserName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"));
                Thread.Sleep(1000);
               PassWord.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "PassWord"));
                Thread.Sleep(1000);
               LoginButton.Click();
                Thread.Sleep(5000);
                               
                
           


        }
        public void TestNegative()
        {
            GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "signIn");
            //GlobalDefinitions.WaitToBeClickable(driver, "XPath", "//*[@id='home']/div/div/div[1]/div/a", 5);
            driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(3, "Url"));
            SignInButton.Click();
            UserName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "UserName"));
            Thread.Sleep(1000);
            PassWord.SendKeys(GlobalDefinitions.ExcelLib.ReadData(3, "PassWord"));
            Thread.Sleep(1000);
            LoginButton.Click();
            Thread.Sleep(5000);
        }
    }
}