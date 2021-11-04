using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class GebrauchteModel
    {
        public List<Gebrauchte> Geraete { get; set; }
        public List<BilderAnzeigen> Bilder { get; set; }

        public GebrauchteModel() {
            using (HaroEntities db = new HaroEntities()) {
                Geraete = db.Gebrauchte.ToList();
                Bilder = db.BilderAnzeigen.ToList();
            }
        }

    }


}