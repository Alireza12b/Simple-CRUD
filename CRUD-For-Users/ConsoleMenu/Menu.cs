using CRUD_For_Users.Exceptions;
using CRUD_For_Users.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the new user full name :" +
                    "\n0-Return to MainMenu");
                string fullName = Console.ReadLine();

                Console.WriteLine("Enter the user phone number :");
                bool isValidPhone = long.TryParse(Console.ReadLine(), out long phone);
                if (phone.ToString().Count() > 11 || phone.ToString().Count() < 11 || !isValidPhone)
                {
                    throw new PhoneNumberNotValid("PLease Enter valid Phone Number");
                }

                Console.WriteLine("Enter the user Birth Date");

                bool isValidBirthDate = DateTime.TryParse(Console.ReadLine(), out DateTime birthDate);
                if (birthDate >= DateTime.Now || !isValidBirthDate)
                {
                    throw new BirthDateNotValid("Please enter valid date time in corrent format");
                }

                userServices.CreateUser(fullName, phone, birthDate);

                Console.Clear();
                Console.WriteLine("User added successfuly ! press any key to continue");
                Console.ReadKey();
                Console.Clear();
                MainMenu();
            }
            catch (BirthDateNotValid e)
            {
                Console.Clear();
                Console.WriteLine(e + "\npress any key to continue !");
                Console.ReadKey();
                Console.Clear();
                AddMenu();
            }
            catch (PhoneNumberNotValid ex)
            {
                Console.Clear();
                Console.WriteLine(ex + "\npress any key to continue !");
                Console.ReadKey();
                Console.Clear();
                AddMenu();
            }
        }

        void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("Enter the ID of a user that you want to change :" +
                "\n0-Return to MainMenu");

            var list = userServices.ReadUser();
            foreach (var user in list)
            {
                Console.WriteLine($"ID = {user.Id} | Name = {user.FullName} | Phone = {user.Phone} | BirthDate = {user.DateOfBirth.ToString("yyyy-MM-dd")} | UserCreationTime = {user.UserCreationDate}");
            }

            bool isValidIdSelection = int.TryParse(Console.ReadLine(), out int idSelection);
            if (idSelection == 0)
            {
                Console.Clear();
                MainMenu();
            }

            if (isValidIdSelection)
            {
                Console.WriteLine("What do you want to do with this ID ?" +
                    "\n1-Update" +
                    "\n2-Delete");
                int.TryParse(Console.ReadLine(), out int idManagementSelection);

                if (idManagementSelection == 1)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new Name of the user");
                        string newName = Console.ReadLine();

                        Console.WriteLine("Enter new Phone Number of the user");
                        string sNewPhone = Console.ReadLine();
                        bool isValidNewPhone = long.TryParse(sNewPhone, out long newPhone);
                        if (newPhone.ToString().Count() > 11 || newPhone.ToString().Count() < 11 || !isValidNewPhone)
                        {
                            throw new PhoneNumberNotValid("PLease Enter valid Phone Number");
                        }

                        Console.WriteLine("Enter new BirthDate of the user");
                        bool isValidNewBirthDate = DateTime.TryParse(Console.ReadLine(), out DateTime newBirthDate);
                        if (newBirthDate >= DateTime.Now || !isValidNewBirthDate)
                        {
                            throw new BirthDateNotValid("Please enter valid date time in corrent format");
                        }

                        userServices.UpdateUser(idSelection, newName, newPhone, newBirthDate);
                        Console.WriteLine("User updated Successfuly !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                    catch (UserNotFoundException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e + "\npress any key to continue !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                    catch (BirthDateNotValid e)
                    {
                        Console.Clear();
                        Console.WriteLine(e + "\npress any key to continue !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                    catch (PhoneNumberNotValid e)
                    {
                        Console.Clear();
                        Console.WriteLine(e + "\npress any key to continue !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                }
                else if (idManagementSelection == 2)
                {
                    try
                    {
                        userServices.DeleteUser(idSelection);
                        Console.WriteLine("User deleted Successfuly !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                    catch (UserNotFoundException e)
                    {
                        Console.Clear();
                        Console.WriteLine(e + "\npress any key to continue !");
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Please enter menu item ! press any key to continue");
                    Console.ReadKey();
                    Console.Clear();
                    ListMenu();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter valid id ! press any key to continue");
                Console.ReadKey();
                Console.Clear();
                ListMenu();
            }
        }

    }
}
