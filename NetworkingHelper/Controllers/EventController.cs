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
using NetworkingHelper.Models.EventModels;

namespace NetworkingHelper.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Event
        public ActionResult Index()
        {
            var service = CreateEventService();
            var model = service.GetEvents();

            return View(model);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateEventService();

            if (service.CreateEvent(model))
            {
                TempData["SaveResult"] = "Your event was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your event could not be created.");
            return View(model);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateEventService();
            var detail = service.GetEventById(id);
            var model =
                new EventEditModel
                {
                    EventID = detail.EventID,
                    EventName = detail.EventName,
                    EventDate = detail.EventDate,
                    EventLocation = detail.EventLocation
                };

            return View(model);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EventEditModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EventID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateEventService();

            if (service.UpdateEvent(model))
            {
                TempData["SaveResult"] = "Your event was updated";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your event could not be updated.");
            return View(model);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);
            
            return View(model);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var svc = CreateEventService();
            var model = svc.GetEventById(id);

            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateEventService();

            service.DeleteEvent(id);

            TempData["SaveResult"] = "Your event was deleted!";
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

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EventService(userId);
            return service;
        }
    }
}
