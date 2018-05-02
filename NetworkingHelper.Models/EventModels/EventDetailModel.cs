using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Models.EventModels
{
    public class EventDetailModel
    {
        public int EventID { get; set; }
        public string EventName { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public string EventTime { get; set; }
        public string EventLocation { get; set; }
    }
}
