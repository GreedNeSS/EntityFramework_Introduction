using DatabaseMigration;
using DatabaseMigration.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("***** Database migration *****");

using (ApplicationContext db = new ApplicationContext())
{
    //db.Database.Migrate();
}