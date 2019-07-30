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
    public class WeVoController : ControllerBase
    {
        private readonly WevDbContext _context;

        public WeVoController(WevDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public outputchangepassword Changepassword(string Changepassword, paramchangepassword pr)
        {
            outputchangepassword output = new outputchangepassword();

            try
            {
                var dtUsers = _context.User.Where(p => p.userid == pr.userid).FirstOrDefault();

                dtUsers.password = pr.password;

                _context.SaveChanges();

                if (dtUsers.userid != null && dtUsers.userid != 0)
                {
                    output.Result = "OK";
                    output.user = dtUsers.userid;
                    output.Message = "Change Password Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Failed Change Password";
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