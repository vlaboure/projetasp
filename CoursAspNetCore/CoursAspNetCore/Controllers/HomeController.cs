using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursAspNetCore.Models;

namespace CoursAspNetCore.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult MonAction()
        {
            //par defaut on cherche la vue avec le meme nom que l'action dans un dossier qui porte le nom du controller à l'interieur du dossier Views
            //return View();
            //On cherche la vue qui porte le nom contact à l'interieur du dossier du même nom que le controller à l'interieur du dosser Views
            //return View("Contact");
            //on peut aussi retourner une vue par son chemin
            //return View("~/Views/Home/Contact.cshtml");
            //retourne une view sans utilisation d'une viewstart
            return PartialView();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

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
