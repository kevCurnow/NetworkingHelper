using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetworkingHelper.Data;
using NetworkingHelper.Services;
using Microsoft.AspNet.Identity;
using NetworkingHelper.Models.ConnectionModels;


namespace NetworkingHelper.Controllers
{
    [Authorize]
    public class ConnectionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Connection
        public ActionResult Index(string searchString)
        {
            var service = CreateConnectionService();
            var model = service.GetConnections();
            if (!String.IsNullOrEmpty(searchString))
            {
                model = model.Where(e => e.EventName.Contains(searchString));
            }

            return View(model);
        }

        // GET: Connection/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Connection/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ConnectionCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateConnectionService();

            if (service.CreateConnection(model))
            {
                TempData["SaveResult"] = "Your connection was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your connection could not be created.");
            return View(model);
        }

        // GET: Connection/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateConnectionService();
            var detail = service.GetConnectionById(id);
            var model =
                new ConnectionEditModel
                {
                    ConnectionID = detail.ConnectionID,
                    ConnectionName = detail.ConnectionName,
                    Job = detail.Job,
                    Employer = detail.Employer,
                    Phone = detail.Phone,
                    Email = detail.Phone,
                    Notes = detail.Notes
                };

            return View(model);
        }

        // POST: Connection/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ConnectionEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ConnectionID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateConnectionService();

            if (service.UpdateConnection(model))
            {
                TempData["SaveResult"] = "Your connection was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your connection could not be updated.");
            return View(model);
        }

        // GET: Connection/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateConnectionService();
            var model = svc.GetConnectionById(id);

            return View(model);
        }

        // GET: Connection/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = CreateConnectionService();
            var model = svc.GetConnectionById(id);

            return View(model);
        }

        // POST: Connection/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateConnectionService();

            service.DeleteConnection(id);

            TempData["SaveResult"] = "Your connection was deleted!";
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

        private ConnectionService CreateConnectionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ConnectionService(userId);
            return service;
        }
    }
}
