using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageCheckIn.Classes;
using PackageCheckIn;

namespace PackageCheckIn.Classes
{
    public class Package
    {
        private string sender;
        private string packageName;
        private string adress;
        protected string guid;
        private double weight;
        protected DateTime dateAdded;

        public Package(string sender, string packageName, string adress, double weight)
        {
            this.sender = sender;
            this.packageName = packageName;
            this.adress = adress;
            guid = Guid.NewGuid().ToString();
            this.weight = weight;
            dateAdded = DateTime.Now;
        }

        public string Sender 
        { 
            get 
            { 
                return sender; 
            } 
            set 
            { 
                sender = value;
            } 
        }
        public string PackageName 
        { 
            get 
            { 
                return packageName; 
            } 
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    packageName = value;
                }
                else
                {
                    Console.WriteLine("Package name must not be null");
                }
            } 
        }
        public string Adress 
        { 
            get 
            { 
                return adress; 
            } 
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    adress = value;
                }
                else
                {
                    Console.WriteLine("Adress must not be null");
                }
            } 
        }
        public string GUID 
        { 
            get 
            { 
                return guid; 
            } 
        }
        public double Weight 
        { 
            get 
            { 
                return weight; 
            } 
            set 
            {
                if (!(weight > 50))
                {
                    weight = value;
                }
                else
                {
                    Console.WriteLine("Package can't be heavier than 50kg");
                }
            } 
        }
        public DateTime DateAdded 
        { 
            get 
            { 
                return dateAdded; 
            } 
        }
    }
}
