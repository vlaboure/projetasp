using GestionPersonne.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonne.Controllers
{
    public class PersonneController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Personne> l = Personne.GetPersonnes();
            return View(l);
        }

        [HttpGet]
        public IActionResult AddFormPersonne()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddPersonne(Personne p, IFormFile imagePersonne)
        {
            if(ModelState.IsValid)
            {
                //Test Taille Image
                if(imagePersonne.Length < (2*1000*1000*8) )
                {

                }
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imagePersonne.FileName);
                FileStream stream = new FileStream(path, FileMode.Create);
                imagePersonne.CopyTo(stream);
                p.Image = imagePersonne.FileName;
                p.Add();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("AddFormPersonne");
            }
        }
    }
}
