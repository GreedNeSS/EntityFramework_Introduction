using ConnectionСonfiguration;
using ConnectionСonfiguration.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

Console.WriteLine("***** Connection Сonfiguration *****");
Console.WriteLine("\n=> using Constructor Config");

var optionBuilder = new DbContextOptionsBuilder<ApplicationContex>();
var options = optionBuilder.UseSqlite("Data Source=users.db").Options;

using (ApplicationContex firstConnect = new ApplicationContex(options))
{
    firstConnect.Add(new User { Name = "GreedNeSS", Age = 30 });
    firstConnect.Add(new User { Name = "Marcus", Age = 45 });
    firstConnect.Add(new User { Name = "Henry", Age = 22 });
    firstConnect.SaveChanges();
}

Console.WriteLine("\n=> using JSON Config");

var builder = new ConfigurationBuilder();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsetting.json");
var config = builder.Build();
string connectionString = config.GetConnectionString("DefaultConnection");

optionBuilder = new DbContextOptionsBuilder<ApplicationContex>();
options = optionBuilder.UseSqlite(connectionString).Options;

using (ApplicationContex secondConnect = new ApplicationContex(options))
{
    var users = secondConnect.Users.ToList();
    users.ForEach(u => Console.WriteLine(u));
}