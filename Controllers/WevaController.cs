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
    public class WevaController : ControllerBase
    {
        private readonly WevDbContext _context;

        public WevaController(WevDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public outputresetpassword Updatepassword(string Updatepassword, paramresetpassword pr)
        {
            outputresetpassword output = new outputresetpassword();

            try
            {
                var dtUsers = _context.User.Where(p => p.email == pr.email).FirstOrDefault();

                dtUsers.password = pr.password;

                _context.SaveChanges();

                if (dtUsers.userid != null && dtUsers.userid != 0)
                {
                    output.Result = "OK";
                    output.user = dtUsers.userid;
                    output.Message = "Reset password Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Failed Update Employee";
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