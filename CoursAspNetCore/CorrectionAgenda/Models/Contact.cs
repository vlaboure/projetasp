using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda.Models
{
    
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string tel;

        [Key]
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Tel { get => tel; set => tel = value; }

        public ICollection<Email> emails { get; set; }

        public Contact()
        {
            emails = new List<Email>();
        }
    }
}
