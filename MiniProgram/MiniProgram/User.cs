using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserNamespace
{
    class User
    {
        static int id = 0;

        public User(string name, string surname, int age, string email, string password)
        {
            ID = ++id;
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Password = password;
        }

        public  int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void ShowUser()
        {
            Console.WriteLine("****************************");
            Console.WriteLine($"ID->{ID}");
            Console.WriteLine($"Name->{Name}");
            Console.WriteLine($"Surname->{Surname}");
            Console.WriteLine($"Age->{Age}");
            Console.WriteLine($"Email->{Email}");
            Console.WriteLine("****************************");
            Console.WriteLine("\n");
        }
    }
    
}
