using Microsoft.AspNetCore.Http;
using PanierAspNetCore.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Models
{
    public class Produit
    {
        private int id;
        private string titre;
        private string image;
        private decimal prix;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Image { get => image; set => image = value; }
        public decimal Prix { get => prix; set => prix = value; }

        public void Add(IFormFile image,string host)
        {
            if (image != null)
            {
                string nomImage = Guid.NewGuid() + image.FileName;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", nomImage);
                FileStream s = new FileStream(path, FileMode.Create);
                image.CopyTo(s);
                s.Close();
                Image = host + "/images/" + nomImage;
            }
            DataBaseContext.Instance.Produits.Add(this);
            DataBaseContext.Instance.SaveChanges();
        }
    }
}
