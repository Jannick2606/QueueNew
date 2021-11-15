using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace QueueNew
{
    class Menu
    {
        //Constructor takes the menu title and the options for that menu and saves them in variables that the rest of the menu class can use
        public Menu(string menuTitle, string[] options)
        {
            index = 0;
            this.options = options;
            this.menuTitle = menuTitle;
        }
        //Method for taking user input. It reacts to up and down arrow, enter and esc
        //The cursor is invisible cause it looks weird to have it blinking below the menu
        //It becomes visible again after the for loop cause you might need it later in the program, just not here
        public void MenuInput()
        {
            Console.CursorVisible = false;
            ConsoleKey key;

            //At the start of the loop I set the cursor potition to the top left corner
            //When it calls DisplayMenu it's gonna rewrite every line in the menu
            //At first I used Console.Clear but it would make the menu disappear for a splitsecond and then reappear
            //Rewriting the lines by setting cursor position makes it look a lot smoother
            do
            {
                Console.SetCursorPosition(0, 0);
                DisplayMenu();
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                key = keyInfo.Key;
                if(key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    index--;
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    index++;
                }
                if (index < 0)
                {
                    index = options.Length - 1;
                }
                else if (index >= options.Length)
                {
                    index = 0;
                }
            } while (key != ConsoleKey.Enter);
            Console.CursorVisible = true;
            ChoiceSwitchCase(index);
        }

        //Method for displaying the menu. Console colors change when the user goes down/up a line
        private void DisplayMenu()
        {
            Console.WriteLine(menuTitle);
            for (int i = 0; i < options.Length; i++)
            {
                string prefix;
                string currentOption = options[i];
                if (index == i)
                {
                    prefix = "> ";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    prefix = "  ";
                    Console.ResetColor();
                }
                Console.WriteLine(prefix + currentOption);
            }
            Console.ResetColor();
        }


        //Switch case. It takes the int from MenuInput and displays the submenu that fits that number
        //and also calls the method needed in logic
        private void ChoiceSwitchCase( int choice)
        {
                Console.Clear();
            switch (choice)
            {

                case 0:
                    Console.WriteLine("How many numbers do you want to add?");
                    int amount = int.Parse(Console.ReadLine());
                    if (amount > 0)
                    {
                        Console.WriteLine("Enter the number(s) you want to add to the queue");
                        for (int i = 0; i < amount; i++)
                        {
                            l.Add(int.Parse(Console.ReadLine()));
                        }
                    }
                    break;
                case 1:
                    Console.WriteLine("How many numbers do you want to delete?");
                    amount = int.Parse(Console.ReadLine());
                        for (int i = 0; i < amount; i++)
                        {
                            l.Delete();
                        }
                    break;
                case 2:
                    Console.WriteLine($"Number of items in queue: {l.Amount()}");
                    break;
                case 3:
                    Console.WriteLine($"The biggest number in the queue is: {l.Max()}");
                    Console.WriteLine($"The smallest number in the queue is: {l.Min()}");
                    break;
                case 4:
                    Console.WriteLine("What number are you looking for?");
                    Console.WriteLine(l.Find(int.Parse(Console.ReadLine())));
                    break;
                case 5:
                    if (l.PrintAll().Count == 0)
                        Console.WriteLine("The queue is empty");
                    else
                    {
                        foreach (int index in l.PrintAll())
                            Console.WriteLine(index);
                    }
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid entry");
                    break;
            }
            Console.WriteLine("Do you want to go back to the menu?");
            string backToMenu = Console.ReadLine().ToLower();
            if (backToMenu.Contains("y"))
            {
                Console.Clear();
                MenuInput();
            }
        }
       
        private int index;
        private string[] options;
        private string menuTitle;
        private Logic l = new Logic();
    }
}