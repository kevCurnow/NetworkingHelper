using NetworkingHelper.Models.EventModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Contracts
{
    public interface IEvent
    {
        bool CreateEvent(EventCreateModel model);
        IEnumerable<EventListModel> GetEvents();
        EventDetailModel GetEventById(int eventID);
        bool UpdateEvent(EventEditModel model);
        bool DeleteEvent(int eventID);
    }
}
