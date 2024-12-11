using BLL.Features.Heshing;
using BLL.Features.Users.RegistUser;
using BLL.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace AuthenticationAuthorization.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly IHeshing _heshing;
        private readonly ISender _sender;

        public UserControllers(ISender sender, IHeshing heshing)
        {
            _sender = sender;
            _heshing = heshing; 
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> EnterData(string name, string lastname, string birthdaystr, string email,string password, string verpassword, string additionalquestion)
        {
            if(password != verpassword)
            {
                throw new Exception("You write not simular second verification password");
            }
            
            password = _heshing.Hash(password);
            var comand = new RegistUserComand(name,lastname,birthdaystr,email,password,additionalquestion);
            bool result = await _sender.Send(comand);

            return Ok(result);
        }
    }
}
