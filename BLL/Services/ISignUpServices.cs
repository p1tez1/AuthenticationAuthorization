using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ISignUpServices
    {
        public Task<bool> EnterData(string name, string lastname, string birthdaystr, string email, string password, string additionalquestion);
    }
}
