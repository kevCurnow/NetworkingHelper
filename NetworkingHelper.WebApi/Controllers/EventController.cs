using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NetworkingHelper.Services;
using NetworkingHelper.Models.EventModels;
using Microsoft.AspNet.Identity;

namespace NetworkingHelper.WebApi.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        // GET /api/event
        public IHttpActionResult GetAll()
        {
            var eventService = CreateEventService();
            var events = eventService.GetEvents();
            return Ok(events);
        }
        public IHttpActionResult Get(int id)
        {
            var eventService = CreateEventService();
            var aevent = eventService.GetEventById(id);
            return Ok(aevent);
        }

        public IHttpActionResult Post(EventCreateModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.CreateEvent(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(EventEditModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEventService();

            if (!service.UpdateEvent(model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateEventService();

            if (!service.DeleteEvent(id))
                return InternalServerError();

            return Ok();
        }

        private EventService CreateEventService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var eventService = new EventService(userId);
            return eventService;
        }
    }
}
