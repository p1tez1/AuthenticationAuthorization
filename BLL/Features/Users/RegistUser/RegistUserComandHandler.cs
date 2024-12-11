using BLL.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Features.Users.RegistUser
{
    public class RegistUserComandHandler : IRequestHandler<RegistUserComand, bool>
    {
        private readonly ISignUpServices _signUpServices;
        public RegistUserComandHandler (ISignUpServices signUpServices )
        {
            _signUpServices = signUpServices;
        }
        public async Task<bool> Handle(RegistUserComand request, CancellationToken cancellationToken)
        {
            var result = _signUpServices.EnterData(request.name, request.lastname, request.birthdaystr, request.email, request.password, request.additionalquestion);
            return await result;
        }
    }
}
