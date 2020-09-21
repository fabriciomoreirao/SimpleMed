using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplesMed.Model;
using SimplesMed.Services.ProfissionalService;

namespace SimplesMed.Controllers
{
    public class ProfissionalController : Controller
    {
        IProfissional Profissional;

        public ProfissionalController(IProfissional profissional)
        {
            Profissional = profissional;
        }
        public async Task<IActionResult> Index()
        {
            return View(await Profissional.GetAll());
        }
        public async Task<IActionResult> Salvar([FromBody] Professionals professionals)
        {
            if (professionals.id == null)
            {
                professionals.id = Guid.NewGuid().ToString();
                 return Json(await Profissional.Save(professionals));
            }
            else
            {
               return Json( await Profissional.Update(professionals));
            }
           
        }
    }
}
