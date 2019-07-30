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
    public class UsersController : ControllerBase
    {
        private readonly WevDbContext _context;

        public UsersController(WevDbContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<outputSignUp> GetUser()
        {
            //await _context.User.ToListAsync();

            outputSignUp output = new outputSignUp();

            try
            {
                output.Result = "OK";
                output.users = await _context.User.ToListAsync();
                output.Message = "Success";
            }
            catch (Exception ex)
            {
                output.Result = "NG";
                output.Message = ex.ToString();
            }
            return output;

        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<outputSignUp> GetUser(int id)
        {
            outputSignUp output = new outputSignUp();

            try
            {
                var user = await _context.User.FindAsync(id);

                if (user != null)
                {
                    output.Result = "OK";
                    output.users = user;
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

        [HttpPost]
        public async Task<outputSignUp> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            outputSignUp output = new outputSignUp();
            var result = new User();

            try
            {
                if (user.userid != 0)
                {
                    result = user;

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

        // DELETE: api/Users/5
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
