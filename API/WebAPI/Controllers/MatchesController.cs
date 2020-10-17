using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public MatchesController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of matches.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Matches
        ///
        /// </remarks>
        /// <returns>List of matches</returns>
        /// <response code="401">If data is not in database</response>
        /// <response code="200">If data is in database</response>
        [HttpGet, /*Authorize*/]
        public IEnumerable<Matches> Get()
        {
            return _context.Matches.ToList();
        }
    }
}
