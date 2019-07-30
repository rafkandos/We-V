using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wevi.Models
{
    public class outputlogin
    {
        public string Result { get; set; }
        public object users { get; set; }
        public string Message { get; set; }
    }
    public class resultlogin
    {
        public int ID { get; set; }
        public string fullname { get; set; }
        public string password { get; set; }
        public string Phone { get; set; }
        public string school { get; set; }
        public string major { get; set; }
        public string interest { get; set; }
        public string email { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? age { get; set; }
        public string gender { get; set; }
        public DateTime? createdon { get; set; }
    }
    public class paramlogin
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class outputresetpassword
    {
        public string Result { get; set; }
        public object user { get; set; }
        public string Message { get; set; }
    }
    public class resultresetpassword
    {
        public string email { get; set; }
        public string password { get; set; }

    }
    public class paramresetpassword
    {
        public string email { get; set; }
        public string password { get; set; }
    }

    public class outputchangepassword
    {
        public string Result { get; set; }
        public object user { get; set; }
        public string Message { get; set; }
    }
    public class resultchangepassword
    {
        public int userid { get; set; }
        public string password { get; set; }

    }
    public class paramchangepassword
    {
        public int userid { get; set; }
        public string password { get; set; }
    }

    public class outputSignUp
    {
        public string Result { get; set; }
        public object users { get; set; }
        public string Message { get; set; }
    }
    public class resultSignUp
    {
        public int ID { get; set; }
        public string fullname { get; set; }
        public string Participantcode { get; set; }
        public string password { get; set; }
        public string Phone { get; set; }
        public string school { get; set; }
        public string major { get; set; }
        public string interest { get; set; }
        public string email { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? age { get; set; }
        public string gender { get; set; }
    }
}
