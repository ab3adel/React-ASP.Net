using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using React_Asp.Model;
using Microsoft.EntityFrameworkCore;

namespace React_Asp.Data

{
    public class DonatContext : DbContext
    {
        public DonatContext(DbContextOptions<DonatContext> options):base(options) {}
        public DbSet<User> User { get; set; }
        public DbSet<Quest> Quest { get; set; }
    }
}
