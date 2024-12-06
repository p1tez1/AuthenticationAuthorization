using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace AuthenticationAuthorization.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UserControllers : ControllerBase
    {
        private readonly SignUpServices _signupservices;
        public UserControllers(SignUpServices signupservices)
        {
            _signupservices = signupservices;
        }

        [HttpPost("SignUp")]
        public ActionResult EnterData(string name, string lastname, string birthdaystr, string email,string password, string verpassword, string additionalquestion)
        {
            if(password != verpassword)
            {
                throw new Exception("You write not simular second verification password");
            }

            _signupservices.EnterData(name, lastname, birthdaystr, email, password, additionalquestion);

            return Ok(true);
        }
    }
}
