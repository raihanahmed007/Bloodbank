using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BloodBank_Management_System.Models;

namespace BloodBank_Management_System.Controllers
{
    public class BloodInventoryManagersController : Controller
    {
        private DbBloodbank db = new DbBloodbank();

        // GET: BloodInventoryManagers
        public ActionResult Index()
        {
            var bloodInventoryManagers = db.BloodInventoryManagers.Include(b => b.BloodSample);
            return View(bloodInventoryManagers.ToList());
        }

        // GET: BloodInventoryManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventoryManager bloodInventoryManager = db.BloodInventoryManagers.Find(id);
            if (bloodInventoryManager == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventoryManager);
        }

        // GET: BloodInventoryManagers/Create
        public ActionResult Create()
        {
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId");
            return View();
        }

        // POST: BloodInventoryManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ManagerId,Name,Address,ContactNo,Email,BloodSampleId")] BloodInventoryManager bloodInventoryManager)
        {
            if (ModelState.IsValid)
            {
                db.BloodInventoryManagers.Add(bloodInventoryManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodInventoryManager.BloodSampleId);
            return View(bloodInventoryManager);
        }

        // GET: BloodInventoryManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventoryManager bloodInventoryManager = db.BloodInventoryManagers.Find(id);
            if (bloodInventoryManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodInventoryManager.BloodSampleId);
            return View(bloodInventoryManager);
        }

        // POST: BloodInventoryManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ManagerId,Name,Address,ContactNo,Email,BloodSampleId")] BloodInventoryManager bloodInventoryManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodInventoryManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bloodInventoryManager.BloodSampleId);
            return View(bloodInventoryManager);
        }

        // GET: BloodInventoryManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodInventoryManager bloodInventoryManager = db.BloodInventoryManagers.Find(id);
            if (bloodInventoryManager == null)
            {
                return HttpNotFound();
            }
            return View(bloodInventoryManager);
        }

        // POST: BloodInventoryManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodInventoryManager bloodInventoryManager = db.BloodInventoryManagers.Find(id);
            db.BloodInventoryManagers.Remove(bloodInventoryManager);
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
