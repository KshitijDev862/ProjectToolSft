using System.Threading.Tasks;
using CoreJwt.Models;
using CoreJwt.Models.Login;
using CoreJwt.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
namespace CoreJwt.Controllers.Email
{
    [ApiController]
    [Route ("api/[controller]")]
    public class EmailController:ControllerBase {
          private readonly StoreContext _context;
           private readonly IEmailSender _emailSender;
        public EmailController (StoreContext context,IEmailSender emailSender) {
            _context = context;
             _emailSender = emailSender;
        }
         [HttpPost ("SendMail")]
        public async Task<ActionResult> SendMail (EmaiBody emailBody) {
            await _emailSender.SendEmailAsync (emailBody.useremail, emailBody.owneremail, emailBody.mailBody);
            return Ok ();
        }
    }
}