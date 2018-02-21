using NetworkingHelper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkingHelper.Models.EventModels;
using NetworkingHelper.Data;

namespace NetworkingHelper.Services
{
    public class EventService : IEvent
    {
        private readonly Guid _userId;

        public EventService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateEvent(EventCreateModel model)
        {
            var entity =
                new EventEntity
                {
                    UserID = _userId,
                    EventName = model.EventName,
                    EventDate = model.EventDate,
                    EventTime = model.EventTime,
                    EventLocation = model.EventLocation,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListModel> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.UserID == _userId)
                        .Select(
                            e =>
                                new EventListModel
                                {
                                    EventID = e.EventID,
                                    EventName = e.EventName,
                                    EventDate = e.EventDate,
                                    EventTime = e.EventTime,
                                    EventLocation = e.EventLocation
                                }
                        );

                return query.ToArray();
            }
        }

        public EventDetailModel GetEventById(int eventID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == eventID && e.UserID == _userId);

                return
                    new EventDetailModel
                    {
                        EventID = entity.EventID,
                        EventName = entity.EventName,
                        EventDate = entity.EventDate,
                        EventTime = entity.EventTime,
                        EventLocation = entity.EventLocation
                    };
            }
        }

        public bool UpdateEvent(EventEditModel model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == model.EventID && e.UserID == _userId);

                entity.EventName = model.EventName;
                entity.EventDate = model.EventDate;
                entity.EventTime = model.EventTime;
                entity.EventLocation = model.EventLocation;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int eventID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventID == eventID && e.UserID == _userId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
