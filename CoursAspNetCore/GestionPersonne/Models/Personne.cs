using GestionPersonne.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonne.Models
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;
        private string image;

        public int Id { get => id; set => id = value; }

        [Required(ErrorMessage ="champ obligatoire"), Display(Name ="Nom personne")]
        public string Nom { get => nom; set => nom = value; }
        [Required(ErrorMessage = "champ obligatoire"), Display(Name = "Prénom personne")]
        public string Prenom { get => prenom; set => prenom = value; }
        [Required(ErrorMessage = "champ obligatoire"), Display(Name = "Tel personne")]
        public string Tel { get => tel; set => tel = value; }
        public string Image { get => image; set => image = value; }

        public void Add()
        {
            DatabaseContext.Instance.Personnes.Add(this);
            DatabaseContext.Instance.SaveChanges();
        }

        public static List<Personne> GetPersonnes()
        {
            return DatabaseContext.Instance.Personnes.ToList();
        }
    }
}
