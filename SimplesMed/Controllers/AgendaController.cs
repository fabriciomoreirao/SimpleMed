using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplesMed.Model;

namespace SimplesMed.Controllers
{
    public class AgendaController : Controller
    {
        Services.SettingService.ISetting Setting;

        public AgendaController(Services.SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAgendamentosCalendario()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}schedules?expand=patient", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Agendamento>>(await responde.Content.ReadAsStringAsync());

                List<Calendario> calendarios = new List<Calendario>();
                foreach (var i in result)
                {
                    Calendario calendario = new Calendario();
                    if (i.status == "sheduled")
                        calendario.color = "#005eff";
                    if (i.status == "completed")
                        calendario.color = "#00ff00";
                    if (i.status == "canceled")
                        calendario.color = "#ff0500";
                    if (i.status == "awaiting")
                        calendario.color = "#ffea00";

                    calendario.id = i.id;
                    calendario.start = DateTime.Parse(i.date).ToString("s");
                    calendario.end = DateTime.Parse(i.date).AddMinutes(30).ToString("s");
                    if (i.patient != null)
                    {
                        calendario.title = i.patient.name;
                    }
                    else
                    {
                        calendario.title = "Bloqueio";
                    }

                    calendarios.Add(calendario);
                }
                return Json(calendarios.ToArray());
            }
            catch (Exception)
            {
                return null;
            }            
        }

    }
}
