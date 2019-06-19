using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PanierAspNetCore.Models;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Controllers
{
    public class PanierController : Controller
    {
        //private IHttpContextAccessor accessor;

        //public PanierController(IHttpContextAccessor a)
        //{
        //    accessor = a;
        //}
        public IActionResult Index()
        {
            Panier panier = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("panier"));
            return View(panier);
        }

        public IActionResult AddProduit(int id)
        {
            Panier panier = HttpContext.Session.GetString("panier") != null ? JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("panier")) : new Panier() ;
            Produit p = DataBaseContext.Instance.Produits.FirstOrDefault(x => x.Id == id);
            if(p != null)
            {
                ProduitPanier pPanier = panier.produits.FirstOrDefault(x => x.ProduitId == p.Id);
                if(pPanier != null)
                {
                    pPanier.Qty++;
                }
                else
                {
                    pPanier = new ProduitPanier { ProduitId = p.Id, produit = p, Qty = 1 };
                    panier.produits.Add(pPanier);
                }
            }

            HttpContext.Session.SetString("panier", JsonConvert.SerializeObject(panier));
            return RedirectToAction("Index");
        }

        public IActionResult SavePanier()
        {
            Panier panier = JsonConvert.DeserializeObject<Panier>(HttpContext.Session.GetString("panier"));
            if(panier != null)
            {
                DataBaseContext.Instance.Paniers.Add(panier);
                DataBaseContext.Instance.SaveChanges();
                HttpContext.Session.Remove("panier");
            }
            return RedirectToAction("Index", "Produit");
        }
    }
}
