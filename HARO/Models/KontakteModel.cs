using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class KontakteModel
    {
        public string Bestaetigung { get; set; }

        public KontakteModel(string bestaetigung) {
            Bestaetigung = bestaetigung;
        }
    }
}