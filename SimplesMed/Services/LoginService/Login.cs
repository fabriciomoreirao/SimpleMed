using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SimplesMed.Model;

namespace SimplesMed.Services.LoginService
{
    public class Login : ILogin
    {
        const string SessionName = "_Name";
        const string SessionEmail = "_Email";
        private SettingService.ISetting Setting;
        public Login(SettingService.ISetting setting)
        {
            Setting = setting;
        }
        async Task<User> ILogin.Login(string user, string senha)
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                var uri = String.Format("{0}users?email={1}&password={2}", Setting.URLBASE,user,senha);
                var response = await httpClient.GetAsync(uri);
                var result=  JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync());

                return result.FirstOrDefault();
             

            }
            catch (Exception ex)
            {
                var a = ex.Message;

                return null;
                
            }
        }
    }
}
