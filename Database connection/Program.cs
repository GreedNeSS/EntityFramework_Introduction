using Database_connection;

Console.WriteLine("***** Connecting to an existing database *****");
using (usersContext db = new usersContext())
{
    Console.WriteLine("Список обьектов:");

    List<User> users = db.Users.ToList();
    users.ForEach(u => Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}"));
}