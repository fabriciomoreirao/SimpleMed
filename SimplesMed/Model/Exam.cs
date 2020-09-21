using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplesMed.Model
{
    public class Exam
    {
        
            public string id { get; set; }
            public string complementaryExameId { get; set; }
            public string exam_type { get; set; }
            public string exam_name { get; set; }
            public object is_changed { get; set; }
            public string created_at { get; set; }
            public object updated_at { get; set; }
            public string status { get; set; }
       

    }
}
