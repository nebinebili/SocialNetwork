using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminNamespace;
using PostNamespace;
using UserNamespace;
using DatabaseNamespace;
using NotificationNamespace;
using NetworkNamespace;
using System.Threading;

namespace ControlNamespace
{

    class Control
    {
        string text;
        Database database;

        void AddPost()
        {
            database.AddPost();
            Console.WriteLine("\n");
            BackAdmin();
        }
        void DeletePost()
        {
            
            while (true)
            {
                Console.Clear();
                database.ShortInfoPosts();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nEnter Delete post Id:");
                text = Console.ReadLine();
                var temp = Convert.ToInt32(text);
                database.DeletePost(temp);
                
                label:

                Console.Write("\nContinue (c) Exit (e)->");
                string text2 = Console.ReadLine();
                char temp2 = Convert.ToChar(text2);

                if (temp2 == 'c') continue;
                else if (temp2 == 'e') break;
                else
                {
                    goto label;
                }
            }
           
            Console.WriteLine("\n");
            BackAdmin();
        }
        void UpdatePost()
        {
            while (true)
            {
                Console.Clear();
                database.ShortInfoPosts();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nEnter Update post Id:");
                text = Console.ReadLine();
                var temp = Convert.ToInt32(text);
                database.UpdatePost(temp);

                label:

                Console.Write("\nContinue (c) Exit (e)->");
                string text2 = Console.ReadLine();
                char temp2 = Convert.ToChar(text2);

                if (temp2 == 'c') continue;
                else if (temp2 == 'e') break;
                else
                {
                    goto label;
                }
            }
            
            Console.WriteLine("\n");
            BackAdmin();
        }

