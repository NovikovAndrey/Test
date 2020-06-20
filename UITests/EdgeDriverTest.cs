using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;

namespace UITests
{

    public class ChromeDriverTest
    {
        // In order to run the below test(s), 
        // please follow the instructions from http://go.microsoft.com/fwlink/?LinkId=619687
        // to install Microsoft WebDriver.

        private ChromeDriver driver;

        [SetUp]
        public void ChromeDriverInitialize()
        {
            // Initialize edge driver 

            driver = new ChromeDriver(@".\");
        }

        [TestCase(13, "Mar", 2019, 24, "Jul", 2019)]
        public void VerifyPageTitle(int startDay, string startMonth, int startYear, int endDay, string endMonth, int endYear)
        {
            // Replace with your own test logic
            driver.Url = "https://localhost:44388/";
            IWebElement dropdown = driver.FindElement(By.XPath("//button[@id='dropdown']"));
            dropdown.Click();

            IWebElement dropdownChanged = driver.FindElement(By.XPath("//div[2]/button[@id='option' and @class='dropdown-item' and 1]"));
            dropdownChanged.Click();

            #region StartDate
            IWebElement startDate = driver.FindElement(By.XPath("//input[1]"));
            startDate.Click();

            IWebElement startDateYear = driver.FindElement(By.XPath("//select[2]"));
            startDateYear.Click();


            var selects = driver.FindElementsByTagName("select");
            var month = selects[0];
            var years = selects[1];
            var optionsYear = years.FindElements(By.TagName("option"));
            var elemYear = optionsYear.FirstOrDefault(item => item.Text == startYear.ToString());
            elemYear.Click();

            var optionsMonth = month.FindElements(By.TagName("option"));
            var elemMonth = optionsMonth.FirstOrDefault(item => item.Text == startMonth);
            elemMonth.Click();

            IWebElement startDateChangeDay = driver.FindElement(By.XPath($"//div[@class='btn-light' and text()='{startDay}']"));
            startDateChangeDay.Click();
            #endregion

            #region EndDate
            IWebElement endDate = driver.FindElement(By.XPath("//input[2]"));
            endDate.Click();

            IWebElement endDateYear = driver.FindElement(By.XPath("//select[2]"));
            endDateYear.Click();


            selects = driver.FindElementsByTagName("select");
            month = selects[0];
            years = selects[1];
            optionsYear = years.FindElements(By.TagName("option"));
            elemYear = optionsYear.FirstOrDefault(item => item.Text == endYear.ToString());
            elemYear.Click();

            optionsMonth = month.FindElements(By.TagName("option"));
            elemMonth = optionsMonth.FirstOrDefault(item => item.Text == endMonth);
            elemMonth.Click();

            IWebElement endDateChangeDay = driver.FindElement(By.XPath($"//div[@class='btn-light' and text()='{endDay}']"));
            endDateChangeDay.Click();
            #endregion

            startDate = driver.FindElement(By.XPath("//input[1]"));
            endDate = driver.FindElement(By.XPath("//input[2]"));
            string s1 = startDate.GetProperty("value");
            string s2 = endDate.Text;
            bool res1 = startDate.Equals($"{startMonth}/{startDay}/{startYear}");
            bool res2 = endDate.Text.Equals($"{endMonth}/{endDay}/{endYear}");

            Assert.AreEqual(true,res1 && res2);
        }

        [TearDown]
        public void EdgeDriverCleanup()
        {
            // driver.Quit();
        }
    }
}
