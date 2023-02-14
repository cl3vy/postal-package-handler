using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;
using PackageCheckIn.Classes;

namespace PackageCheckIn.Classes
{
    public class User : Person
    {
        protected string guid;
        public User(string name, string surname, string email)
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            guid = Guid.NewGuid().ToString();
        }

        public List<Package> packages = new List<Package>();
        public string GUID
        {
            get
            {
                return guid;
            }
        }

        //Method that adds a package to the users list of packages
        public void AddPackage(User user, string packageName, string adress, double wheight)
        {
            Package package = new Package(user.Name, packageName, adress, wheight);
            packages.Add(package);
            Admin.allPackages.Add(package);
        }

        //Method that changes a packages name in the list
        public void ChangePackageName(string currentName, string newName)
        {
            //Check if the package is in the list
            if (packages.Find(Package => Package.PackageName == currentName) != default)
            {
                //Create a variable that holds the object with that name
                var package = packages.Find(Package => Package.PackageName == currentName);
                //Change the name of the object with the new name given
                package.PackageName = newName;
                Console.WriteLine($"Package: {currentName} was changed to {newName}");
            }
            //In the case that the package was not found
            else
            {
                Console.WriteLine("Package with that name has not been found please check if you typed correctly");
            }
        }


        //Method that changes adress of a package in the list
        public void ChangePackageAdress(string packageName, string newAdress)
        {
            //Check if the package is in the list
            if (packages.Find(Package => Package.PackageName == packageName) != default)
            {
                //Create a variable that holds the object with that name
                var package = packages.Find(Package => Package.PackageName == packageName);
                //Change the adress with the new adress given
                package.Adress = newAdress;
                Console.WriteLine($"Package: {package.PackageName} has the new adress of {package.Adress}");
            }
            //In the case that the package was not found
            else
            {
                Console.WriteLine("Package with that name has not been found please check if you typed correctly");
            }
        }
    }
}
