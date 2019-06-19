using CoursIOCAspNetCore.Interfaces;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursIOCAspNetCore.Models
{
    public class Personne
    {
        private ILogger MonLogger;
        private IServiceProvider serviceProvier;
        public Personne()
        {
            
        }
        public Personne(IServiceProvider s)
        {
            serviceProvier = s;

            MonLogger = (ILogger)serviceProvier.GetService(typeof(ILogger));
            MonLogger.WriteLog("Log Test Personne");
        }
    }
}
