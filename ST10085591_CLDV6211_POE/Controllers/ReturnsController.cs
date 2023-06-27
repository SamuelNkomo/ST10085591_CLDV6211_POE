using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ST10085591_CLDV6211_POE.Models;

namespace ST10085591_CLDV6211_POE.Controllers
{
    public class ReturnsController : Controller
    {
        private The_Ride_You_RentEntities1 db = new The_Ride_You_RentEntities1();

        // GET: Return
        public ActionResult Index()
        {
            var returns = db.Returns.ToList();
            return View(returns);
        }

        // GET: Return/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Return/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarNo,DriverName,InspectorName,ReturnDate,ElapsedDate,Fine,Id")] Return returnObj)
        {
            if (ModelState.IsValid)
            {
                db.Returns.Add(returnObj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(returnObj);
        }
        private void CalculateElapsedDateAndFine(Return returnObject)
        {
            TimeSpan elapsed = DateTime.Now.Date - returnObject.ReturnDate.Date;
            returnObject.ElapsedDate = elapsed.Days;
            returnObject.Fine = elapsed.Days * 500;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Return returnObj = db.Returns.Find(id);

            if (returnObj == null)
            {
                return HttpNotFound();
            }

            return View(returnObj);
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