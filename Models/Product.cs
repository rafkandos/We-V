using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productid { get; set; }

        public string productname { get; set; }

        public string productdetail { get; set; }

        public string productcode { get; set; }

        public string bannerproduct { get; set; }

        public string linkstring { get; set; }
    }
}
