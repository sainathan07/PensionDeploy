using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Collections.Generic;
using System.Security.Claims;
using System;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : Controller
    {

        [HttpPost,Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if(user == null)
                return BadRequest("Invalid request");

            if((user.UserName == "sai" && user.Password=="sai123")|| (user.UserName == "admin" && user.Password == "admin123"))
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokenOptions = new JwtSecurityToken(
                    issuer: "http://localhost:42891/",
                    audience: "http://localhost:42891/",
                    claims: new List<Claim>(),
                    expires:DateTime.Now.AddMinutes(30),
                    signingCredentials:signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