        void BackAdmin()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Back[<--]");
            Console.WriteLine("2.Exit[X]");
            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);
            if (temp == 1)
            {
                Console.Clear();
                Admin();
            }
            else if (temp == 2)
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your choise is incorrect.Try again");
                BackAdmin();
            }
        }

       public void Admin()
       {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("1.Add Post");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("2.Delete Post");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("3.Update Post");
            Console.SetCursorPosition(45, 10);
            Console.WriteLine("4.See All Posts");
            Console.SetCursorPosition(45, 11);
            Console.WriteLine("5.See All Users");
            Console.SetCursorPosition(45, 12);
            Console.WriteLine("6.See Notifications");
            Console.SetCursorPosition(45, 14);
            Console.WriteLine("7.(<--) BACK");

            Console.SetCursorPosition(45, 15);
            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);

            switch (temp)
            {
                case (1):
                    Console.Clear();
                    AddPost();
                    break;
                case (2):
                    Console.Clear();
                    DeletePost();
                    break;
                case (3):
                    Console.Clear();
                    UpdatePost();
                    break;
                case (4):
                    Console.Clear();
                    database.ShowAllPosts();
                    Console.WriteLine("\n");
                    BackAdmin();
                    break;
                case (5):
                    Console.Clear();
                    database.ShowAllUsers();
                    Console.WriteLine("\n");
                    BackAdmin();
                    break;
                case (6):
                    Console.Clear();
                    database.ShowAllNotification();
                    Console.WriteLine("\n");
                    BackAdmin();
                    break;
                case (7):
                    Console.Clear();
                    FirstDisplay();
                    break;
                default:
                    Console.Clear();
                    Console.SetCursorPosition(0, 15);
                    Console.WriteLine("Your choise is incorrect.Try again");
                    Console.SetCursorPosition(0, 0);
                    Admin();
                    break;
            }
       }

        void ViewPosts()
        {
           
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (var post in database.Posts)
                {
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine($"Id->{post.ID}");
                    Console.WriteLine($"Datetime->{post.CreationDateTime.ToShortDateString()}");
                    Console.WriteLine($"Views count->{post.ViewCount}");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("\n");
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter View Post ID:");
                text = Console.ReadLine();
                var temp = Convert.ToInt32(text);

                foreach (var post in database.Posts)
                {
                    if (post.ID == temp)
                    {
                        post.ViewCount += 1;
                        post.ShowPost();
                        Notification notification = new Notification($"View Post:{post.Content}", database.username);
                        database.AddNotification(notification);
                        string text = $"View Post:{post.Content},User->{database.username}";
                        Network network = new Network();
                        network.Mail(database.useremail, database.userpassword, database.Admins[0].Email, text);
                        break;
                    }
                }
                label:
                Console.Write("Continue view post(c), Exit(e):");
                text = Console.ReadLine();
                char temp2 = Convert.ToChar(text);
                if (temp2 == 'c') continue;
                else if (temp2 == 'e') break;
                else goto label;
            }
            BackUser();
        }

        void LikePosts()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                foreach (var post in database.Posts)
                {
                    post.ShowPost();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nEnter Like Post ID:");
                text = Console.ReadLine();
                var temp = Convert.ToInt32(text);

                foreach (var post in database.Posts)
                {
                    if (post.ID == temp)
                    {
                        post.ViewCount += 1;
                        post.LikeCount += 1;
                        Notification notification = new Notification($"Like Post:{post.Content}", database.username);
                        database.AddNotification(notification);
                        string text = $"Like Post:{post.Content},User->{database.username}";
                        Network network = new Network();
                        network.Mail(database.useremail, database.userpassword, database.Admins[0].Email, text);
                        break;
                    }
                }
                label:
                Console.Write("Continue like post(c), Exit(e):");
                text = Console.ReadLine();
                char temp2 = Convert.ToChar(text);
                if (temp2 == 'c') continue;
                else if (temp2 == 'e') break;
                else goto label;
            }

            BackUser();
        }

        void BackUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Back[<--]");
            Console.WriteLine("2.Exit[X]");
            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);
            if (temp == 1)
            {
                Console.Clear();
                User();
            }
            else if (temp == 2)
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your choise is incorrect.Try again");
                BackUser();
            }
        }

        void User()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("1.View Posts");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("2.Like Posts");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("3.Back(<--)");

            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);

            switch (temp)
            {
                case (1):
                    Console.Clear();
                    ViewPosts();
                    break;
                case (2):
                    LikePosts();
                    break;
                case (3):
                    Console.Clear();
                    FirstDisplay();
                    break;

                default:
                    Console.Clear();
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("Your choise is incorrect.Try again");
                    Console.SetCursorPosition(0, 0);
                    User();
                    break;
            }
        }

        void SignUp()
        {
            database.SignUp();
        }

        void SignIN()
        {
            database.SignIn();
            Console.Clear();
            User();
        }

        void BackFistDisplay()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1.Back[<--]");
            Console.WriteLine("2.Exit[X]");
            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);
            if (temp == 1)
            {
                Console.Clear();
                FirstDisplay();
            }
            if (temp == 2)
            {
                System.Environment.Exit(1);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Your choise is incorrect.Try again"); 
                BackFistDisplay();
            }
        }

       void FirstDisplay()
       {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("1.Admin");
            Console.SetCursorPosition(45, 8);
            Console.WriteLine("2.Sign UP");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("3.Sign IN");

            Console.SetCursorPosition(45, 13);
            Console.Write("\nEnter:");
            text = Console.ReadLine();
            var temp = Convert.ToInt32(text);

            if (temp == 1)
            {
                Console.Clear();
                database.AdminSignIN();
                Console.Clear();
                Admin();
            }
            else if (temp == 2)
            {
                Console.Clear();
                SignUp();
                BackFistDisplay();
            }
            else if (temp == 3)
            {
                Console.Clear();
                SignIN();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0, 13);
                Console.WriteLine("Your choise is incorrect.Try again");
                Console.SetCursorPosition(0, 0);
                FirstDisplay();
            }
       }

       public  void Start()
       {
            
            Post post1 = new Post( "World News");
            Post post2 = new Post("Sport News");

            Post[] Posts = new Post[2]
            {
                post1,post2
            };

            User user1 = new User("Anar", "Aliyev", 25, "anar25@gmail.com", "78001a");
            User[] Users = new User[1]
            {
                user1
            };

            Admin admin1 = new Admin("admin", "nbilinbi7@gmail.com", "nebili2002");
            Admin[] admins = new Admin[1]
            {
                admin1
            };


            database = new Database { Posts = Posts, Users = Users, Admins = admins};
            FirstDisplay();
            //database.ShowAllUsers();
            // database.AddPost();
            //database.ShowAllNotification();
       }
        
    }
}
