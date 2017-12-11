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
                    EventLocation = model.EventLocation,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int eventID)
        {
            throw new NotImplementedException();
        }

        public EventDetailModel GetEventById(int eventID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EventListModel> GetEvents()
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(EventEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
