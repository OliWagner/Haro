using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class AdminNewsModel
    {
        public List<News> AlleNews { get; set; }
        public News AnzeigeNews { get; set; }

        public AdminNewsModel() {
            using (HaroEntities db = new HaroEntities()) {
                AlleNews = db.News.ToList();
                AnzeigeNews = new News();
            }
        }

        public AdminNewsModel(int id)
        {
            using (HaroEntities db = new HaroEntities())
            {
                AlleNews = db.News.ToList();
                AnzeigeNews = db.News.Where(x => x.id == id).FirstOrDefault();
            }
        }
    }
}