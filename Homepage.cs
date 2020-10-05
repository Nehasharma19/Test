using System;
using OpenQA.Selenium;

namespace september2020
{
    public class Homepage
    {
        public void NavigateToTM(IWebDriver driver)
        {
            // click administration
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul[1]/li[5]/a")).Click();
            
            //click time and material
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            

        }
        
    }
}
