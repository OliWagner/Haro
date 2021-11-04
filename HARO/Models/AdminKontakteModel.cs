using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class AdminKontakteModel
    {
        public List<Kontaktanfragen> Kontakte { get; set; }

        public AdminKontakteModel() {
            using (HaroEntities db = new HaroEntities()) {
                Kontakte = db.Kontaktanfragen.ToList();
            }
        }
    }
}