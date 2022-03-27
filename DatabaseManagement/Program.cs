using DatabaseManagement;

Console.WriteLine("***** Database Management *****");

using (ApplicationContext db = new ApplicationContext())
{
    bool isAvailable = await db.Database.CanConnectAsync();
    Console.WriteLine(isAvailable ? "\nБаза данных существует!" : "\nБаза данных не существует!");

    bool isCreated = await db.Database.EnsureCreatedAsync();
    Console.WriteLine(isCreated ? "\nБаза данных создана." : "\nБаза данных была создана раньше.");

    isAvailable = await db.Database.CanConnectAsync();
    Console.WriteLine(isAvailable ? "База данных существует!" : "База данных не существует!");

    bool isDeleted = await db.Database.EnsureDeletedAsync();
    Console.WriteLine(isDeleted ? "\nБаза данных удалена." : "\nБаза данных не была удалена.");

    isAvailable = await db.Database.CanConnectAsync();
    Console.WriteLine(isAvailable ? "База данных существует!" : "База данных не существует!");
}