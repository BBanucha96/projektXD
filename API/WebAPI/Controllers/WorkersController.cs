using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkersController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public WorkersController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get list of workers.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Workers
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="401">Unauthorized request</response>
        /// <response code="200">Request success</response>
        [HttpGet, Authorize]
        public IEnumerable<Worker> Get()
        {
            return _context.Workers.ToList();
        }

        /// <summary>
        /// Get one user by it id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Workers/1
        ///
        /// </remarks>
        /// <param id="id"></param>  
        /// <returns>A newly created TodoItem</returns>
        /// <response code="401">Unauthorized request</response>
        /// <response code="200">Request success</response>
        [HttpGet("{id}"), Authorize]
        public Worker GetOne(int id)
        {
            return _context.Workers.SingleOrDefault(m => m.Id == id);
        }
        /// <summary>
        /// Create user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Workers
        ///     {
        ///         "id": 0,
        ///         "avatar": "string",
        ///         "name": "string",
        ///         "surname": "string",
        ///         "job": "string",
        ///         "descript": "string"
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created User</returns>
        /// <response code="401">Unauthorized request</response>
        /// <response code="200">Worker created</response>
        /// <response code="403">Request forbidden</response>
        [HttpPost, Authorize(Roles = "admin")]
        public bool Create([FromBody] Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Update data of worker.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Workers/1
        ///     {
        ///         "id": 0,
        ///         "avatar": "string",
        ///         "name": "string",
        ///         "surname": "string",
        ///         "job": "string",
        ///         "descript": "string"
        ///     }
        ///
        /// </remarks>  
        /// <param id="id"></param> 
        /// <returns>A newly created TodoItem</returns>
        /// <response code="401">If user is not in database</response>
        /// <response code="200">If user is in database</response>
        /// <response code="403">Request forbidden</response>
        [HttpPut("{id}"), Authorize(Roles = "admin")]
        public bool Update(int id, [FromBody] Worker worker)
        {
            _context.Workers.Update(worker);
            _context.SaveChanges();
            return true;
        }
        /// <summary>
        /// Delete user by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Workers/1
        ///
        /// </remarks>  
        /// <param id="id"></param> 
        /// <returns>None</returns>
        /// <response code="403">Request forbidden</response>
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            var student = _context.Workers.FirstOrDefault(t => t.Id == id);
            if (student != null)
            {
                _context.Workers.Remove(student);
                _context.SaveChanges();
            }
        }
    }
}
