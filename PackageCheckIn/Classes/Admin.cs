using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageCheckIn.Classes;

namespace PackageCheckIn.Classes
{
    public static class Admin
    {

        public static List<User> users = new List<User>();
        public static List<Package> allPackages = new List<Package>();

        public static void CreateUser(string name, string surname, string email)
        {
            var user = new User(name, surname, email);
            users.Add(user);
        }

        //Method that outputs all packages of all users
        public static void SeeAllPackages()
        {
            //Check if the list of all packages is not empty
            if (AllPackages().Count != 0)
            {
                //Iterating through every package
                foreach (Package package in AllPackages())
                {
                    Console.WriteLine("********************");
                    Console.WriteLine($"Package Name: {package.PackageName} \nPackage Sender:{package.Sender} \nPackage Adress:{package.Adress} \nPackage GUID: {package.GUID} \nPackge Weight: {package.Weight}");
                }
            }
            //In the case that the list of all packages is empty
            else Console.WriteLine("There are no packages");

        }

        //Output the names of all packages of a user
        public static void SeeUsersPackages(string name)
        {
            //Check if a user is in the users list by the users name
            if (users.Find(User => User.Name == name) != default)
            {
                //Create a variable that holds the user with that name
                var user = FindUser(name);
                //Check that the packages list of this user is not empty
                if (user.packages.Count != 0)
                {
                    //Iterate through the list and output the names
                    foreach (var package in user.packages)
                    {
                        Console.WriteLine($"Package Name: {package.PackageName} \nPackage Sender:{package.Sender} \nPackage Adress:{package.Adress} \nPackage GUID: {package.GUID} \nPackge Weight: {package.Weight}");
                    }
                }
                //In the case that the list of packages is empty
                else
                {
                    Console.WriteLine("The user with that name has no packages");
                }
            }
            //In the case that the user with that is not found
            else
            {
                Console.WriteLine("User with that name was not found, check for inacuriecies in your typing");
            }
        }

        public static void SendPackage(string name)
        {
            //Bool that keeps track if we found a package with the name given
            bool check = false;
            //Iterate through each user
            foreach (User user in users)
            {
                //Iterate through each package of each user
                for(int i = 0; i < user.packages.Count; i++)
                {
                    if (user.packages[i].PackageName == name)
                    {
                        //Remove package from the users list of packages
                        user.packages.Remove(user.packages[i]);
                        //Turn the bool true because we found the package with that name
                        check = true;
                    }
                }
            }
            //This removes the package from the list with all the packages 
            for(int i = 0; i < allPackages.Count; i++)
            {
                if (allPackages[i].PackageName == name)
                {
                    allPackages.Remove(allPackages[i]);
                    //Turn the bool true because we found the package with that name
                    check = true;
                }
            }
            //If the check is false it means package was not found
            if (check == false)
            {
                Console.WriteLine("That package was not found");
            }
            //In the case that it is found
            else Console.WriteLine($"We sent packages found with that name");
        }

        public static List<Package> AllPackages()
        {
            List<Package> packages = new List<Package>();
            //Iterate through each user in users
            foreach (User user in users)
            {
                //Iterate through each package in packages
                foreach (Package package in user.packages)
                {
                    //Adds current package iteration to the list packages
                    packages.Add(package);
                }
            }
            //Returns the list with all the packages
            return packages;
        }

        public static User FindUser(string name)
        {
            return users.Find(User => User.Name == name);
        }

        public static void DeleteAllPackages()
        {
            int counter = 0;
            //Iterate through each user in isers
            foreach (User user in users)
            {
                //Iterate through each package of each user
                for (int i = 0; i < user.packages.Count; i++)
                {
                    //Remove package from the users list of packages
                    user.packages.Remove(user.packages[i]);
                    counter++;
                }
            }
            //Iterate through each package in allPackages
            for (int i = 0; i < allPackages.Count; i++)
            {
                //Remove every package
                allPackages.Remove(allPackages[i]);
                counter++;
            }
            if (counter == 0)
            {
                Console.WriteLine("There are no packages to delete");
            }
            else Console.WriteLine("All the packages got deleted");
        }
    }
}
