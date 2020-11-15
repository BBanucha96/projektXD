using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public UsersController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of users.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Users
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="401">If user is not in database</response>
        /// <response code="200">If user is in database</response>
        [HttpGet, /*Authorize*/]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }
        /// <summary>
        /// Get one user by id.
        /// </summary>
        [HttpGet("{id}"), Authorize]
        public User GetOne(int id)
        {
            return _context.Users.SingleOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Create user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /User
        ///     {
        ///         "Username": "string",
        ///         "Password": "string",
        ///         "EmailAddress": "string",
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created User</returns>
        /// <response code="401">Unauthorized request</response>
        /// <response code="200">Worker created</response>
        /// <response code="403">Request forbidden</response>
        [HttpPost]
        public bool Register([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }
    }
}