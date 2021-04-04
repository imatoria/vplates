using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VPlatesAutomation.NUnitTest.DTO;

namespace VPlatesAutomation.NUnitTest.Pages
{
    public class VPlatesPage: IDisposable
    {
        IWebDriver Driver { get; set; }
        IWebElement radTypeCar => Driver.FindElement(By.Id("quick-combo__type-car"));
        IWebElement radTypeMotorcycle => Driver.FindElement(By.Id("quick-combo__type-motorcycle"));
        IWebElement txtQuickCombo => Driver.FindElement(By.Id("quick-combo__combo"));
        IWebElement btnCheckAvailability => Driver.FindElement(By.ClassName("quick-combo__submit"));
        ReadOnlyCollection<IWebElement> h2Available => Driver.FindElements(By.ClassName("quick-combo__title--available"));
        IWebElement btnReset => Driver.FindElement(By.ClassName("quick-combo__reset"));

        public VPlatesPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void SelectVehicleType(VPlatesDTO vPlatesDTO)
        {
            if (vPlatesDTO.Type == "CAR")
            {
                if (radTypeCar.Selected == false)
                {
                    radTypeCar.Click();
                }
            }
            else
            {
                if (radTypeMotorcycle.Selected == false)
                {
                    radTypeMotorcycle.Click();
                }
            }
        }
        public void EnterSequence(VPlatesDTO vPlatesDTO)
        {
            txtQuickCombo.SendKeys(vPlatesDTO.Sequence);
            btnCheckAvailability.Click();

        }
        public void VerifyAvailability(VPlatesDTO vPlatesDTO)
        {
            //vPlatesDTO.IsChecked = true;
            vPlatesDTO.IsAvailable = h2Available.Count > 0;
            btnReset.Click();

        }

        public void Dispose()
        {
            Driver.Close();
        }
    }
}
