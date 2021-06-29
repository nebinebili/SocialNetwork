using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamespace;
using UserNamespace;
using AdminNamespace;
using NotificationNamespace;
using System.Threading;
using ControlNamespace;

namespace DatabaseNamespace
{
    class Database
    {
        public Post[] Posts { get; set; }
        public User[] Users { get; set; }
        public Admin[] Admins { get; set; }
        public Notification[] Notifications { get; set; }

        public string username;
        public string useremail;
        public string userpassword;

        public void AddPost()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            string text;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("Enter Add Post Content->");
            Console.SetCursorPosition(69, 7);
            text = Console.ReadLine();

            Post newpost = new Post(text);
            Post[] newposts = new Post[Posts.Length + 1];
            for (int i = 0; i < Posts.Length; i++)
            {
                newposts[i] = Posts[i];
            }
            
            newposts[Posts.Length] = newpost;
            Posts = newposts;
            Posts[Posts.Length-1].CreationDateTime = DateTime.Now;
         
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("Post adding...");
            Thread.Sleep(1000);
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("Post added");
            label:

            Console.Write("\nContinue (c) Exit (e)->");
            string text2 = Console.ReadLine();
            char temp2 = Convert.ToChar(text2);

            if (temp2 == 'c') AddPost();
            else if (temp2 != 'e' && temp2!='c') goto label;
            
        }


        public void DeletePost(int id)
        {
            for (int i = 0; i < Posts.Length; i++)
            {
                if (Posts[i].ID == id)
                {
                    Post[] newclients = new Post[Posts.Length - 1];
                    for (int k = 0, j = 0; j < Posts.Length; j++)
                    {
                        if (j != i) newclients[k++] = Posts[j];
                    }
                    Posts = newclients;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nDelete Process is doing...");
                    Thread.Sleep(1000);
                    Console.WriteLine("Delete Post is succesfully");
                }
            }
           
        }

        public void UpdatePost(int id)
        {
            foreach (var post in Posts)
            {
                if (post.ID == id)
                {
                    string text;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Update Post Content->");
                    text = Console.ReadLine();
                    post.Content = text;
                    Console.WriteLine("Update Process is doing...");
                    Thread.Sleep(1000);
                    Console.WriteLine("Update  is succesfully");
                    break;
                }
            }
        }

        public void SignUp()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            
            string name, surname, age, email, password;
            Console.SetCursorPosition(45, 7);
            Console.Write("Enter Name->");
            name = Console.ReadLine();
            Console.SetCursorPosition(45, 8);
            Console.Write("Enter Surname->");
            surname = Console.ReadLine();
            Console.SetCursorPosition(45, 9);
            Console.Write("Enter Age->");
            age = Console.ReadLine();
            var temp = Convert.ToInt32(age);
            Console.SetCursorPosition(45, 10);
            Console.Write("Enter Email->");
            email = Console.ReadLine();
            Console.SetCursorPosition(45, 11);
            Console.Write("Enter Email password->");
            password = Console.ReadLine();

            User newuser = new User(name, surname, temp, email, password);

            
            User[] users = new User[Users.Length + 1];
            for (int i = 0; i < Users.Length; i++)
            {
                users[i] = Users[i];
            }

            users[Users.Length] = newuser;
            Users = users;
            Console.SetCursorPosition(45, 13);
            Console.WriteLine("Wait Process is doing...");
            Thread.Sleep(1000);
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("Sign Up is succesfully");
        }

        public void SignIn()
        {
            bool temp = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            string email,password;
            Console.SetCursorPosition(45, 7);
            Console.Write("Enter Email->");
            email = Console.ReadLine();
            Console.SetCursorPosition(45, 8);
            Console.Write("Enter Email password->");
            password = Console.ReadLine();

            foreach (var user in Users)
            {
                if(user.Email==email && user.Password == password)
                {
                    Console.WriteLine("Sign In is succesfully");
                    username=user.Name;
                    userpassword = user.Password;
                    useremail = user.Email;
                    temp = true;
                    break;
                }
                else if(user.Email==email && user.Password !=password)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Password is wrong");
                    SignIn();
                    break;
                }
                else if(user.Email != email && user.Password ==password)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("User not found");
                    SignIn();
                    break;
                }

            }
            if (temp == false)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("User not found");
                SignIn();
                
            }
            
        }

        public void AddNotification(Notification  newnotification)
        {
            if (Notifications!= null)
            {
                Notification[] newnotific = new Notification[Notifications.Length + 1];
                for (int i = 0; i < Notifications.Length; i++)
                {
                    newnotific[i] = Notifications[i];
                }

                newnotific[Notifications.Length] = newnotification;
                Notifications = newnotific;
            }
            else
            {
                Notification[] newnotific1 = new Notification[1];


                newnotific1[0] = newnotification;
                Notifications = newnotific1;
            }
            

        }
        public void AdminSignIN()
        {
            bool temp = false;
            Console.ForegroundColor = ConsoleColor.Yellow;
            string email, password;
            Console.SetCursorPosition(45, 7);
            Console.Write("Enter Email->");
            email = Console.ReadLine();
            Console.SetCursorPosition(45, 8);
            Console.Write("Enter Email password->");
            password = Console.ReadLine();

            foreach (var admin in Admins)
            {
                if (admin.Email == email && admin.Password == password)
                {
                    Console.WriteLine("Sign In is succesfully");
                    temp = true;
                    break;
                }
                else if (admin.Email == email && admin.Password != password)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Password is wrong");
                    AdminSignIN();
                    break;
                }
                else if(admin.Email != email && admin.Password == password)
                {
                    Console.Clear();
                    Console.SetCursorPosition(45, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Admin not found");
                    AdminSignIN();
                    break;
                }
                
            }
            if (temp == false)
            {
                Console.Clear();
                Console.SetCursorPosition(45, 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Admin not found");
                AdminSignIN();
            }

        }


        public void ShowAllPosts()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            foreach (var post in Posts)
            {
                post.ShowPost();
            }
        }
        public void ShortInfoPosts()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var post in Posts)
            {
                post.ShortInfoPost();
                Console.WriteLine("\n");
            }
        }
        public void ShowAllUsers()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            foreach (var user in Users)
            {
                user.ShowUser();
            }
        }
        public void ShowAllNotification()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (Notifications == null)
            {
                
            }
            else
            {
                foreach (var item in Notifications)
                {
                    item.ShowNotification();
                }
                Notifications = null;
            }
            
        }
       
    }
}
