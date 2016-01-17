using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NDependTestDAL;
using NDependTestToDos;

namespace NDependTestWebsite.Controllers
{
    public class ToDoCategoriesController : Controller
    {
        private MyContext db = new MyContext();

        // GET: ToDoCategories
        public ActionResult Index()
        {
            return View(db.ToDoCategories.ToList());
        }

        // GET: ToDoCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoCategory toDoCategory = db.ToDoCategories.Find(id);
            if (toDoCategory == null)
            {
                return HttpNotFound();
            }
            return View(toDoCategory);
        }

        // GET: ToDoCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToDoCategoryID,ToDoCategoryName,IsActive")] ToDoCategory toDoCategory)
        {
            if (ModelState.IsValid)
            {
                db.ToDoCategories.Add(toDoCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoCategory);
        }

        // GET: ToDoCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoCategory toDoCategory = db.ToDoCategories.Find(id);
            if (toDoCategory == null)
            {
                return HttpNotFound();
            }
            return View(toDoCategory);
        }

        // POST: ToDoCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToDoCategoryID,ToDoCategoryName,IsActive")] ToDoCategory toDoCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoCategory);
        }

        // GET: ToDoCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoCategory toDoCategory = db.ToDoCategories.Find(id);
            if (toDoCategory == null)
            {
                return HttpNotFound();
            }
            return View(toDoCategory);
        }

        // POST: ToDoCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoCategory toDoCategory = db.ToDoCategories.Find(id);
            db.ToDoCategories.Remove(toDoCategory);
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
