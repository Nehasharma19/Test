using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
using System.Threading;


namespace september2020
{
    class Loginpage
    {
        public void LoginSteps(IWebDriver driver)
        
        {
            Console.WriteLine("Hello World!");
            // Init and define webdriver

            // launch browser and enter the url
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

            // maximise web browser
            driver.Manage().Window.Maximize();

            // identify username textbox and enter username
            IWebElement username = driver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            // identify password textbox and enter password
            IWebElement password = driver.FindElement(By.Id("Password"));
            password.SendKeys("123123");

            // identify login button and click login button
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();
            Thread.Sleep(10000);

            // validate if the user had logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("Logged in successfully, test passed");
            }
            else
            {
                Console.WriteLine("Login failed, test failed");

            }

        }

    }
}