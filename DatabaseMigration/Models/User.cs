using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigration.Models
{
    internal partial class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, name: {Name}, Age: {Age}";
        }
    }
}
