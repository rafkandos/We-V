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
        public int userid { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string school { get; set; }
        public string major { get; set; }
        public string interest { get; set; }
        public string email { get; set; }
        public DateTime? dateofbirth { get; set; }
        public DateTime? createdon { get; set; }
        public int age { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public int role { get; set; }
        public string participantcode { get; set; }
        public string profilepicture { get; set; }
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
    public class paramSignUp
    {
        public int userid { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string school { get; set; }
        public string major { get; set; }
        public string interest { get; set; }
        public string email { get; set; }
        public DateTime? dateofbirth { get; set; }
        public DateTime? createdon { get; set; }
        public int age { get; set; }
        public string fullname { get; set; }
        public string gender { get; set; }
        public int role { get; set; }
        public string participantcode { get; set; }
        public string profilepicture { get; set; }
    }

    public class outputHisPro
    {
        public string Result { get; set; }
        public object hispro { get; set; }
        public string Message { get; set; }
    }

    public class outputGetCommentById
    {
        public string Result { get; set; }
        public object comments { get; set; }
        public string Message { get; set; }
    }
    public class resultGetCommentById
    {
        public string fullname { get; set; }
        public string comment { get; set; }
        public DateTime? commentdate { get; set; }

    }
    public class paramGetCommentById
    {
        public int productid { get; set; }
    }

    public class outputHistoryEvent
    {
        public string Result { get; set; }
        public object events { get; set; }
        public string Message { get; set; }
    }
    public class resultHistoryEvent
    {
        public string eventname { get; set; }
        public string place { get; set; }
        public DateTime? eventdate { get; set; }

    }
    public class paramHistoryEvent
    {
        public int userid { get; set; }
    }

    public class outputScanQr
    {
        public string Result { get; set; }
        public object products { get; set; }
        public string Message { get; set; }
    }
    public class resultScanQr
    {
        public int productid { get; set; }
        public string productname { get; set; }
        public string productdetail { get; set; }
        public string productcode { get; set; }
        public string bannerproduct { get; set; }
        public string linkstring { get; set; }
    }
    public class paramScanQr
    {
        public int hisproid { get; set; }
        public int userid { get; set; }
        public int productid { get; set; }
        public DateTime? scantime { get; set; }
    }

    public class outputHisEvt
    {
        public string Result { get; set; }
        public object hisevt { get; set; }
        public string Message { get; set; }
    }
}
