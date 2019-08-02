using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class HistoryEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hisevid { get; set; }

        public int userid { get; set; }

        public int eventid { get; set; }

        public DateTime? jointime { get; set; }

        [ForeignKey("userid")]
        public virtual User User { get; set; }

        [ForeignKey("eventid")]
        public virtual Event Event { get; set; }
    }
}
