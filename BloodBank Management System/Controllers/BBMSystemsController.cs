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
    public class BBMSystemsController : Controller
    {
        private DbBloodbank db = new DbBloodbank();

        // GET: BBMSystems
        public ActionResult Index()
        {
            var bBMSystems = db.BBMSystems.Include(b => b.BloodInventoryManager).Include(b => b.BloodRecipient).Include(b => b.BloodSample).Include(b => b.District).Include(b => b.Donor);
            return View(bBMSystems.ToList());
        }

        // GET: BBMSystems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BBMSystem bBMSystem = db.BBMSystems.Find(id);
            if (bBMSystem == null)
            {
                return HttpNotFound();
            }
            return View(bBMSystem);
        }

        // GET: BBMSystems/Create
        public ActionResult Create()
        {
            ViewBag.ManagerId = new SelectList(db.BloodInventoryManagers, "ManagerId", "Name");
            ViewBag.RecipientId = new SelectList(db.BloodRecipients, "RecipientId", "RecipientName");
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId");
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name");
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName");
            return View();
        }

        // POST: BBMSystems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BBMSystemId,BBMSName,BloodSampleId,ManagerId,RecipientId,DonorId,DistrictId")] BBMSystem bBMSystem)
        {
            if (ModelState.IsValid)
            {
                db.BBMSystems.Add(bBMSystem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerId = new SelectList(db.BloodInventoryManagers, "ManagerId", "Name", bBMSystem.ManagerId);
            ViewBag.RecipientId = new SelectList(db.BloodRecipients, "RecipientId", "RecipientName", bBMSystem.RecipientId);
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bBMSystem.BloodSampleId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", bBMSystem.DistrictId);
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bBMSystem.DonorId);
            return View(bBMSystem);
        }

        // GET: BBMSystems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BBMSystem bBMSystem = db.BBMSystems.Find(id);
            if (bBMSystem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerId = new SelectList(db.BloodInventoryManagers, "ManagerId", "Name", bBMSystem.ManagerId);
            ViewBag.RecipientId = new SelectList(db.BloodRecipients, "RecipientId", "RecipientName", bBMSystem.RecipientId);
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bBMSystem.BloodSampleId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", bBMSystem.DistrictId);
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bBMSystem.DonorId);
            return View(bBMSystem);
        }

        // POST: BBMSystems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BBMSystemId,BBMSName,BloodSampleId,ManagerId,RecipientId,DonorId,DistrictId")] BBMSystem bBMSystem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bBMSystem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerId = new SelectList(db.BloodInventoryManagers, "ManagerId", "Name", bBMSystem.ManagerId);
            ViewBag.RecipientId = new SelectList(db.BloodRecipients, "RecipientId", "RecipientName", bBMSystem.RecipientId);
            ViewBag.BloodSampleId = new SelectList(db.BloodSamples, "BloodSampleId", "BloodSampleId", bBMSystem.BloodSampleId);
            ViewBag.DistrictId = new SelectList(db.Districts, "DistrictId", "Name", bBMSystem.DistrictId);
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bBMSystem.DonorId);
            return View(bBMSystem);
        }

        // GET: BBMSystems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BBMSystem bBMSystem = db.BBMSystems.Find(id);
            if (bBMSystem == null)
            {
                return HttpNotFound();
            }
            return View(bBMSystem);
        }

        // POST: BBMSystems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BBMSystem bBMSystem = db.BBMSystems.Find(id);
            db.BBMSystems.Remove(bBMSystem);
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
