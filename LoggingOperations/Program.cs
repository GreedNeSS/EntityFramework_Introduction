using LoggingOperations;
using LoggingOperations.Models;

Console.WriteLine("***** Logging Operations *****");

User user1 = new User { Name = "GreedNeSS", Age = 30 };
User user2 = new User { Name = "Marcus", Age = 45 };

using (ApplicationContext db = new ApplicationContext())
{
    db.Add(user1);
    db.Add(user2);
    db.SaveChanges();

    var users = db.Users.ToList();

    foreach (var u in users)
    {
        Console.WriteLine(u);
    }
}