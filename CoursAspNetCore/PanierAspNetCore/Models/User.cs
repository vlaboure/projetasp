using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Models
{
    public class User
    {
        private int id;
        private string userName;
        private string password;
        private string token;
        private string mail;
        private string tel;
        private string adress;
 

        public int Id { get => id; set => id = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Token { get => token; set => token = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Tel { get => tel; set => tel = value; }

        public void Add()
        {
            DataBaseContext.Instance.Users.Add(this);
            DataBaseContext.Instance.SaveChanges();
        }
    }
}
