using CRUD_For_Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_For_Users.ConsoleMenu
{
    public class Menu
    {
        IUserServices userServices = new UserServices();

        public void MainMenu()
        {
            Console.WriteLine("Welcome !" +
                "\nwhat do you want to do ?" +
                "\n1-Add a User" +
                "\n2-Show List of Users");

            int.TryParse(Console.ReadLine(), out int mainMenuSelection);
            if (mainMenuSelection == 1)
            {
                AddMenu();
            }
            else if (mainMenuSelection == 2)
            {
                ListMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid selection . Please enter only number of menu item that you want !");
                MainMenu();
            }
        }

        void AddMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the new user full name : " +
                "\n 0-Return to MainMenu");
            string fullName = Console.ReadLine();

            Console.WriteLine("Enter the user phone number :");
            int.TryParse(Console.ReadLine(), out int phone);

            Console.WriteLine("Enter the user Birth Date");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            userServices.CreateUser(fullName, phone, birthDate);

            Console.Clear() ;
            Console.WriteLine("User added successfuly ! press any key to continue");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }

        void ListMenu()
        {

        }
    }
}
