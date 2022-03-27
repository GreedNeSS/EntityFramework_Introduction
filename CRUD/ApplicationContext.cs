using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;

namespace CRUD
{
    public class ApplicationContext: DbContext
    {
        private readonly string _connectionString;
        public DbSet<User> Users => Set<User>();

        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }
    }
}
