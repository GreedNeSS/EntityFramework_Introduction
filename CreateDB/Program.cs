using CreateDB.Models;
using CreateDB;

Console.WriteLine("***** Create DB *****");

using (ApplicationContext db = new ApplicationContext())
{
    User greedness = new User { Name = "GreedNeSS", Age = 30 };
    User marcus = new User { Name = "Marcus", Age = 45 };
    db.Users.Add(greedness);
    db.Users.Add(marcus);
    db.SaveChanges();

    Console.WriteLine("Обьекты успешно сохранены!");
    Console.WriteLine("\nПолучение пользователей из базы данных!");

    List<User> users = db.Users.ToList();
    users.ForEach(u => Console.WriteLine(u));
}