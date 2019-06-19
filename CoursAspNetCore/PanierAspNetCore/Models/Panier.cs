using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Models
{
    public class Panier
    {
        private int id;
        private decimal total;


        public int Id { get => id; set => id = value; }
        public decimal Total { get {
                total = 0;
                foreach(ProduitPanier p in produits)
                {
                    total += p.produit.Prix * p.Qty;
                }
                return total;
            }
            set
            {
                total = 0;
                foreach (ProduitPanier p in produits)
                {
                    total += p.produit.Prix * p.Qty;
                }
            }
        }

        public ICollection<ProduitPanier> produits { get; set; }

        public Panier()
        {
            produits = new List<ProduitPanier>();
        }

        
    }
}
