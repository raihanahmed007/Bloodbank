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
    public class BloodRecipientsController : Controller
    {
        private DbBloodbank db = new DbBloodbank();

        // GET: BloodRecipients
        public ActionResult Index()
        {
            var bloodRecipients = db.BloodRecipients.Include(b => b.Donor);
            return View(bloodRecipients.ToList());
        }

        // GET: BloodRecipients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRecipient bloodRecipient = db.BloodRecipients.Find(id);
            if (bloodRecipient == null)
            {
                return HttpNotFound();
            }
            return View(bloodRecipient);
        }

        // GET: BloodRecipients/Create
        public ActionResult Create()
        {
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName");
            return View();
        }

        // POST: BloodRecipients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipientId,RecipientName,Gender,Age,ContactNo,DonorId")] BloodRecipient bloodRecipient)
        {
            if (ModelState.IsValid)
            {
                db.BloodRecipients.Add(bloodRecipient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodRecipient.DonorId);
            return View(bloodRecipient);
        }

        // GET: BloodRecipients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRecipient bloodRecipient = db.BloodRecipients.Find(id);
            if (bloodRecipient == null)
            {
                return HttpNotFound();
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodRecipient.DonorId);
            return View(bloodRecipient);
        }

        // POST: BloodRecipients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipientId,RecipientName,Gender,Age,ContactNo,DonorId")] BloodRecipient bloodRecipient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloodRecipient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DonorId = new SelectList(db.Donors, "DonorId", "DonorName", bloodRecipient.DonorId);
            return View(bloodRecipient);
        }

        // GET: BloodRecipients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloodRecipient bloodRecipient = db.BloodRecipients.Find(id);
            if (bloodRecipient == null)
            {
                return HttpNotFound();
            }
            return View(bloodRecipient);
        }

        // POST: BloodRecipients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloodRecipient bloodRecipient = db.BloodRecipients.Find(id);
            db.BloodRecipients.Remove(bloodRecipient);
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
