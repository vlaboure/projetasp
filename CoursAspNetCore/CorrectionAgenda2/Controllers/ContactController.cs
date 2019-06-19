using CorrectionAgenda2.Models;
using CorrectionAgenda2.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda2.Controllers
{
    public class ContactController : Controller
    {
        private IServiceProvider service;

        public ContactController(IServiceProvider s)
        {
            service = s;
        }
        public IActionResult Index(bool? id)
        {
            ViewBag.error = id;
            return View(Contact.GetContacts(service));
        }

        //Action qui envoie le formulaire d'ajout 
        //le ? pour déclarer une variable nullable
        [HttpGet]
        public IActionResult AddContact(bool? id)
        {
            ViewBag.error = id;
            return View();
        }

        //Action qui traite me formulaire d'ajout
        [HttpPost]
        public IActionResult AddContact(Contact contact, IFormFile avatar)
        {
            if(ModelState.IsValid)
            {
                if (avatar != null)
                {
                    string nomAvatar = Guid.NewGuid() + "-" + avatar.FileName;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/avatars", nomAvatar);
                    FileStream stream = new FileStream(path, FileMode.Create);
                    avatar.CopyTo(stream);
                    contact.Avatar = nomAvatar;
                }
                if(contact.Id != default(int))
                {
                    contact.Update();
                }
                else
                {
                    contact.Add();
                }
                
                return RedirectToAction("Index", new { id = false });
            }
            else
            {
                return RedirectToAction("AddContact", new { id = true });
            }
            
        }

        [HttpGet]
        public IActionResult AddEmail(int id)
        {
            Contact c = DatabaseContext.Instance.Contacts.FirstOrDefault(x => x.Id == id);
            if(c == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = c.Id;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmail(Email email)
        {
            Contact c = DatabaseContext.Instance.Contacts.FirstOrDefault(x => x.Id == email.ContactId);
            if(c != null)
            {
                email.Id = default(int);
                DatabaseContext.Instance.Emails.Add(email);
                DatabaseContext.Instance.SaveChanges();
                ViewBag.ContactId = c.Id;
                ViewBag.error = false;
                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }

        [HttpGet]
        public IActionResult DetailContact(int id)
        {
            Contact c = DatabaseContext.Instance.Contacts.Include("emails").FirstOrDefault((x) => x.Id == id);
            if(c != null)
            {
                return View(c);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult DeleteContact(int id)
        {
            Contact c = DatabaseContext.Instance.Contacts.Include("emails").FirstOrDefault((x) => x.Id == id);
            if(c != null)
            {
                DatabaseContext.Instance.Emails.RemoveRange(c.emails.ToArray());
                DatabaseContext.Instance.Contacts.Remove(c);
                DatabaseContext.Instance.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditContact(int id)
        {
            Contact c = DatabaseContext.Instance.Contacts.Include("emails").FirstOrDefault((x) => x.Id == id);
            if (c != null)
            {
                return View("AddContact", c);
            }
            return RedirectToAction("Index");
        }
    }
}
