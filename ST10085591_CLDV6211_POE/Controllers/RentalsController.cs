using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ST10085591_CLDV6211_POE.Models;

namespace ST10085591_CLDV6211_POE.Controllers
{
    public class RentalsController : Controller
    {
        private The_Ride_You_RentEntities1 db = new The_Ride_You_RentEntities1();

        // GET: Rental
        public ActionResult Index()
        {
            return View(db.Rentals.ToList());
        }

        // GET: Rental/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = db.Rentals.Find(id);
            if (rental == null)
            {
                return HttpNotFound();
            }
            return View(rental);
        }

        // GET: Rental/Create
        //creating this async <actionresult> method so we can call the view bag in the cshtml class, this enables the user to be able to see a list of all the data provided in the database
        public async Task<ActionResult> Create(int id = 1)
        {
            if (id.Equals(null))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rental rental = await db.Rentals.FindAsync(id);
            Car car = await db.Cars.FindAsync(id);
            Driver driver = await db.Drivers.FindAsync(id);
            Inspector inspector = await db.Inspectors.FindAsync(id);

            if (rental == null)
            {
                return HttpNotFound();
            }
            //these view bags are what contain the list of data which we choose on own terms to display to the user
            ViewBag.CarNo = new SelectList(db.Cars, "CarNo", "CarNo", car.CarNo);
            ViewBag.DriverName = new SelectList(db.Drivers, "DriverName", "DriverName", driver.DriverName);
            ViewBag.InspectorName = new SelectList(db.Inspectors, "InspectorName", "InspectorName", inspector.InspectorName);

            return View();
            /* This above block of code has been adapted from
             * Author: SurferOnWww
             * Date: Jun 28, 2022
             * URL: https://learn.microsoft.com/en-us/answers/questions/904674/dropdown-list-is-not-showing-selected-value
             * Date Accessed: July 25, 2023
             */

        }

        // POST: Rental/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarNo,InspectorName,DriverName,RentalFee,StartDate,EndDate")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                db.Rentals.Add(rental);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rental);
        }

    }
}