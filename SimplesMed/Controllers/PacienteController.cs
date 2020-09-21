using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplesMed.Model;
using SimplesMed.Services.PacienteService;

namespace SimplesMed.Controllers
{
    public class PacienteController : Controller
    {
        IPaciente Paciente;
        public PacienteController(IPaciente paciente)
        {
            Paciente = paciente;
        }
        public async Task<IActionResult> Index()
        {
            return View(await Paciente.GetAll());
        }

        public async Task<IActionResult> Salvar([FromBody] Pacient paciente)
        {
            if (paciente.id == null)
            {
                paciente.id = Guid.NewGuid().ToString();
                return Json(await Paciente.Save(paciente));
            }
            else
            {
                return Json(await Paciente.Update(paciente));
            }
        }
    }
}
