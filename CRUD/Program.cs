using CRUD;
using CRUD.Models;

Console.WriteLine("***** CRUD Operations *****");

List<User> users = new List<User>
{
    new User{Name = "GreedNeSS", Age = 30},
    new User{Name = "Marcus", Age = 45},
    new User{Name = "Henry", Age = 22},
};

Console.WriteLine("\nПользователи добавлены:");

UserDAL data = new UserDAL();
data.AddUsers(users);
users = data.GetUsers();
users.ForEach(u => Console.WriteLine(u));

Console.WriteLine("\nДобавлен один пользователь!");

data.AddUser(new User { Name = "Bob", Age = 12 });
users = data.GetUsers();
users.ForEach(u => Console.WriteLine(u));

Console.WriteLine("\nИзменен первый пользователь!");

data.UpdateFirstUser(new User { Name = "Ruslan", Age = 29 });
users = data.GetUsers();
users.ForEach(u => Console.WriteLine(u));

Console.WriteLine("\nУдалён первый пользователь!");

data.DeleteFirstUser();
users = data.GetUsers();
users.ForEach(u => Console.WriteLine(u));