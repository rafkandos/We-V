using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wevi.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userid { get; set; }

        [MaxLength(100)]
        [Required]
        public string password { get; set; }

        [MaxLength(20)]
        public string phone { get; set; }

        [MaxLength(80)]
        public string school { get; set; }

        [MaxLength(50)]
        public string major { get; set; }

        [MaxLength(100)]
        public string interest { get; set; }

        [MaxLength(100)]
        [Required]
        public string email { get; set; }

        public DateTime? dateofbirth { get; set; }

        public DateTime? createdon { get; set; }

        public int age { get; set; }

        [MaxLength(200)]
        public string fullname { get; set; }

        [MaxLength(20)]
        public string gender { get; set; }

        public int role { get; set; }

        public string participantcode { get; set; }

        public string profilepicture { get; set; }
    }

    public class outputSingUp
    {
        public string Result { get; set; }
        public object users { get; set; }
        public string Message { get; set; }
    }

    //public class paramlogin
    //{
    //    public string email { get; set; }
    //    public string password { get; set; }
    //}

    //public class outputlogin
    //{
    //    public string Result { get; set; }
    //    public object user { get; set; }
    //    public string Message { get; set; }
    //}
}
