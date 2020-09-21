using Newtonsoft.Json;
using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplesMed.Services.LaboratorioService
{
    public class Laboratorio : ILaboratorio
    {
        private SettingService.ISetting Setting;
        public Laboratorio(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public async Task<List<Lab>> GetAll()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}laboratories", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Lab>>(await responde.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Lab> Save(Lab lab)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}laboratories", Setting.URLBASE);

                var content = new StringContent(JsonConvert.SerializeObject(lab), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PostAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Lab>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Lab> Update(Lab lab)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}laboratories/{1}", Setting.URLBASE,lab.id);

                var content = new StringContent(JsonConvert.SerializeObject(lab), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PutAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Lab>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
