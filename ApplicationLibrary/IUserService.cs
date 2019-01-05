using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public interface IUsersService
    {
        User AddUser(string firstName, string lastName, DateTime birthDate, string email);
        List<User> GetUsers();
        User GetUsersById(int id);
        bool DeleteUserById(int id);
        bool UpdateUser(int id, string newFirstName, string newLastName);
    }
}
