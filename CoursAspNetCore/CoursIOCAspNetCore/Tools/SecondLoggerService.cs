using CoursIOCAspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoursIOCAspNetCore.Tools
{
    public class SecondLoggerService : ILogger
    {
        private static int nombreInstance = 0;
        public SecondLoggerService()
        {
            nombreInstance++;
        }
        public void WriteLog(string log)
        {
            Debug.WriteLine("Second log " + log + "Nombre d'instance "+ nombreInstance);
        }
    }
}
