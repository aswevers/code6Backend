using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project4_Code6.Data;
using Project4_Code6.Models;
using Project4_Code6.Services;

namespace Project4_Code6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users2Controller : ControllerBase
    {
        private readonly ProjectContext _context;

        public Users2Controller(ProjectContext context, IUserService userService)
        {
            _userService = userService;

            _context = context;
        }
        private IUserService _userService; 
       
        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users2>>> GetUsers()
        {
            return await _context.Users2.ToListAsync();
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<Users2>> GetUser(int id)
        {
            var user = await _context.Users2.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, Users2 user)
        {
            if (id != user.Id)
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

        // POST: api/Users
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(Users2 user)
        {
            _context.Users2.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Users2>> DeleteUser(int id)
        {
            var user = await _context.Users2.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users2.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users2.Any(e => e.Id == id);
        }
    }
}
