using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using SimplesMed.Model;
using SimplesMed.Services.LoginService;

namespace SimplesMed.Controllers
{
    public class LoginController : Controller
    {
        private ILogin Login;
        public LoginController(ILogin login)
        {
            Login = login;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logar([FromBody] User user)
        {
            var result = await Login.Login(user.email, user.password);
            if (result != null)
            {
                HttpContext.Session.SetString("user", result.email);
                return Json(result);
            }

            return Json(result);
        }
    }
}
