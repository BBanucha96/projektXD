using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRanksController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public UsersRanksController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of users ranks.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /UsersRanks
        ///
        /// </remarks>
        /// <returns>List of users ranks</returns>
        /// <response code="401">If data is not in database</response>
        /// <response code="200">If data is in database</response>
        [HttpGet, /*Authorize*/]
        public IEnumerable<UsersRanks> Get()
        {
            return _context.UsersRanks.ToList();
        }
    }
}
