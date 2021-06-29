using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostNamespace
{
    class Post
    {
        static int id = 0;

       

        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreationDateTime { get; set; }
        public int LikeCount { get; set; }
        public int ViewCount { get; set; }

        
        public Post( string content)
        {
            ID = ++id;
            Content = content;
            CreationDateTime = datetime();

        }
        public DateTime datetime()
        {
            
            Random rd = new Random();
            DateTime dt = new DateTime(2021, rd.Next(1, 13), rd.Next(1, 32));

            return dt;
        }


        public void ShowPost()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine($"ID->{ID}");
            Console.WriteLine($"Content->{Content}");
            Console.WriteLine($"DateTime->{CreationDateTime.ToShortDateString()}");
            Console.WriteLine($"LikeCount->{LikeCount}");
            Console.WriteLine($"ViewCount->{ViewCount}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("\n");
        }

        public void ShortInfoPost()
        {
            Console.WriteLine($"ID->{ID}");
            Console.WriteLine($"Content->{Content}");
        }
    }
}
