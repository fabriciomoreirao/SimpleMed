using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.LoginService
{
    public interface ILogin
    {
        Task<User> Login(string user, string senha);


    }
}
