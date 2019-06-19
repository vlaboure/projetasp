using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PanierAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PanierAspNetCore.Tools
{
    public class DataBaseContext : DbContext
    {
        private static DataBaseContext _instance = null;
        private static readonly object _lock = new object();

        public static DataBaseContext Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DataBaseContext();
                    return _instance;
                }
            }
        }
        private DataBaseContext()
        {
            RelationalDatabaseCreator creator = (RelationalDatabaseCreator)Database.GetService<IRelationalDatabaseCreator>();
            try
            {
                Database.Migrate();
                creator.CreateTables();
            }
            catch (Exception e)
            {

            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localDb)\DataBaseEntityFrameWork;Integrated Security=True");
        }

        public DbSet<Produit> Produits { get; set; }
        public DbSet<ProduitPanier> ProduitPaniers { get; set; }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
