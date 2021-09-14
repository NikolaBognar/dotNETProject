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
    public class KarticesController : Controller
    {
        private BankaContext db = new BankaContext();

        // GET: Kartices
        public ActionResult Index(int? strana)
        {
            var brojStrane = strana ?? 1;
            var velicinaStrane = 4;
            var naruceneKartice = db.Kartices.OrderBy(s => s.IDKartice).ToPagedList(brojStrane, velicinaStrane);
            return View(naruceneKartice);
        }

        // GET: Kartices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kartice kartice = db.Kartices.Find(id);
            if (kartice == null)
            {
                return HttpNotFound();
            }
            return View(kartice);
        }

        // GET: Kartices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kartices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDKartice,TipKartice")] Kartice kartice)
        {
            if (ModelState.IsValid)
            {
                db.Kartices.Add(kartice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kartice);
        }

        // GET: Kartices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kartice kartice = db.Kartices.Find(id);
            if (kartice == null)
            {
                return HttpNotFound();
            }
            return View(kartice);
        }

        // POST: Kartices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDKartice,TipKartice")] Kartice kartice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kartice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kartice);
        }

        // GET: Kartices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kartice kartice = db.Kartices.Find(id);
            if (kartice == null)
            {
                return HttpNotFound();
            }
            return View(kartice);
        }

        // POST: Kartices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kartice kartice = db.Kartices.Find(id);
            db.Kartices.Remove(kartice);
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
    }
}
