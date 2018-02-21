using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Models.EventModels
{
    public class EventCreateModel
    {
        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTimeOffset EventDate { get; set; }

        [Required]
        public string EventTime { get; set; }

        [Required]
        public string EventLocation { get; set; }
    }
}
