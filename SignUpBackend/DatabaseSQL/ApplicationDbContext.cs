using Microsoft.EntityFrameworkCore;
using SignUpBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpBackend.DatabaseSQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Person { get; set; }
    }
}
