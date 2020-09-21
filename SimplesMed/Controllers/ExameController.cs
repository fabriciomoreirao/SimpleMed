using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplesMed.Model;
using SimplesMed.Services.ExameService;

namespace SimplesMed.Controllers
{
    public class ExameController : Controller
    {
        IExame Exame;
        public ExameController(IExame exame)
        {
            Exame = exame;
        }
        public async  Task<IActionResult> Index()
        {

            return View( await Exame.GetAll());
        }

        public async Task<IActionResult> Salvar([FromBody] Exam exam)
        {            
            return Json(await Exame.Save(exam));
        }


    }
}
