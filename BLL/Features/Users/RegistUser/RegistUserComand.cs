using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Features.Users.RegistUser
{
    public record RegistUserComand(string name, string lastname, string birthdaystr, string email, string password, string additionalquestion) : IRequest<bool>;
}
