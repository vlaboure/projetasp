using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursIOCAspNetCore.Interfaces
{
    public interface ILogger
    {
        void WriteLog(string log);
    }
}
