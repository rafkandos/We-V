using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wevi.Models;

namespace wevi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersZController : ControllerBase
    {
        private readonly WevDbContext _context;

        public UsersZController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/UsersZ
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/UsersZ/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/UsersZ/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.userid)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsersZ
        //[HttpPost]
        //public async Task<ActionResult<User>> PostUser(User user)
        //{
        //    _context.User.Add(user);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetUser", new { id = user.userid }, user);
        //}
        [HttpPost]
        public outputSignUp PostUser(paramSignUp pr)
        {
            outputSignUp output = new outputSignUp();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            try
            {
                User dtUser = new User();
                dtUser.userid = pr.userid;
                dtUser.password = pr.password;
                dtUser.phone = pr.phone;
                dtUser.school = pr.school;
                dtUser.major = pr.major;
                dtUser.interest = pr.interest;
                dtUser.email = pr.email;
                dtUser.dateofbirth = Convert.ToDateTime(pr.dateofbirth);
                dtUser.createdon = DateTime.Now;
                dtUser.age = pr.age;
                dtUser.fullname = pr.fullname;
                dtUser.gender = pr.gender;
                dtUser.participantcode = finalString;
                dtUser.role = pr.role;
                dtUser.profilepicture = pr.profilepicture;

                _context.User.Add(dtUser);
                _context.SaveChanges();

                if (dtUser.userid != null && dtUser.userid != 0)
                {
                    output.Result = "OK";
                    output.users = dtUser.userid;
                    output.Message = "Insert Success";
                }
                else
                {
                    output.Result = "NG";
                    output.Message = "Failed Insert Employee";
                }
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }

            return output;
        }

        // DELETE: api/UsersZ/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.userid == id);
        }
    }
}
