using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fikri_MVC.Models;

namespace Fikri_MVC.Controllers
{
    public class TransactionFuelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TransactionFuels
        public async Task<ActionResult> Index()
        {
            try
            {
                var transactionFuels = db.TransactionFuels.Include(t => t.Consumer).Include(t => t.Employee);
                return View(await transactionFuels.ToListAsync());
            }
            catch(Exception e)
            {
                return Content("Failed to load TransactionFuels Index page");
            }
        }

        // GET: TransactionFuels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionFuel transactionFuel = await db.TransactionFuels.FindAsync(id);
                if (transactionFuel == null)
                {
                    return HttpNotFound();
                }
                return View(transactionFuel);
            }
            catch(Exception e)
            {
                return Content("Failed to load TransactionFuels detail page");
            }
        }

        // GET: TransactionFuels/Create
        public ActionResult Create()
        {
            try
            {
                ViewBag.Consumer_Id = new SelectList(db.Consumers, "Consumer_Id", "Vehicle_Name");
                ViewBag.Employee_Id = new SelectList(db.Employees, "Employee_Id", "Name");
                return View();
            }
            catch(Exception e)
            {
                return Content("Failed to load TransactionFuels Create page");
            }
        }

        // POST: TransactionFuels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,OrderDate,FuelType,Capacity,Consumer_Id,Employee_Id")] TransactionFuel transactionFuel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.TransactionFuels.Add(transactionFuel);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                ViewBag.Consumer_Id = new SelectList(db.Consumers, "Consumer_Id", "Vehicle_Name", transactionFuel.Consumer_Id);
                ViewBag.Employee_Id = new SelectList(db.Employees, "Employee_Id", "Name", transactionFuel.Employee_Id);
                return View(transactionFuel);
            }
            catch(Exception e)
            {
                return Content("Failed to create TransactionFuels data ");
            }
        }

        // GET: TransactionFuels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionFuel transactionFuel = await db.TransactionFuels.FindAsync(id);
                if (transactionFuel == null)
                {
                    return HttpNotFound();
                }
                ViewBag.Consumer_Id = new SelectList(db.Consumers, "Consumer_Id", "Vehicle_Name", transactionFuel.Consumer_Id);
                ViewBag.Employee_Id = new SelectList(db.Employees, "Employee_Id", "Name", transactionFuel.Employee_Id);
                return View(transactionFuel);
            }
            catch(Exception e)
            {
                return Content("Failed to load TransactionFuels Edit page");
            }
        }

        // POST: TransactionFuels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,OrderDate,FuelType,Capacity,Consumer_Id,Employee_Id")] TransactionFuel transactionFuel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(transactionFuel).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                ViewBag.Consumer_Id = new SelectList(db.Consumers, "Consumer_Id", "Vehicle_Name", transactionFuel.Consumer_Id);
                ViewBag.Employee_Id = new SelectList(db.Employees, "Employee_Id", "Name", transactionFuel.Employee_Id);
                return View(transactionFuel);
            }
            catch(Exception e)
            {
                return Content("Failed to edit TransactionFuels data");
            }
        }

        // GET: TransactionFuels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                TransactionFuel transactionFuel = await db.TransactionFuels.FindAsync(id);
                if (transactionFuel == null)
                {
                    return HttpNotFound();
                }
                return View(transactionFuel);
            }
            catch(Exception e)
            {
                return Content("Failed to load TransactionFuels delete page");
            }
        }

        // POST: TransactionFuels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                TransactionFuel transactionFuel = await db.TransactionFuels.FindAsync(id);
                db.TransactionFuels.Remove(transactionFuel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Content("Failed to delete TransactionFuels data ");
            }
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
