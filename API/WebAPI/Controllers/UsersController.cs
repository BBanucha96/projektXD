using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[Route("api/[controller]")]
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
        [HttpGet, Authorize]
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
    }
}