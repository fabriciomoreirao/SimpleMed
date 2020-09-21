using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplesMed.Model;
using SimplesMed.Services.LaboratorioService;

namespace SimplesMed.Controllers
{
    public class LaboratorioController : Controller
    {
        ILaboratorio Laboratorio;
        public LaboratorioController(ILaboratorio laboratorio)
        {
            Laboratorio = laboratorio;
        }
        public async Task<IActionResult> Index()
        {
            return View(await Laboratorio.GetAll());
        }


        public async Task<IActionResult> Salvar([FromBody]  Lab lab)
        {
            if (lab.id == null)
            {
                lab.id = Guid.NewGuid().ToString();
                return Json(await Laboratorio.Save(lab));
            }
            else
            {
                return Json(await Laboratorio.Update(lab));
            }
        }

    }
}
