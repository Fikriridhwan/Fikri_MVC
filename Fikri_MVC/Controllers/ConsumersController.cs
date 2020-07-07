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
    public class ConsumersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consumers
        public async Task<ActionResult> Index()
        {
            try 
            { 
                return View(await db.Consumers.ToListAsync());
            }
            catch(Exception e)
            {
                return Content("Failed to load Consumer Index page");
            }
        }

        // GET: Consumers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Consumer consumer = await db.Consumers.FindAsync(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            catch (Exception e)
            {
                return Content("Failed to load Consumer Detail page");
            }
            
        }

        // GET: Consumers/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }catch(Exception e)
            {
                return Content("Failed to load Consumer Create page");
            }
        }

        // POST: Consumers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Consumer_Id,Vehicle_Name,Fuel_Type,Capacity")] Consumer consumer)
        {
            try 
            { 
                if (ModelState.IsValid)
                {
                    db.Consumers.Add(consumer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(consumer);
            } 
            catch(Exception e)
            {
                return Content("Failed to Create Consumer data");
            }
        }

        // GET: Consumers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try { 
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumer consumer = await db.Consumers.FindAsync(id);
            if (consumer == null)
            {
                return HttpNotFound();
            }
            return View(consumer);
            }
            catch(Exception e)
            {
                return Content("Failed to load Consumer Edit page");
            }
        }

        // POST: Consumers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Consumer_Id,Vehicle_Name,Fuel_Type,Capacity")] Consumer consumer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(consumer).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(consumer);
            }
            catch(Exception e)
            {
                return Content("Failed to Edit Consumer data");
            }
        }

        // GET: Consumers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Consumer consumer = await db.Consumers.FindAsync(id);
                if (consumer == null)
                {
                    return HttpNotFound();
                }
                return View(consumer);
            }
            catch(Exception e)
            {
                return Content("Failed to load Consumer page");
            }
        }

        // POST: Consumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Consumer consumer = await db.Consumers.FindAsync(id);
                db.Consumers.Remove(consumer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Content("Failed to Delete Consumer data");
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
