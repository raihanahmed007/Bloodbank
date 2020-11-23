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
    public class BloodSamplesController : Controller
    {
        private DbBloodbank db = new DbBloodbank();

        // GET: BloodSamples
        public ActionResult Index()
        {
            var bloodSamples = db.BloodSamples.Include(b => b.Donor);
            return View(bloodSamples.ToList());
        }

        // GET: BloodSamples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = db.BloodSamples.Find(id);
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            return View(bloodSample);
        }

        // GET: BloodSamples/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName");
            return View();
        }

        // POST: BloodSamples/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BloodSampleId,BloodGroups,BloodQuentity,DonorId")] BloodSample bloodSample)
        {
            if (ModelState.IsValid)
            {
                db.BloodSamples.Add(bloodSample);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodSample.DonorId);
            return View(bloodSample);
        }

        // GET: BloodSamples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = db.BloodSamples.Find(id);
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodSample.DonorId);
            return View(bloodSample);
        }

        // POST: BloodSamples/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BloodSampleId,BloodGroups,BloodQuentity,DonorId")] BloodSample bloodSample)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodSample).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodSample.DonorId);
            return View(bloodSample);
        }

        // GET: BloodSamples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodSample bloodSample = db.BloodSamples.Find(id);
            if (bloodSample == null)
            {
                return HttpNotFound();
            }
            return View(bloodSample);
        }

        // POST: BloodSamples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodSample bloodSample = db.BloodSamples.Find(id);
            db.BloodSamples.Remove(bloodSample);
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
