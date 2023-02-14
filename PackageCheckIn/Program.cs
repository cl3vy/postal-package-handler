using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PackageCheckIn.Menu;
using PackageCheckIn.Classes;

namespace PackageCheckIn
{
    public class Program
    {
        public static void Main()
        {
            Menu.Menu.PrintMainMenu();
            var option = Console.ReadLine();

            while (option.ToUpper().Trim() != "EXIT")
            {
                Menu.Menu.ExecuteMainOption(option);
                if (option.ToUpper().Trim() == "A")
                {
                    while (option.ToUpper().Trim() != "M")
                    {
                        option = Console.ReadLine();
                        if (option.ToUpper().Trim() == "M") break;
                        Menu.Menu.ExcecuteUserOption(option);
                        Menu.Menu.PrintUserMenu();
                    }
                        Menu.Menu.PrintMainMenu();
                        option = Console.ReadLine();
                }
                else if (option.ToUpper().Trim() == "B")
                {
                    while (option.ToUpper().Trim() != "M")
                    {
                        option = Console.ReadLine();
                        if (option.ToUpper().Trim() == "M") break;
                        Menu.Menu.ExcecuteAdminOption(option);
                        Menu.Menu.PrintAdminMenu();
                    }
                        Menu.Menu.PrintMainMenu();
                        option = Console.ReadLine();
                }
            }
        }
    }
}
