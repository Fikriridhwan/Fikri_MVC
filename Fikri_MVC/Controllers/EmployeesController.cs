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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            try
            {
                return View(await db.Employees.ToListAsync());
            }
            catch(Exception e)
            {
                return Content("Failed to load Employees index page");
            }
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = await db.Employees.FindAsync(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch(Exception e)
            {
                return Content("Failed to load Employees detail page");
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return Content("Failed to load Employees Create page");
            }
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Employee_Id,Name,Nip")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employees.Add(employee);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                return View(employee);
            }
            catch(Exception e)
            {
                return Content("Failed to create Employees data");
            }
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = await db.Employees.FindAsync(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch(Exception e)
            {
                return Content("Failed to load Employees edit page");
            }
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Employee_Id,Name,Nip")] Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(employee).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                return View(employee);
            }
            catch(Exception e)
            {
                return Content("Failed to edit Employees data");
            }
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Employee employee = await db.Employees.FindAsync(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            catch(Exception e)
            {
                return Content("Failed to load Employees delete page");
            }
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                Employee employee = await db.Employees.FindAsync(id);
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return Content("Failed to delete Employees ");
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
