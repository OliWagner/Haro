using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class UploadModel
    {
        public int Id { get; set; }
        public List<BilderAnzeigen> BilderGeraet { get; set; }

        public UploadModel(int id) {
            using (HaroEntities db = new HaroEntities()) {
                Id = id;
                BilderGeraet = db.BilderAnzeigen.Where(x => x.AnzeigeId == id).ToList();
            }
            
        }
    }
}