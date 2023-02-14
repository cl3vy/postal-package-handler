using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageCheckIn.Classes;

namespace PackageCheckIn.Classes
{
    public class Person
    {
        protected string name;
        protected string surname;
        protected string email;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name must not be null");
                }
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    surname = value;
                }
                else
                {
                    Console.WriteLine("Surname must not be null");
                }
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (value.EndsWith(".com"))
                {
                    email = value;
                }
                else
                {
                    Console.WriteLine("You need to enter a valid email");
                }
            }
        }
    }
}
