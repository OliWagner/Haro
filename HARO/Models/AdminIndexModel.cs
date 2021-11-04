using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class AdminIndexModel
    {
        public List<Gebrauchte> AlleAnzeigen { get; set; }
        public Gebrauchte AkutesGeraet { get; set; }

        public AdminIndexModel() {
            using (HaroEntities db = new HaroEntities()) {
                AlleAnzeigen = db.Gebrauchte.ToList();
                AkutesGeraet = new Gebrauchte();
            }
        }

        public AdminIndexModel(int id)
        {
            using (HaroEntities db = new HaroEntities())
            {
                AlleAnzeigen = db.Gebrauchte.ToList();
                AkutesGeraet = db.Gebrauchte.Where(x => x.id == id).FirstOrDefault();
            }
        }
    }
}