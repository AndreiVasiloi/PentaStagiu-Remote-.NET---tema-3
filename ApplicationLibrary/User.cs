using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class User : Person
    {

        public int Id { get; private set; }

        public User(int id, string firstName, string lastName, DateTime birthDate, string email)
            : base(firstName, lastName, birthDate)
        {
            this.Id = id;

        }
    }
}
