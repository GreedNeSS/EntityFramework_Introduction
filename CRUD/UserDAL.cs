using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD;
using CRUD.Models;

namespace CRUD
{
    internal class UserDAL
    {
        private ApplicationContext _db = null!;
        private readonly string _connectionString = "Data Source=user.db";

        public UserDAL()
        {

        }

        public UserDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        private void OpenConnection()
        {
                _db = new ApplicationContext(_connectionString);
        }

        private void CloseConnection()
        {
            _db.Dispose();
        }

        public void AddUser(User user)
        {
            try
            {
                OpenConnection();
                _db.Add(user);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void AddUsers(List<User> users)
        {
            try
            {
                OpenConnection();

                foreach (User user in users)
                {
                    _db.Add(user);
                }

                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateFirstUser(User user)
        {
            try
            {
                OpenConnection();

                User? firstUser = _db.Users.FirstOrDefault();
                if (firstUser != null)
                {
                    firstUser.Name = user.Name;
                    firstUser.Age = user.Age;
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public void DeleteFirstUser()
        {
            try
            {
                OpenConnection();
                User? firstUser = _db.Users.FirstOrDefault();

                if (firstUser != null)
                {
                    _db.Remove(firstUser);
                    _db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            try
            {
                OpenConnection();
                users = _db.Users.ToList<User>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                CloseConnection();
            }

            return users;
        }
    }
}
