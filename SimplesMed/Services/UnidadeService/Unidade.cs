using Newtonsoft.Json;
using SimplesMed.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SimplesMed.Services.UnidadeService
{
    public class Unidade : IUnidade
    {
        private SettingService.ISetting Setting;
        public Unidade(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        public async Task<List<Unidades>> GetAll()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}units", Setting.URLBASE);
                var responde = await httpClient.GetAsync(uri);

                var result = JsonConvert.DeserializeObject<List<Unidades>>(await responde.Content.ReadAsStringAsync());

                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Unidades> Save(Unidades unidade)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}units", Setting.URLBASE);

                var content = new StringContent(JsonConvert.SerializeObject(unidade), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PostAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Unidades>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Unidades> Update(Unidades unidade)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                var uri = String.Format("{0}units/{1}", Setting.URLBASE,unidade.id);

                var content = new StringContent(JsonConvert.SerializeObject(unidade), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var responde = await httpClient.PutAsync(uri, content);

                var result = JsonConvert.DeserializeObject<Unidades>(await responde.Content.ReadAsStringAsync());

                return result;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
