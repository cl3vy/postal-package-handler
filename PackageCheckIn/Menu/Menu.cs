using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PackageCheckIn.Classes;
using PackageCheckIn;
using System.Threading.Tasks;

namespace PackageCheckIn.Menu
{
    public static class Menu
    {

        public static void PrintMainMenu()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Type 'A' to act as User");
            Console.WriteLine("Type 'B' to act as Admin");
            Console.WriteLine("Type 'EXIT' to exit the app");
        }

        public static void PrintUserMenu()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Type 'A' to change a package name");
            Console.WriteLine("Type 'B' to change a package adress");
            Console.WriteLine("Type 'C' to add a new package to a user");
            Console.WriteLine("Type 'M' to go back to main menu");
        }

        public static void PrintAdminMenu()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Type 'A' to Add a new user");
            Console.WriteLine("Type 'B' to See a users packages");
            Console.WriteLine("Type 'C' to Send a package");
            Console.WriteLine("Type 'D' to See all packages");
            Console.WriteLine("Type 'E' to delete all packages");
            Console.WriteLine("Type 'G' to see all users");
            Console.WriteLine("Type 'M' to go back to main menu");
        }

        public static void ExecuteMainOption(string option)
        {
            option = option.ToUpper().Trim();
            switch (option)
            {
                case "A":
                    PrintUserMenu();
                    break;
                case "B":
                    PrintAdminMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        public static void ExcecuteUserOption(string option)
        {
            option = option.ToUpper().Trim();
            switch (option)
            {
                case "A":
                    ExcecuteUserA();
                    break;
                case "B":
                    ExcecuteUserB();
                    break;
                case "C":
                    ExcecuteUserC();
                    break;
                case "M":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }     
        }
        public static void ExcecuteAdminOption(string option)
        {
            option = option.ToUpper().Trim();
            switch (option)
            {
                case "A":
                    ExcecuteAdminA();
                    break;
                case "B":
                    ExcecuteAdminB();
                    break;
                case "C":
                    ExcecuteAdminC();
                    break;
                case "D":
                    ExcecuteAdminD();
                    break;
                case "E":
                    ExcecuteAdminE();
                    break;
                case "G":
                    ExcecuteAdminG();
                    break;
                case "M":
                    PrintMainMenu();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;

            }
        }
        public static User GetUser()
        {
            Console.WriteLine("Enter your Username");
            var userName = Console.ReadLine();
            User user;
            if (Admin.users.Find(User => User.Name == userName) != default)
            {
                user = Admin.users.Find(User => User.Name == userName);
                return user;
            }
            throw new Exception("That user could not be found");
        }

        //USER METHODS
        public static void ExcecuteUserA()
        {
            //Method to get user
            var user = GetUser();
            
            Console.WriteLine("Write the name of package you want to change");
            var oldName = Console.ReadLine();
            Console.WriteLine("Write the new name of this package");
            var newName = Console.ReadLine();
            user.ChangePackageName(oldName, newName);
            Console.WriteLine("Name of package was changed succesfuly");
        }

        public static void ExcecuteUserB()
        {
            //Method to get user
            var user = GetUser();

            Console.WriteLine("Write the name of package you want to change adress");
            var name = Console.ReadLine();
            Console.WriteLine("Write the new adress you want to modify to it");
            var adress = Console.ReadLine();
            user.ChangePackageAdress(name, adress);
        }

        public static void ExcecuteUserC()
        {
            //Method to get user
            var user = GetUser();

            Console.WriteLine("Enter a name for your package");
            var packageName = Console.ReadLine();
            Console.WriteLine("Enter an adress for your package");
            var packageAdress = Console.ReadLine();
            Console.WriteLine("Enter the wheight of your package");
            double packageWeight = Convert.ToDouble(Console.ReadLine());
            user.AddPackage(user, packageName, packageAdress, packageWeight);
            Console.WriteLine("****Your package is added****");
        }


        //ADMIN METHODS
        public static void ExcecuteAdminA()
        {
            Console.WriteLine("Enter a name for your user");
            var name = Console.ReadLine();
            Console.WriteLine("Enter a surname for your user");
            var surname = Console.ReadLine();
            Console.WriteLine("Enter an email for your user");
            var email = Console.ReadLine();
            Admin.CreateUser(name, surname, email);
        }

        public static void ExcecuteAdminB()
        {
            Console.WriteLine("Enter users name");
            var name = Console.ReadLine();
            Admin.SeeUsersPackages(name);
        }

        public static void ExcecuteAdminC()
        {
            Console.WriteLine("Write the name of the packages you want to send");
            var name = Console.ReadLine();
            Admin.SendPackage(name);
        }
        public static void ExcecuteAdminD()
        {
            Admin.SeeAllPackages();
        }
        public static void ExcecuteAdminE()
        {
            Admin.DeleteAllPackages();
        }
        public static void ExcecuteAdminG()
        {
            if (Admin.users.Count > 0)
            {
                foreach (User user in Admin.users)
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine(user.Name);
                    Console.WriteLine(user.Surname);
                    Console.WriteLine(user.Email);
                }
            }
            else Console.WriteLine("There are no registered users");
        }
    }
}
