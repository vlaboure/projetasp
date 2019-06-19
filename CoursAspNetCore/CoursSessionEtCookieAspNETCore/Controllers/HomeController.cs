using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursSessionEtCookieAspNETCore.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace CoursSessionEtCookieAspNETCore.Controllers
{
    public class HomeController : Controller
    {
        //private IHttpContextAccessor httpContext;

        public HomeController()
        {
            //httpContext = _h;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            Personne p = JsonConvert.DeserializeObject<Personne>(HttpContext.Session.GetString("personne"));
            ViewData["Message"] = p.Nom +" "+p.Prenom;

            return View();
        }

        public IActionResult AddSession(Personne p)
        {
            HttpContext.Session.SetString("personne", JsonConvert.SerializeObject(p));
            return RedirectToAction("Index");
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

        public IActionResult ReadCookie()
        {
            string valueCookie = Request.Cookies["cleCookie"];
            return new ContentResult() { Content = valueCookie};
        }

        public IActionResult CreateCookie()
        {
            CookieOptions o = new CookieOptions()
            {
                Expires = DateTime.Now.AddHours(1)
            };
            Response.Cookies.Append("cleCookie", "ValueCookie",o);
            return RedirectToAction("Index");
        }
    }
}
