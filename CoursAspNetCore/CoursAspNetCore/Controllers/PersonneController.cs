using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using CoursAspNetCore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class PersonneController : Controller
    {
        public IActionResult Accueil()
        {
            //ViewData
            //ViewData["nom"] = "abadi";
            //ViewData["prenom"] = "Ihab";
            //ViewData["ListeString"] = new List<string> { "toto", "tata", "titi" };
            //ViewBag
            ViewBag.nom = "abadi";
            ViewBag.prenom = "Ihab";
            ViewBag.ListeString = new List<string> { "toto", "tata", "titi" };

            ViewBag.ListePersonnes = new List<Personne>
            {
                new Personne {Nom = "toto", Prenom = "tata"},
                new Personne {Nom = "titi", Prenom = "minet"},
            };
            
            return View();
        }

        //Methode de redirection

        public IActionResult Operation()
        {
            //redirection vers une action à l'interieur du même controller
            //return RedirectToAction("Accueil");

            //redirection vers une action d'un autre controller
            //return RedirectToAction("Index", "Home");

            //Autre methode de redirection
            //redirection de type 301 <=> permanente
            //return RedirectPermanent("Lien de redirection");

            //redirect to route
            //return RedirectToRoute(new { controller = "Home", action = "Index" });

            //redirect to route en utilisant le nom de la route
            return RedirectToRoute("RoutePersonne");
        }


        //public IActionResult GetPersonne()
        //{
        //    Personne p = new Personne { Id = 1, Nom = "abadi", Prenom = "ihab" };
            
        //    return View(p);
        //}

        public IActionResult GetPersonne()
        {
            Personne p = new Personne { Id = 1, Nom = "abadi", Prenom = "ihab" };
            Adresse a = new Adresse { PersonneId = 1, Id = 1, Ville = "Tourcoing", Rue = "rue de paris" };
            GetPersonneViewModel v = new GetPersonneViewModel
            {
                personne = p,
                adresse = a
            };
            //string t = "test";
            //return View("GetPersonne", t);
            return View(v);
        }

        public IActionResult GetPersonnes()
        {
            return View(Personne.GetListePersonnes());
        }

        public IActionResult DetailPersonne(int id)
        {
            Personne p = Personne.GetListePersonnes().FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        [HttpGet]
        public IActionResult FormPersonne()
        {
            return View();
        }

        //public IActionResult AddPersonne(string nom, string prenom)
        //{
        //    Personne p = new Personne()
        //    {
        //        Nom = nom,
        //        Prenom = prenom
        //    };
        //    p.Add();
        //    return RedirectToAction("Accueil");
        //}

        [HttpPost]
        public IActionResult AddPersonne(string Autre, Personne p)
        {
            if (ModelState.IsValid)
            {

                //Personne p = new Personne()
                //{
                //    Nom = nom,
                //    Prenom = prenom
                //};
                p.Add();
                return RedirectToAction("Accueil");
            }
            else
            {
                return RedirectToAction("FormPersonne");
            }
            
        }
    }
}