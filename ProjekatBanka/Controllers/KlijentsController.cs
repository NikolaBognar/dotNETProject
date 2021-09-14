using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatBanka.Models;

namespace ProjekatBanka.Controllers
{
    public class KlijentsController : Controller
    {
        private BankaContext db = new BankaContext();

        // GET: Klijents
        public ActionResult Index()
        {
            return View(db.Klijents.ToList());
        }

        // GET: Klijents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            return View(klijent);
        }

        // GET: Klijents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klijents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JMBG,Ime,Prezime,Adresa,BrojLicneKarte,Telefon,Sifra")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                db.Klijents.Add(klijent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klijent);
        }

        // GET: Klijents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            return View(klijent);
        }

        // POST: Klijents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JMBG,Ime,Prezime,Adresa,BrojLicneKarte,Telefon,Sifra")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klijent).State = EntityState.Modified;
                db.SaveChanges();
                Session["JMBG"] = klijent.JMBG;
                return RedirectToAction("Index","Kartices");
            }
            return View(klijent);
        }

        // GET: Klijents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Klijent klijent = db.Klijents.Find(id);
            if (klijent == null)
            {
                return HttpNotFound();
            }
            return View(klijent);
        }

        // POST: Klijents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Klijent klijent = db.Klijents.Find(id);
            db.Klijents.Remove(klijent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Registracija()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult RegistracijaKlijents([Bind(Include = "JMBG,Ime,Prezime,Adresa,BrojLicneKarte,Telefon,Sifra")] Klijent klijent)
        {
            if (ModelState.IsValid)
            {
                var podaciOKlijentu = db.Klijents.Where(x => x.JMBG == klijent.JMBG).SingleOrDefault();
                if (podaciOKlijentu == null)
                {
                    Klijent noviKlijent = klijent;
                    db.Klijents.Add(noviKlijent);
                    db.SaveChanges();
                    Session["JMBG"] = noviKlijent.JMBG;
                    Session["Ime"] = noviKlijent.Ime;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Greska = "Postoji korisnik sa istim JMBG.";
                    return View("Registracija");
                }
            }
            else
            {
                return View("Registracija");
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Autorizacija(Klijent klijent)
        {
            var podaciOKlijentu = db.Klijents.Where(x => x.JMBG == klijent.JMBG && x.Sifra == klijent.Sifra).FirstOrDefault();
            if (podaciOKlijentu == null)
            {
                ViewBag.Greska = "Proverite uneti JMBG i šifru.";
                return View("Login");
            }
            else
            {
                Session["JMBG"] = podaciOKlijentu.JMBG;
                Session["Ime"] = podaciOKlijentu.Ime;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Odjava()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
}
