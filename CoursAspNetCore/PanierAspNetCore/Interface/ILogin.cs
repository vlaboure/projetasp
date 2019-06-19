using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Http;

namespace PanierAspNetCore.Interface
{
    public interface ILogin
    {
        bool Logged(ISession session);
        bool LogOut(ISession session);
        bool Logged(HttpRequest request);
        bool LogOut(HttpResponse response);
        string GetMd5Hash(MD5 md5Hash, string input);
        bool isLogged { get; }

        string userName { get; }
       
    }
}
