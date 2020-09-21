using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplesMed.Model;
using SimplesMed.Services.UnidadeService;

namespace SimplesMed.Controllers
{
    public class UnidadeController : Controller
    {
        private IUnidade Unidade;
        public UnidadeController(IUnidade unidade)
        {
            Unidade = unidade;
        }
        public async Task<IActionResult> Index()
        {
            var result = await Unidade.GetAll();
            return View(result);
        }

        public async Task<IActionResult> Salvar([FromBody] Unidades unidades)
        {
            if (unidades.id == null)
            {
                unidades.id = Guid.NewGuid().ToString();
                return Json(await Unidade.Save(unidades));
            }
            else
            {
                return Json(await Unidade.Update(unidades));
            }
        }
    }
}
