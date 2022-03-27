using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConnectionСonfiguration.Models;

namespace ConnectionСonfiguration
{
    internal class ApplicationContex: DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContex(DbContextOptions<ApplicationContex> options):
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}
