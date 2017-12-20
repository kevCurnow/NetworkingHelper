using NetworkingHelper.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkingHelper.Models.EventModels;

namespace NetworkingHelper.Web.Tests.Controllers.EventControllerTests
{
    public class FakeEventService : IEvent
    {
        public int CreateEventCallCount { get; private set; }
        public bool CreateEventReturnValue { private get; set; } = true;

        public bool CreateEvent(EventCreateModel model)
        {
            CreateEventCallCount++;

            return CreateEventReturnValue;
        }

        public IEnumerable<EventListModel> GetEvents()
        {
            throw new NotImplementedException();
        }

        public EventDetailModel GetEventById(int eventID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEvent(EventEditModel model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEvent(int eventID)
        {
            throw new NotImplementedException();
        }
    }
}
