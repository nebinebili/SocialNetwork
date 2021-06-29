using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationNamespace;
using PostNamespace;

namespace AdminNamespace
{
    class Admin
    {
        static int id = 0;

        public Admin(string username, string email, string password)
        {
            ID = ++id;
            Username = username;
            Email = email;
            Password = password;
        }

        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string  Password { get; set; }
    }
}
