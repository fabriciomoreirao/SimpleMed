using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Model
{
    public class Agendamento
    {


        public string id { get; set; }
        public string patientId { get; set; }
        public string professionalId { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public Patient patient { get; set; }


    }

    public class Patient
    {
        public string id { get; set; }
        public bool isResponsible { get; set; }
        public bool isDependent { get; set; }
        public object user_id { get; set; }
        public string name { get; set; }
        public string mon { get; set; }
        public string dad { get; set; }
        public string gender { get; set; }
        public string birthdate { get; set; }
        public string cpf { get; set; }
        public string cns { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string number { get; set; }
        public string complement { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public string uf { get; set; }
        public string zip { get; set; }
    }

}

