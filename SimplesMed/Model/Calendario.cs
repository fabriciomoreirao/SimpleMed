using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Model
{
    public class Calendario
    {
        public string id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public string className { get; set; }
        public string someKey { get; set; }
        public bool allDay { get; set; }
        public string resourceId { get; set; }
        public bool editable { get; set; }
    }
}
