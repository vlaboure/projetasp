using CorrectionAgenda2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda2.Tools
{
    public class DbContextService : DbContext, IData
    {
        public DbContextService()
        {
            RelationalDatabaseCreator creator = (RelationalDatabaseCreator)Database.GetService<IRelationalDatabaseCreator>();
            try
            {
                creator.CreateTables();
            }
            catch (Exception e)
            {

            }
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\DataBaseEntityFrameWork;Integrated Security=True");
        }
    }
}
