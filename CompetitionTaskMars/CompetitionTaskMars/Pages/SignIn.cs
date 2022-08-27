﻿using OpenQA.Selenium;
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
    internal class SignIn:CommonDriver
    {
        //private IWebDriver driver;
        /*public  SignIn(IWebDriver driver)
        {

        //initial driver object
           driver = driver;
        
            PageFactory.InitElements(driver,this);
        }*/
        //Find signin button

        private IWebElement SignInButton => driver.FindElement(By.XPath("//*[@id='home']/div/div/div[1]/div/a"));
        
        //find username
        private IWebElement UserName => driver.FindElement(By.XPath("//input[@name='email']"));
        
        //find password
        private IWebElement PassWord => driver.FindElement(By.XPath("//input[@name='password']"));

        //Find Login button
        private IWebElement LoginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));

        private IWebElement Loginmessage => driver.FindElement(By.XPath("//div/div[1]/div[2]/div/span"));

        public void NavigatetoHomepage()
        {
            // ChromeDriver driver= new ChromeDriver();
            //driver.Manage().Window.Maximize();
            //enter the project url
            //driver.Navigate().GoToUrl("http://localhost:5000/");
            Thread.Sleep(2000);
           
           
               GlobalDefinitions.ExcelLib.PopulateInCollection(CommonDriver.ExcelPath, "signIn");

            driver.Navigate().GoToUrl(GlobalDefinitions.ExcelLib.ReadData(2, "Url"));
            SignInButton.Click();
            UserName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "UserName"));
                Thread.Sleep(1000);
               PassWord.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "PassWord"));
                Thread.Sleep(1000);
               LoginButton.Click();
                Thread.Sleep(5000);
                //Assert.That(Loginmessage.Text == "Hi sathya", "not login successfully");
                    
                
           


        }
    }
}