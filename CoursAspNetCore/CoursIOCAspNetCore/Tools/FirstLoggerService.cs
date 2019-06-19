using CoursIOCAspNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CoursIOCAspNetCore.Tools
{
    public class FirstLoggerService : ILogger
    {
        public void WriteLog(string log)
        {
            Debug.WriteLine(log);
        }
    }
}
