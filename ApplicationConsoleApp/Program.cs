using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLibrary;

namespace ApplicationConsoleApp
{
    class Program
    {
        private static Application application;
        private static Board board;

        public static void DisplayMenu()
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine();
            Console.WriteLine("1: Create new account");
            Console.WriteLine("2: Update account");
            Console.WriteLine("3: Delete account");
            Console.WriteLine("4: Display user by ID");
            Console.WriteLine("5: Display all users");
            Console.WriteLine("6: Log in ");
        }


        private static void DisplayUser(User user)
        {
            Console.WriteLine("{0} {1} (id={2}) - {3}",
                user.FirstName, user.LastName, user.Id, user.BirthDate);
        }

        private static void DisplayAllUsers()
        {
            Console.WriteLine("All users:");
            foreach (User user in application.GetUsers())
            {
                DisplayUser(user);
            }
        }

        private static User ReadUser()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter year of birth (yyyy): ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter month of birth (1-12): ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter day of birth (1-31): ");
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter email address: ");
            string email = Console.ReadLine();

            return application.AddUser(firstName, lastName, new DateTime(year, month, day), email);
        }

        private static void DeleteUserById()
        {
            Console.Write("Delete user by id: ");
            int id = int.Parse(Console.ReadLine());
            bool wasUserDeleted = application.DeleteUserById(id);
            if (wasUserDeleted)
            {
                Console.WriteLine("User was deleted");
            }
            else
            {
                Console.WriteLine("No user with that id");
            }
        }

        private static void SearchUserById()
        {
            Console.Write("Search user by id: ");
            int id = int.Parse(Console.ReadLine());
            User foundUser = application.GetUserById(id);
            if (foundUser != null)
            {
                DisplayUser(foundUser);
            }
            else
            {
                Console.WriteLine("No user with that id");
            }
        }



        static void Main(string[] args)
        {
            application = new Application(new UsersService());
            board = new Board();

            while (true)
            {
                DisplayMenu();

                Console.Write("Your option is: ");
                int option = 0;
                int.TryParse(Console.ReadLine(), out option);

                Console.WriteLine();

                switch (option)
                {
                    case 1:
                        ReadUser();
                        break;
                    case 2:
                        UpdateUserById();
                        break;
                    case 3:
                        DeleteUserById();
                        break;
                    case 4:
                        SearchUserById();
                        break;
                    case 5:
                        DisplayAllUsers();
                        break;
                    case 6:
                        Login();
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again!");
                        break;
                }



                Console.WriteLine();
            }
        }

        private static void UpdateUserById()
        {
            Console.Write("Update user by id: ");
            int id = int.Parse(Console.ReadLine());

            User foundUser = application.GetUserById(id);
            if (foundUser != null)
            {
                Console.Write("Enter new first name: ");
                string newFirstName = Console.ReadLine();

                Console.Write("Enter new last name: ");
                string newLastName = Console.ReadLine();

                bool wasUserUpdated = application.UpdateUser(id, newFirstName, newLastName);
                if (wasUserUpdated)
                {
                    Console.WriteLine("User was updated");
                }
                else
                {
                    Console.WriteLine("User could not be updated");
                }
            }
            else
            {
                Console.WriteLine("No user with that id");
            }
        }





        private static void Login()
        {

            Console.WriteLine("Enter your ID ");
            int id = int.Parse(Console.ReadLine());
            User foundUser = application.GetUserById(id);
            if (foundUser == null)
            {
                Console.WriteLine("No user with that id");
                return;
            }

            void PostMessage()
            {
                Console.WriteLine("Post your message ");
                string message = Console.ReadLine();
                board.AddPost(message, id);
                Console.WriteLine(foundUser + ": " + message);
            }

            void DisplayPosts()
            {
                var posts = board.GetPosts();
                foreach (var post in posts)
                {
                    Console.WriteLine("Post: " + post.Message + "; by user id - " + post.UserId);
                }
            }

            while (true)
            {

                Console.WriteLine("Choose option:");
                Console.WriteLine();
                Console.WriteLine("1: Post a message");
                Console.WriteLine("2: Show posts");
                Console.WriteLine("3: Exit this menu");

                int option = 0;
                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {

                    case 1:
                        PostMessage();
                        break;
                    case 2:
                        DisplayPosts();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }

            }

        }


    }


}
