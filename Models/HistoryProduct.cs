using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class HistoryProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int hisproid { get; set; }

        public int userid { get; set; }

        public int productid { get; set; }

        public DateTime? scantime { get; set; }

        [ForeignKey("userid")]
        public virtual User User { get; set; }

        [ForeignKey("productid")]
        public virtual Product Product { get; set; }
    }
}
