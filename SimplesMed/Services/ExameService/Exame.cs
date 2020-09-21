using Newtonsoft.Json;
using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplesMed.Services.ExameService
{
    public class Exame : IExame
    {

        private SettingService.ISetting Setting;
        public Exame(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public async Task<List<Exam>> GetAll()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}exames_items", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Exam>>(await responde.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Exam> Save(Exam exame)
        {
            try
            {
                
                HttpClient httpClient = new HttpClient();

                var uri = String.Format("{0}exames_items/{1}", Setting.URLBASE,exame.id);

                var content = new StringContent(JsonConvert.SerializeObject(exame), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PutAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Exam>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
