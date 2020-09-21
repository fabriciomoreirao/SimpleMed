using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Model
{
    public class Lab
    {
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public string uf { get; set; }
        public string zip { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public bool isPublic { get; set; }
    }
}
