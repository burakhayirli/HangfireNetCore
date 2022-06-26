using Hangfire.Web.BackgroundJobs;
using Hangfire.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hangfire.Web.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SignUp()
        {
            FireAndForgetJobs.EmailSendToUserJob("1", "Sitemize hoş geldiniz.");

            return View();
        }

        public IActionResult PictureSave()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PictureSave(IFormFile picture)
        {
            string newFilename = String.Empty;

            if (picture != null && picture.Length > 0)
            {
                newFilename = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures", newFilename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                string jobId = BackgroundJobs.DelayedJobs.AddWatermarkJob(newFilename,"www.burakhayirli.com");
            }

            return View();
        }


    }
}
