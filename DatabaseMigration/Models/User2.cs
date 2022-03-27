using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseMigration.Models
{
    internal partial class User
    {
        public string? Company { get; set; }
        public bool? isMarried { get; set; }
    }
}
