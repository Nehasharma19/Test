using OpenQA.Selenium;
using System;
using System.Threading;

namespace september2020
{
    class TMpages
    {
        public void CreateTM(IWebDriver driver)

        {
            Thread.Sleep(1000);
            // Click Create New
            IWebElement CreateNew = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            CreateNew.Click();
            Thread.Sleep(1000);

            // Click Time in dropdown menu
            IWebElement TypeCode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            TypeCode.Click();


            Thread.Sleep(2000); 

            // Write valid value in Code
            driver.FindElement(By.Id("Code")).SendKeys("12:30");

            // Write valid value in Description
            driver.FindElement(By.Id("Description")).SendKeys("You have assignment due.");

            //(*) Write valid value in Price per unit 
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).SendKeys("100");

            // Click Save 
            IWebElement Save = driver.FindElement(By.Id("SaveButton"));
            Save.Click();
            Thread.Sleep(2000);

            // Validate if the time record is added to the list
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            Thread.Sleep(1500);

            IWebElement expectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement expectedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));

            if (expectedCode.Text == "12:30" && expectedDescription.Text == "You have assignment due.")
            {
                Console.WriteLine("Time was added successfully!");
            }
            else
            {
                Console.WriteLine("Failure to add time record!");
            }
        }




        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //Edit time record
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[1]")).Click();

            Thread.Sleep(1000);

            //new inputs
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys(" Eskimo 12:40");
            driver.FindElement(By.Id("Description")).SendKeys("Eskimo is coming in Sept|");

            //Click save button
            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(1000);

            // click to go to last page
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]")).Click();
            Thread.Sleep(1000);

            //validate if the value is changed
            IWebElement UpdatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if

                (UpdatedCode.Text == "Eskimo 12:40")
            {
                Console.Write("Record is edit successfully");
            }
            else
            {
                Console.Write("Record is edit failed");
            }


        }


        public void DeleteTM(IWebDriver driver)

        {
            //Delete time record
            driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[5]/a[2]")).Click();
            Thread.Sleep(1000);

            // click cancel to cancel delete
            driver.SwitchTo().Alert().Dismiss();

            // click ok to delete the record
            driver.SwitchTo().Alert().Accept();

            //Validate if the record has been deleted
            Thread.Sleep(500);

            IWebElement ExpectedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[1]/td[1]"));
            if (ExpectedCode.Text == "CodeDelete")
            {
                Console.WriteLine("Delete was successfull");

            }
            else
            {
                Console.WriteLine("Delete record failed");
            }



        }
    }
}

