using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursAspNetCore.Models
{
    public class Adresse
    {
        private int id;
        private string ville;
        private string rue;
        private int personneId;

        public int Id { get => id; set => id = value; }
        public string Ville { get => ville; set => ville = value; }
        public string Rue { get => rue; set => rue = value; }
        public int PersonneId { get => personneId; set => personneId = value; }
    }
}
