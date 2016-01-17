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
    public class ToDosController : Controller
    {
        private MyContext db = new MyContext();

        // GET: ToDos
        public ActionResult Index()
        {
            var toDos = db.ToDos.Include(t => t.ToDoCategory);
            return View(toDos.ToList());
        }

        // GET: ToDos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // GET: ToDos/Create
        public ActionResult Create()
        {
            ViewBag.ToDoCategoryID = new SelectList(db.ToDoCategories, "ToDoCategoryID", "ToDoCategoryName");
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ToDoID,Text,AdditionalDetails,IsComplete,CompleteBy,ToDoPriority,ToDoCategoryID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.ToDos.Add(toDo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ToDoCategoryID = new SelectList(db.ToDoCategories, "ToDoCategoryID", "ToDoCategoryName", toDo.ToDoCategoryID);
            return View(toDo);
        }

        // GET: ToDos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ToDoCategoryID = new SelectList(db.ToDoCategories, "ToDoCategoryID", "ToDoCategoryName", toDo.ToDoCategoryID);
            return View(toDo);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ToDoID,Text,AdditionalDetails,IsComplete,CompleteBy,ToDoPriority,ToDoCategoryID")] ToDo toDo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ToDoCategoryID = new SelectList(db.ToDoCategories, "ToDoCategoryID", "ToDoCategoryName", toDo.ToDoCategoryID);
            return View(toDo);
        }

        // GET: ToDos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDo toDo = db.ToDos.Find(id);
            if (toDo == null)
            {
                return HttpNotFound();
            }
            return View(toDo);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDo toDo = db.ToDos.Find(id);
            db.ToDos.Remove(toDo);
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
