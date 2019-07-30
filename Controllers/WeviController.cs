using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeviController : ControllerBase
    {
        private readonly WevDbContext _context;

        public WeviController(WevDbContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public outputlogin getDetailLogin(string getDetailLogin, paramlogin pr)
        {
            outputlogin output = new outputlogin();
            var result = new resultlogin();

            try
            {
                var dtlogin = (from x in _context.User

                               where x.email == pr.email && x.password == pr.password
                               select new resultlogin
                               {
                                   ID = x.userid,
                                   fullname = x.fullname,
                                   password = x.password,
                                   //Participantcode = x.participantcode,
                                   Phone = x.phone,
                                   major = x.major,
                                   school = x.school,
                                   email = x.email,
                                   interest = x.interest,
                                   age = x.age,
                                   Dateofbirth = x.dateofbirth,
                                   gender = x.gender,
                                   createdon = x.createdon

                               }).FirstOrDefault();

                if (dtlogin != null)
                {
                    result = dtlogin;

                    output.Result = "OK";
                    output.users = result;
                    output.Message = "Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = " Invalid Email or password";
                }
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }

            return output;
        }


        
    }
}