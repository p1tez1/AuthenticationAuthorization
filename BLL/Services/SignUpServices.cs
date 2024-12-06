using DAL.DBContext;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SignUpServices
    {
        private readonly UserContext _context;

        public SignUpServices(UserContext context)
        {
            _context = context;
        }

         public bool EnterData(string name, string lastname, string birthdaystr, string email, string password, string additionalquestion)
         {
            DateOnly birthday = DateOnly.Parse(birthdaystr);
            User user = new User(name,lastname,birthday,email,password,additionalquestion);
            _context.Users.AddAsync(user);
            _context.SaveChanges();
            return true;
         }
    }
}
