using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HARO.Models
{
    public class NewsModel
    {
        public List<News> AlleNews { get; set; }
        public News AnzeigeNews { get; set; }

        public NewsModel() {
            using (HaroEntities db = new HaroEntities()) {
                AlleNews = db.News.OrderByDescending(x => x.id).ToList();
                AnzeigeNews = db.News.OrderByDescending(x => x.id).FirstOrDefault();
                if (AnzeigeNews == null) {
                    AnzeigeNews = new News();
                }
            }
        }

        public NewsModel(int id)
        {
            using (HaroEntities db = new HaroEntities())
            {
                AlleNews = db.News.OrderByDescending(x => x.id).ToList();
                AnzeigeNews = db.News.Where(x => x.id == id).FirstOrDefault();
            }
        }
    }
}