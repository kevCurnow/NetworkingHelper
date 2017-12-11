using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkingHelper.Data
{
    public class EventEntity
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTimeOffset EventDate { get; set; }

        [Required]
        public string EventLocation { get; set; }

        public virtual ICollection<ConnectionEntity> Connections { get; set; }
    }
}
