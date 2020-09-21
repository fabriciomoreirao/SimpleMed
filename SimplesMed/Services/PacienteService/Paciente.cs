using Newtonsoft.Json;
using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplesMed.Services.PacienteService
{
    public class Paciente : IPaciente
    {
        SettingService.ISetting Setting;

        public Paciente(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public async Task<List<Pacient>> GetAll()
        {

            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}patients", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Pacient>>(await responde.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Pacient> Save(Pacient paciente)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}patients", Setting.URLBASE);

                var content = new StringContent(JsonConvert.SerializeObject(paciente), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PostAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Pacient>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Pacient> Update(Pacient paciente)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}patients/{1}", Setting.URLBASE,paciente.id);

                var content = new StringContent(JsonConvert.SerializeObject(paciente), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var responde = await httpClient.PutAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Pacient>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
