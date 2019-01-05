using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class UsersService : IUsersService
    {
        private List<User> users;
        private static int nextId = 1;

        public UsersService()
        {
            this.users = new List<User>();
        }

        public User AddUser(string firstName, string lastName, DateTime birthDate, string email)
        {
            User user = new User(nextId++, firstName, lastName, birthDate, email);
            this.users.Add(user);
            return user;
        }

        public List<User> GetUsers()
        {
            return this.users;
        }

        public User GetUsersById(int id)
        {
            foreach (User user in this.users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }


        public bool DeleteUserById(int id)
        {
            User user = GetUsersById(id);
            if (user != null)
            {
                users.Remove(user);
                return true;
            }
            return false;
        }

        public bool UpdateUser(int id, string newFirstName, string newLastName)
        {
            User user = GetUsersById(id);
            if (user != null)
            {
                user.FirstName = newFirstName;
                user.LastName = newLastName;
                return true;
            }
            return false;
        }



    }
}
