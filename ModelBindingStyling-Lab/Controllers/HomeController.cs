using Microsoft.AspNetCore.Mvc;
using ModelBindingStyling_Lab.Models;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;

namespace ModelBindingStyling_Lab.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserProfile()
        {
            UserProfile user = GetUserProfileData();
            return View(user);
        }

        public IActionResult PrinterList()
        {
            IEnumerable<ThreeDPrinters> printers = GetPrinterList();
            return View(printers);
        }

        /// <summary>
        /// Returns a list of 3d printers with test data for use
        /// on a view to practice modelbinding
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ThreeDPrinters> GetPrinterList()
        {
            return new List<ThreeDPrinters>()
            {
                new ThreeDPrinters
                {
                    BuildVolume = "180 x 180 x 180 mm",
                    Price = 499.99,
                    SKU = "SMLPRINTER7",
                    Title = "The mini printer",
                    PrinterImage = "src=/img/printer1.jpg" 
                },
                new ThreeDPrinters
                {
                    BuildVolume = "300 x 300 x 300 mm",
                    Price = 899.99,
                    SKU = "MEDPRINTER12",
                    Title = "Mega Printer",
                    PrinterImage = "src=/img/printer2.jpg"
                },
                new ThreeDPrinters 
                {
                    BuildVolume = "360 x 360 x 360 mm",
                    Price = 999.99,
                    SKU = "MEDPRINTER12P",
                    Title = "Mega Printer Plus",
                    PrinterImage = "src=/img/printer3.jpg"
                },
                new ThreeDPrinters 
                {
                    BuildVolume = "360 x 360 x 500 mm",
                    Price = 899.99,
                    SKU = "GIGANTOR10",
                    Title = "Mega Printer",
                    PrinterImage = "src=/img/printer4.jpg"
                }
            };
        }

        /// <summary>
        /// This method returns hardcoded data for a UserProfile
        /// to use with modelbinding on a view
        /// </summary>
        private UserProfile GetUserProfileData()
        {
            return new UserProfile()
            {
                DateOfBirth = new DateOnly(1875, 7, 1),
                Email = "bestAtWhatIDo@claws.com",
                FullName = "Wolverine",
                GitHubUrl = "https://github.com/Octocat",
                ImageUrl = "https://via.placeholder.com/150",
                PhoneNumber = "(253) 555-1234",
                UserProfileId = 10,
                SkilledLanguages = new List<string> { "Fighting" }
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}