using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int eventid { get; set; }

        public string eventname { get; set; }

        public string detailevent { get; set; }

        public DateTime? eventdate { get; set; }

        public string statusevent { get; set; }

        public string eventcode { get; set; }

        public int countingevent { get; set; }

        public string linkstring { get; set; }

        public string bannerevent { get; set; }
    }
}
