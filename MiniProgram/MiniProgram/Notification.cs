using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotificationNamespace
{
    class Notification
    {
        static int id = 0;

        

        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public string FromUser { get; set; }

        public Notification(string text, string fromUser)
        {
            ID = ++id;
            Text = text;
            DateTime = DateTime.Now;
            FromUser = fromUser;
        }

        public void ShowNotification()
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"ID->{ID}");
            Console.WriteLine($"Text->{Text}");
            Console.WriteLine($"DateTime->{DateTime.ToShortDateString()}");
            Console.WriteLine($"FromUser->{FromUser}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("\n");
        }
    }
}
