using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int commentid { get; set; }

        public int userid { get; set; }

        [Required]
        public string comment { get; set; }

        [Required]
        public DateTime? commentdate { get; set; }

        [Required]
        public int productid { get; set; }

        [ForeignKey("userid")]
        public virtual User User { get; set; }

        [ForeignKey("productid")]
        public virtual Product Product { get; set; }

    }
}
