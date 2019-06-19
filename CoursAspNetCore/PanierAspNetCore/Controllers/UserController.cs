using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PanierAspNetCore.Interface;
using PanierAspNetCore.Models;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PanierAspNetCore.Controllers
{
    public class UserController : Controller
    {
        private ILogin serviceLogin;

        public UserController(ILogin s)
        {
            serviceLogin = s;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            MD5 crypto = MD5.Create();
            
            string hash = serviceLogin.GetMd5Hash(crypto, password);
            User u = DataBaseContext.Instance.Users.FirstOrDefault((x) => x.UserName == username && x.Password == hash);
            if(u != null)
            {
                u.Token = serviceLogin.GetMd5Hash(crypto, Guid.NewGuid().ToString());
                DataBaseContext.Instance.SaveChanges();
                //HttpContext.Session.SetString("token", u.Token);
                //HttpContext.Session.SetString("id", u.Id.ToString());
                CookieOptions o = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(1)
                };
                Response.Cookies.Append("id", u.Id.ToString(), o);
                Response.Cookies.Append("token", u.Token, o);
                return RedirectToAction("AddProduit", "Produit");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult LogOut()
        {
            serviceLogin.LogOut(Response);
            return RedirectToAction("Index", "Produit");
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.UserName = Request.Cookies["username"];
            ViewBag.Password = Request.Cookies["password"];
            return View();
        }

        [HttpPost]
        public IActionResult Register(string UserName, string Password, string save, string valid)
        {
            if(valid == null)
            {
                Response.Cookies.Append("username", UserName, new CookieOptions { Expires = DateTime.Now.AddDays(1) });
                Response.Cookies.Append("password", Password, new CookieOptions { Expires = DateTime.Now.AddDays(1) });
            }
            else if(save == null)
            {
                User u = new User
                {
                    UserName = UserName,
                    Password = serviceLogin.GetMd5Hash(MD5.Create(), Password)
                };
                u.Add();
                Response.Cookies.Append("username", UserName, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
                Response.Cookies.Append("password", Password, new CookieOptions { Expires = DateTime.Now.AddDays(-1) });
            }
            return RedirectToAction("Login");
        }
    }
}
