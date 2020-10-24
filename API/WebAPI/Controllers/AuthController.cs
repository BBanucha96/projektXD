using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private DatabaseContext _context { get; set; }

        public AuthController(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// User authentication.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Auth/login
        ///     {
        ///        "emailAdress": "user@test.com",
        ///        "password": "user"
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created TodoItem</returns>
        /// <response code="401">If user is not in database</response>
        /// <response code="200">If user is in database</response>
        [HttpPost, Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (_context.Users.Any(m => m.EmailAddress == user.EmailAddress && m.Password == user.Password))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.EmailAddress),
                    new Claim(ClaimTypes.Role, _context.Users.Where(u => user.EmailAddress == u.EmailAddress ).Single().Type)
                };

                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44336",
                    audience: "http://localhost:44336",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, uType = _context.Users.Where(u => user.EmailAddress == u.EmailAddress).Single().Type });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}