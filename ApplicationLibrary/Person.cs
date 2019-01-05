using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLibrary
{
    public class Person
    {
        public virtual string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public override string ToString()
        {
            return FullName;
        }


        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value) == false)
                {
                    firstName = value;
                }
            }
        }
        public string LastName { get; set; }

        public DateTime BirthDate { get; private set; }


        public double Age
        {
            get
            {
                return (DateTime.Now - this.BirthDate).TotalDays / 365.2425;
            }
        }


        public Person(string firstName, string lastName, DateTime birthDate)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;

        }
    }
}
