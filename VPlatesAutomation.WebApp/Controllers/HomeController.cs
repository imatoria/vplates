using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPlatesAutomation.NUnitTest;
using VPlatesAutomation.NUnitTest.DTO;

namespace VPlatesAutomation.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("home")]
        [Route("home/index")]
        public IActionResult Index()
        {
            var listVPlatesDTO = new List<VPlatesDTO>
            {
                new VPlatesDTO
                {
                    Type = "CAR",
                    Sequence = "MELBOU"
                },
                new VPlatesDTO
                {
                    Type = "CAR",
                    Sequence = "SYDNEY"
                },
                new VPlatesDTO
                {
                    Type = "CAR",
                    Sequence = "BRISBA"
                },
                new VPlatesDTO
                {
                    Type = "CAR",
                    Sequence = "PERTH"
                }
            };

            var vPlatesTest = new VPlatesTest();
            vPlatesTest.Setup();
            vPlatesTest.CheckAvailability(listVPlatesDTO);
            vPlatesTest.TearDown();

            return View("Index", listVPlatesDTO);
        }
    }
}
