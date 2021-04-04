using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPlatesAutomation.NUnitTest.DTO;
using VPlatesAutomation.NUnitTest.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace VPlatesAutomation.NUnitTest
{
    public class VPlatesTest : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized");
            options.AddArguments("--disable-gpu");
            //options.AddArguments("--headless");

            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver(options);
        }
        public void CheckAvailability(List<VPlatesDTO> listVPlatesDTO)
        {
            Driver.Navigate().GoToUrl("https://vplates.com.au");

            using (VPlatesPage vPlatesPage = new VPlatesPage(Driver))
            {
                foreach (var vPlatesDTO in listVPlatesDTO)
                {
                    vPlatesPage.SelectVehicleType(vPlatesDTO);
                    vPlatesPage.EnterSequence(vPlatesDTO);
                    WaitUntilEitherElementDisplayed(By.ClassName("quick-combo__title--available"), By.ClassName("quick-combo__title--unavailable"));
                    vPlatesPage.VerifyAvailability(vPlatesDTO);
                    WaitUntilElementDisplayed(By.Id("quick-combo__combo"));
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
