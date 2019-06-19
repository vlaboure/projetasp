using CorrectionAgenda2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAgenda2.Tools
{
    public interface IData
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Email> Emails { get; set; }
        int SaveChanges();
    }
}
