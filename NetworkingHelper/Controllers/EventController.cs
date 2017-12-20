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
using NetworkingHelper.Contracts;

namespace NetworkingHelper.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private readonly Lazy<IEvent> _eventService;

        public EventController()
        {
            _eventService = new Lazy<IEvent>(() =>
                new EventService(Guid.Parse(User.Identity.GetUserId())));
        }

        public EventController(Lazy<IEvent> eventService)
        {
            _eventService = eventService;
        }

        // GET: Event
        public ActionResult Index()
        {
            
            var model = _eventService.Value.GetEvents();

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

            if (_eventService.Value.CreateEvent(model))
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
            
            var detail = _eventService.Value.GetEventById(id);
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

            if (_eventService.Value.UpdateEvent(model))
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
            var model = _eventService.Value.
                GetEventById(id);
            
            return View(model);
        }

        // GET: Event/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _eventService.Value.GetEventById(id);

            return View(model);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _eventService.Value.DeleteEvent(id);

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

        
    }
}
