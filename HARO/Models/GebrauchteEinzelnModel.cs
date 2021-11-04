using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class GebrauchteEinzelnModel
    {
        public Gebrauchte Geraet { get; set; }
        public List<BilderAnzeigen> Bilder { get; set; }

        public GebrauchteEinzelnModel(int id) {
            using (HaroEntities db = new HaroEntities()) {
                Geraet = db.Gebrauchte.Where(x => x.id == id).FirstOrDefault();
                Bilder = db.BilderAnzeigen.Where(x => x.AnzeigeId == id).ToList();
            }
        }

    }


}