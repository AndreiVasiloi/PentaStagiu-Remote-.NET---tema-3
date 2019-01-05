using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class Application
    {
        private IUsersService usersService;

        public Application(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IEnumerable<User> GetUsers()
        {
            return usersService.GetUsers();
        }

        public User GetUserById(int id)
        {
            return usersService.GetUsersById(id);
        }



        public User AddUser(string firstName, string lastName, DateTime birthDate, string email)
        {
            return usersService.AddUser(firstName, lastName, birthDate, email);
        }

        public bool DeleteUserById(int id)
        {
            return usersService.DeleteUserById(id);
        }

        public bool UpdateUser(int id, string newFirstName, string newLastName)
        {
            return usersService.UpdateUser(id, newFirstName, newLastName);
        }
    }
}
