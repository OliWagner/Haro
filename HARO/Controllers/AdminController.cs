using HARO.Helpers;
using HARO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;

namespace HARO.Controllers
{
    public class AdminController : Controller
    {
        

        // GET: Admin
        public ActionResult Index(int? id)
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else {
                if (id == null) {
                    AdminIndexModel model = new AdminIndexModel();
                    return View(model);
                }
                else {
                    AdminIndexModel model = new AdminIndexModel((int)id);
                    return View(model);
                }
                
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Anmelden(string user, string pass)
        {
            using (HaroEntities db = new HaroEntities()) {
                foreach (User usr in db.User)
                {
                    if (usr.username.Equals(user) && usr.passwort.Equals(pass)) {
                        Session["User"] = "ok";
                        return RedirectToAction("index");
                    }
                }
            }
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult AnzeigeEintragen(AdminIndexModel model)
        {
            using (HaroEntities db = new HaroEntities())
            {
                if (model.AkutesGeraet.id == 0)
                {
                    Gebrauchte neuer = new Gebrauchte();
                    neuer.Antrieb = model.AkutesGeraet.Antrieb;
                    neuer.AnzahlVentile = model.AkutesGeraet.AnzahlVentile;
                    neuer.Bauhoehe = model.AkutesGeraet.Bauhoehe;
                    neuer.Baujahr = model.AkutesGeraet.Baujahr;
                    neuer.Beschreibung = model.AkutesGeraet.Beschreibung;
                    neuer.Besonderheiten = model.AkutesGeraet.Besonderheiten;
                    neuer.Betriebsstunden = model.AkutesGeraet.Betriebsstunden;
                    neuer.Bezeichnung = model.AkutesGeraet.Bezeichnung;
                    neuer.Hersteller = model.AkutesGeraet.Hersteller;
                    neuer.Leergewicht = model.AkutesGeraet.Leergewicht;
                    neuer.Mast = model.AkutesGeraet.Mast;
                    neuer.MaxHubhoehe = model.AkutesGeraet.MaxHubhoehe;
                    neuer.Preis = model.AkutesGeraet.Preis;
                    neuer.Tragkraft = model.AkutesGeraet.Tragkraft;
                    neuer.Kategorie = model.AkutesGeraet.Kategorie;
                    neuer.LBH = model.AkutesGeraet.LBH;

                    db.Gebrauchte.Add(neuer);
                }
                else {
                    Gebrauchte datensatz = db.Gebrauchte.Where(x => x.id == model.AkutesGeraet.id).FirstOrDefault();
                    datensatz.Antrieb = model.AkutesGeraet.Antrieb;
                    datensatz.AnzahlVentile = model.AkutesGeraet.AnzahlVentile;
                    datensatz.Bauhoehe = model.AkutesGeraet.Bauhoehe;
                    datensatz.Baujahr = model.AkutesGeraet.Baujahr;
                    datensatz.Beschreibung = model.AkutesGeraet.Beschreibung;
                    datensatz.Besonderheiten = model.AkutesGeraet.Besonderheiten;
                    datensatz.Betriebsstunden = model.AkutesGeraet.Betriebsstunden;
                    datensatz.Bezeichnung = model.AkutesGeraet.Bezeichnung;
                    datensatz.Hersteller = model.AkutesGeraet.Hersteller;
                    datensatz.Leergewicht = model.AkutesGeraet.Leergewicht;
                    datensatz.Mast = model.AkutesGeraet.Mast;
                    datensatz.MaxHubhoehe = model.AkutesGeraet.MaxHubhoehe;
                    datensatz.Preis = model.AkutesGeraet.Preis;
                    datensatz.Tragkraft = model.AkutesGeraet.Tragkraft;
                    datensatz.Kategorie = model.AkutesGeraet.Kategorie;
                    datensatz.LBH = model.AkutesGeraet.LBH;
                }
                try {
                    
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Kontakte()
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else
            {
                AdminKontakteModel model = new AdminKontakteModel();
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult KontaktAnfrageLoeschen(int id)
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else
            {
                using (HaroEntities db = new HaroEntities()) {
                    Kontaktanfragen anfrage = db.Kontaktanfragen.Where(x => x.id == id).FirstOrDefault();
                    db.Kontaktanfragen.Remove(anfrage);
                    db.SaveChanges();
                }
                return RedirectToAction("Kontakte");
            }
        }



        [HttpGet]
        public ActionResult UploadFile(int id)
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else
            {
                UploadModel model = new UploadModel(id);
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult BildLoeschen(int bildId, int geraeteId)
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else
            {
                using (HaroEntities db = new HaroEntities()) {
                    BilderAnzeigen konkBild = db.BilderAnzeigen.Where(x => x.id == bildId).FirstOrDefault();
                    //Bild entfernen
                    System.IO.File.Delete(Path.Combine(Server.MapPath("~/UploadedFiles"), konkBild.url));
                    //DB Eintrag entfernen
                    db.BilderAnzeigen.Remove(konkBild);
                    db.SaveChanges();
                }
                return RedirectToAction("UploadFile", new { id = geraeteId });
            }
        }

        [HttpGet]
        public ActionResult DeleteAnzeige(int id)
        {
            if (Session["User"] == null || Session["User"].Equals(""))
            {
                return RedirectToAction("Login");
            }
            else
            {
                using (HaroEntities db = new HaroEntities())
                {
                    List<BilderAnzeigen> konkBilder = db.BilderAnzeigen.Where(x => x.AnzeigeId == id).ToList();
                    //Bilder entfernen
                    foreach (BilderAnzeigen item in konkBilder)
                    {
                        System.IO.File.Delete(Path.Combine(Server.MapPath("~/UploadedFiles"), item.url));
                    }
                    //DB Einträge entfernen
                    db.BilderAnzeigen.RemoveRange(konkBilder);
                    Gebrauchte zeug = db.Gebrauchte.Where(x => x.id == id).FirstOrDefault();
                    db.Gebrauchte.Remove(zeug);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file, string id)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName).Split('.')[1];
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), Guid.NewGuid().ToString().Replace("-", "") + "." + _FileName);

                    WebImage img = new WebImage(file.InputStream);
                    if (img.Width > img.Height)
                    {
                        if (img.Width > 800)
                            img.Resize(800, 600);
                        
                    }
                    else {
                        if (img.Height > 800)
                            img.Resize(600, 800);
                            img.RotateRight();
                    }
                    
                    img.Save(_path);

                    //file.SaveAs(_path);
                    using (HaroEntities db = new HaroEntities()) {
                        BilderAnzeigen aktuell = new BilderAnzeigen();
                        aktuell.AnzeigeId = Int32.Parse(id);
                        aktuell.url = _path.Split('\\').LastOrDefault();
                        db.BilderAnzeigen.Add(aktuell);
                        db.SaveChanges();
                    }
                }
                UploadModel model = new UploadModel(Int32.Parse(id));
                return View(model);
            }
            catch (Exception ex)
            {
                var test = 0;
                return View();
            }
        }
    }
}