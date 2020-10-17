using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersMatchesController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public UsersMatchesController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of users matches.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /UsersMatches
        ///
        /// </remarks>
        /// <returns>List of users matches</returns>
        /// <response code="401">If data is not in database</response>
        /// <response code="200">If data is in database</response>
        [HttpGet, /*Authorize*/]
        public IEnumerable<UsersMatches> Get()
        {
            return _context.UsersMatches.ToList();
        }
    }
}
