using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public DateOnly Birthday {  get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string AdditionalQuestion { get; set; }
        public User(){  }
        public User(string name, string lastname, DateOnly birthday, string email, string password, string additionalquestion) 
        {
            this.Id = Guid.NewGuid();
            this.Name = name;
            this.LastName = lastname;   
            this.Birthday = birthday;
            this.Email = email;
            this.Password = password;
            this.AdditionalQuestion = additionalquestion;
        }
    }
}
