using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkingHelper.Models.ConnectionModels;
using NetworkingHelper.Models.EventModels;

namespace NetworkingHelper.Models.EventConnectionModels
{
    public class ConnectionEventData
    {
        public IEnumerable<ConnectionCreateModel> CreateConnection { get; set; }
        public IEnumerable<ConnectionDetailModel> ConnectionDetails { get; set; }
        public IEnumerable<ConnectionEditModel> EditConnection { get; set; }
        public IEnumerable<ConnectionListModel> ListConnections { get; set; }
        
        public IEnumerable<EventCreateModel> CreateEvent { get; set; }
        public IEnumerable<EventCreateModel> EventDetails { get; set; }
        public IEnumerable<EventEditModel> EditEvent { get; set; }
        public IEnumerable<EventListModel> ListEvents { get; set; }
    }
}
