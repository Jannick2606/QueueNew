using System;
using System.Threading;
using System.Media;

namespace QueueNew
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuTitel = "Menu\n";
            string[] menuOptions = new string[] 
            {   "Add items", 
                "Delete items", 
                "Show the number of items",
                "Show min and max items",
                "Find an item",
                "Print all items",
                "Exit"
            };
            Menu m = new Menu(menuTitel, menuOptions);
            m.MenuInput();
        }
    }
}
