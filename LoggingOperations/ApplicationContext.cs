using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using LoggingOperations.Models;

namespace LoggingOperations
{
    public class ApplicationContext: DbContext
    {
        private readonly StreamWriter _writer = new StreamWriter("log.txt", true);
        public DbSet<User> Users => Set<User>();

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
            optionsBuilder.LogTo(message =>
            {
                Console.WriteLine(message);
                _writer.WriteLine(message);
            }
            // OR
            //,Microsoft.Extensions.Logging.LogLevel.Information

            // OR
            //, new[] { RelationalEventId.CommandExecuted }

            // OR
            //, new[] { DbLoggerCategory.Database.Transaction.Name }
            
            // OR
            , new[] { DbLoggerCategory.Database.Command.Name }
            );
        }

        public override void Dispose()
        {
            base.Dispose();
            _writer.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            await _writer.DisposeAsync();
        }
    }
}
