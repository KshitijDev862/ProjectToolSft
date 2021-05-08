using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CoreJwt.Models;
using CoreJwt.Models.Login;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CoreJwt.Controllers.Auth {
    [ApiController]
    [Route ("api/[controller]")]
    public class AuthenticationController : ControllerBase {
        private readonly StoreContext _context;
        public AuthenticationController (StoreContext context) {
            _context = context;
        }
        //Register Method api/ApplicationManager/register
        [HttpPost ("register")]
        public async Task<IActionResult> Register ([FromBody] Memberships appuser) {
             var user = await _context.membership.FirstOrDefaultAsync (c => c.UserName == appuser.UserName || c.Email==appuser.Email);
            if (user != null)
                return BadRequest ("Duplicate. Member with this username already exist");

            try {
                appuser.CreatedDate=DateTime.Now;
                await _context.AddAsync (appuser);
                await _context.SaveChangesAsync ();
                return Ok (appuser);
            } catch (Exception ex) {
                throw ex;
            }

        }

        //Login Method api/ApplicationManager/login
        [HttpPost ("login")]
        public async Task<IActionResult> Login (LoginModel loginUser) {
            var user = await _context.membership.FirstOrDefaultAsync (c => c.UserName == loginUser.UserName);
            if (user != null && user.Password == loginUser.Password) {
                var tokenDecriptor = new SecurityTokenDescriptor {
                Subject = new System.Security.Claims.ClaimsIdentity (new Claim[] {
                new Claim ("UserId", user.Id.ToString ())
                }),
                Expires = DateTime.UtcNow.AddMinutes (50),
                SigningCredentials = new SigningCredentials (new SymmetricSecurityKey (Encoding.UTF8.GetBytes ("super secret key")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandeler = new JwtSecurityTokenHandler ();
                var securityToken = tokenHandeler.CreateToken (tokenDecriptor);
                var token = tokenHandeler.WriteToken (securityToken);
                var loginTime=DateTime.Now;
                return Ok (new { token,user, user.Id,loginTime });

            } else {
                return BadRequest (new { message = "UserName & Password Incorrect." });
            }
        }

    }
}