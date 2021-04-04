using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VPlatesAutomation.NUnitTest
{
    public class DriverHelper
    {
        public IWebDriver Driver { get; set; }

        public bool WaitForPageLoad(string oldUrl)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(x => x.Url != oldUrl);
        }
        public bool WaitForPageHasLoaded(string newUrl)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(x => x.Url == newUrl);
        }
        public bool WaitUntilElementDisplayed(By by)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(x => x.FindElements(by).Count > 0);
        }
        public bool WaitUntilEitherElementDisplayed(By byFirst, By bySecond)
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(60)).Until(x => 
                x.FindElements(byFirst).Count > 0 ||
                x.FindElements(bySecond).Count > 0
            );
        }
    }
}
