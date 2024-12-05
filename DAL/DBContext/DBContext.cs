using DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext
{
    public class UserContext : DbContext
    {
        
        public DbSet<User> Users { get; set; }
        public UserContext(DbContextOptions options) : base(options) { }


    }
}
