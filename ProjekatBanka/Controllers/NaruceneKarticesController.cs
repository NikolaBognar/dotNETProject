using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatBanka.Models;
using PagedList;

namespace ProjekatBanka.Controllers
{
    public class NaruceneKarticesController : Controller
    {
        private BankaContext db = new BankaContext();

        // GET: NaruceneKartices
        public ActionResult Index(int? strana)
        {
            var brojStrane = strana ?? 1;
            var velicinaStrane = 4;
            var naruceneKartice = db.naruceneKartices.OrderBy(s => s.RedniBrojNarudzbe).ToPagedList(brojStrane, velicinaStrane);
            return View(naruceneKartice);

        }

        // GET: NaruceneKartices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaruceneKartice naruceneKartice = db.naruceneKartices.Find(id);
            if (naruceneKartice == null)
            {
                return HttpNotFound();
            }
            return View(naruceneKartice);
        }

        // GET: NaruceneKartices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NaruceneKartices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RedniBrojNarudzbe,IDKartice,Tip,JMBG")] NaruceneKartice naruceneKartice)
        {
            if (ModelState.IsValid)
            {
                db.naruceneKartices.Add(naruceneKartice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naruceneKartice);
        }

        // GET: NaruceneKartices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaruceneKartice naruceneKartice = db.naruceneKartices.Find(id);
            if (naruceneKartice == null)
            {
                return HttpNotFound();
            }
            return View(naruceneKartice);
        }

        // POST: NaruceneKartices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RedniBrojNarudzbe,IDKartice,Tip,JMBG")] NaruceneKartice naruceneKartice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naruceneKartice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(naruceneKartice);
        }

        // GET: NaruceneKartices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NaruceneKartice naruceneKartice = db.naruceneKartices.Find(id);
            if (naruceneKartice == null)
            {
                return HttpNotFound();
            }
            return View(naruceneKartice);
        }

        // POST: NaruceneKartices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NaruceneKartice naruceneKartice = db.naruceneKartices.Find(id);
            db.naruceneKartices.Remove(naruceneKartice);
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
        public ActionResult Rezervacija(int id)
        {
            Kartice kartica = db.Kartices.Find(id);

            NaruceneKartice narucivanje = new NaruceneKartice();

            narucivanje.IDKartice = kartica.IDKartice;
            narucivanje.JMBG = (string)Session["JMBG"];
            narucivanje.Tip = kartica.TipKartice;

            try
            {
                db.naruceneKartices.Add(narucivanje);
                db.SaveChanges();
                return RedirectToAction("Index", "NaruceneKartices");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
     
    }
}
