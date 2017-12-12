using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetworkingHelper.Data;

namespace NetworkingHelper.Controllers
{
    public class ConnectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Connection
        public ActionResult Index()
        {
            var connections = db.Connections.Include(c => c.Events);
            return View(connections.ToList());
        }

        // GET: Connection/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionEntity connectionEntity = db.Connections.Find(id);
            if (connectionEntity == null)
            {
                return HttpNotFound();
            }
            return View(connectionEntity);
        }

        // GET: Connection/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName");
            return View();
        }

        // POST: Connection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConnectionID,UserID,ConnectionName,Job,Employer,Phone,Email,Notes,EventID")] ConnectionEntity connectionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Connections.Add(connectionEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", connectionEntity.EventID);
            return View(connectionEntity);
        }

        // GET: Connection/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionEntity connectionEntity = db.Connections.Find(id);
            if (connectionEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", connectionEntity.EventID);
            return View(connectionEntity);
        }

        // POST: Connection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConnectionID,UserID,ConnectionName,Job,Employer,Phone,Email,Notes,EventID")] ConnectionEntity connectionEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(connectionEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventID = new SelectList(db.Events, "EventID", "EventName", connectionEntity.EventID);
            return View(connectionEntity);
        }

        // GET: Connection/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConnectionEntity connectionEntity = db.Connections.Find(id);
            if (connectionEntity == null)
            {
                return HttpNotFound();
            }
            return View(connectionEntity);
        }

        // POST: Connection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ConnectionEntity connectionEntity = db.Connections.Find(id);
            db.Connections.Remove(connectionEntity);
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
