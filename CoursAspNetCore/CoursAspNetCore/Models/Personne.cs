using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetCore.Models
{
    public class Personne
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;

        public int Id { get => id; set => id = value; }
        [Display (Name = "Nom du client"), Required(ErrorMessage ="Erreur"), MaxLength(50, ErrorMessage ="Erreur taille")]
        public string Nom { get => nom; set => nom = value; }
        [Display(Name = "Prénom du client")]
        public string Prenom { get => prenom; set => prenom = value; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^0[1-9]{1}([\s*-\.]?[0-9]{2}){4}", ErrorMessage ="format incorrect")]
        public string Tel { get => tel; set => tel = value; }

        public static List<Personne> liste = new List<Personne>()
        {
            new Personne {Id = 1, Nom = "tata", Prenom="titi"},
            new Personne {Id = 2, Nom = "toto", Prenom="minet"},
        };

        public static List<Personne> GetListePersonnes()
        {
            return liste;
        }

        public void Add()
        {

        }
    }
}
