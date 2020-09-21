using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Services.SettingService
{
    public class Setting : ISetting
    {
        private string _urlbase = "https://simplemed.herokuapp.com/";
        public string URLBASE { get { return _urlbase; } set { _urlbase = value; } }
    }
}
