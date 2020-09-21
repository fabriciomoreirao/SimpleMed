using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;

namespace SimplesMed.Services.ProfissionalService
{
    public class Profissional : IProfissional
    {
        private SettingService.ISetting Setting;
        public Profissional(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Professionals>> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Professionals>> GetAll()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}professionals", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Professionals>>(await responde.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Professionals> Save(Professionals professionals)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}professionals", Setting.URLBASE);

                var content = new StringContent(JsonConvert.SerializeObject(professionals), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PostAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Professionals>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Professionals> Update(Professionals professionals)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}professionals/{1}", Setting.URLBASE, professionals.id);
                var content = new StringContent(JsonConvert.SerializeObject(professionals), Encoding.UTF8, "application/json");

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PutAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Professionals>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
