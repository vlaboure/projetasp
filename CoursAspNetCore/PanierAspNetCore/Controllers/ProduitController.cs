using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanierAspNetCore.Interface;
using PanierAspNetCore.Models;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Controllers
{
    public class ProduitController : Controller
    {
        private ILogin serviceLogin;

        public ProduitController(ILogin i)
        {
            serviceLogin = i;
        }
        public IActionResult Index()
        {
            
            return View(DataBaseContext.Instance.Produits.ToList());
        }

        public IActionResult AddProduit()
        {
            if (serviceLogin.Logged(Request))
                return View();
            else
                return RedirectToAction("Login", "User");
        }

        [HttpPost]
        public IActionResult AddProduit(Produit p, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                p.Add(image,"http://"+Request.Host.Value);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddProduit");
            }
        }
    }
}
