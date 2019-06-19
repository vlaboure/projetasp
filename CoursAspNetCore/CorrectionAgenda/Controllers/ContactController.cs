using CorrectionAgenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda.Controllers
{
    public class ContactController : Controller
    {
        public DataContext data = new DataContext();

        public IActionResult Index()
        { 
            List<Contact> contacts = data.Contacts.ToList(); 
            return View(contacts);
        }

        public IActionResult DetailContact(int id)
        {
            Contact c = data.Contacts.Include("emails").Where(x => x.Id == id).First();
            return View(c);
        }
    }
}
