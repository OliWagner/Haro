using HARO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HARO.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Service() {
            return View();
        }

        public ActionResult Stapler()
        {
            return View();
        }

        public ActionResult Hyster()
        {
            return View();
        }

        public ActionResult Wir()
        {
            return View();
        }

        public ActionResult Gebrauchte()
        {
            GebrauchteModel model = new GebrauchteModel();
            return View(model);
        }

        public ActionResult GebrauchteEinzelansicht(int id)
        {
            GebrauchteEinzelnModel model = new GebrauchteEinzelnModel(id);
            return View(model);
        }

        public ActionResult Zubehoer()
        {
            return View();
        }

        public ActionResult Werkstatt()
        {
            return View();
        }

        public ActionResult Ersatzteile()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        [HttpGet]
        public ActionResult News(int? id)
        {
            NewsModel model;
            if (id == null) {
                model = new NewsModel();
            } else {
                model = new NewsModel((int)id);
            }
            return View(model);
        }

        public ActionResult Marken()
        {
            return View();
        }

        public ActionResult Kontakt(int? bestaetigung)
        {
            KontakteModel model;
            if (bestaetigung == 1)
            {
                model= new KontakteModel("Vielen Dank, wird werden uns so schnell wie möglich bei Ihnen melden.");
            }
            else {
                model = new KontakteModel("");
            }
            return View(model);
        }

        public ActionResult Impressum()
        {
            return View();
        }

        public ActionResult Haftung()
        {
            return View();
        }

        public ActionResult Datenschutz()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult KontaktEintragen()
        {
            string _Firma = Request.Form["firma"];
            string _Anpartner = Request.Form["anpartner"];
            string _MailTel = Request.Form["mailTel"];
            string _Thema = Request.Form["thema"];

            using (HaroEntities db = new HaroEntities()) {
                Kontaktanfragen anfrage = new Kontaktanfragen();
                anfrage.Anpartner = _Anpartner;
                anfrage.Firma = _Firma;
                anfrage.MailTel = _MailTel;
                anfrage.Thema = _Thema;
                db.Kontaktanfragen.Add(anfrage);
                db.SaveChanges();
            }
            //Bestätigung einbauen

            return RedirectToAction("Kontakt", new { bestaetigung = 1 });
        }
    }
}