using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursIOCAspNetCore.Models;
using CoursIOCAspNetCore.Interfaces;

namespace CoursIOCAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private ILogger MonLogger;
        private IServiceProvider monService;
        public HomeController(ILogger _logger, IServiceProvider s)
        {
            MonLogger = _logger;
            monService = s;
        }
        public IActionResult Index()
        {
            MonLogger.WriteLog("Test du logger");
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            Personne p = new Personne(monService);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
