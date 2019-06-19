using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Models
{
    public class ProduitPanier
    {

        private int id;
        private int produitId;
        private int qty;
        private int panierId;

        public int Id { get => id; set => id = value; }
        public int ProduitId { get => produitId; set => produitId = value; }
        public int Qty { get => qty; set => qty = value; }
        public int PanierId { get => panierId; set => panierId = value; }

        [ForeignKey("ProduitId")]
        public Produit produit { get; set; }

        
        
    }
}
