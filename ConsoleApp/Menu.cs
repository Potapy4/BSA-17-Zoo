using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Menu
    {
        Zoo.Zoo zoo;

        public Menu()
        {
            zoo = new Zoo.Zoo();
        }

        public void WaitUserCommand()
        {
            while (!zoo.isAllDead)
            {
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine();

                if (!zoo.isAllDead) // Additional check when we type smth
                {
                    ParseCommand(command);
                }
            }

            LogColoredMessage("All animals in zoo is died.", true);           
        }

        private void ParseCommand(string command)
        {
            string[] args = command.Split(' ');           

            switch (args[0])
            {
                case "HELP":
                case "help":
                    HelpCommand();
                    break;
                case "add":
                case "ADD":
                    Add(args);
                    break;
                case "FEED":
                case "feed":
                    Feed(args);
                    break;
                case "HEAL":
                case "heal":
                    Heal(args);
                    break;
                case "REMOVE":
                case "remove":
                    Remove(args);
                    break;
                default:
                    LogColoredMessage("Command not found!", true);
                    break;
            }
        }

        private void HelpCommand()
        {
            Console.WriteLine("Usage: <command> <params>");
            Console.WriteLine("add/ADD AnimalName AnimalType: add myLion LION");
            Console.WriteLine("*Animal types: LION | TIGER | BEAR | WOLF | FOX | ELEPHANT");
            Console.WriteLine("feed/FEED AnimalName: feed myLion");
            Console.WriteLine("heal/HEAL AnimalName: heal myLion");
            Console.WriteLine("remove/REMOVE AnimalName: remove myLion");
            Console.WriteLine("P.S - commands case sensitivity");

        }

        private void LogColoredMessage(string msg, bool isError = false)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void Add(string[] args)
        {
            if(args.Length != 3)
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                zoo.AddAnimal(args[1], args[2]);
                LogColoredMessage("Animal was successfully added.");
            }
            catch(Exceptions.AnimalAlreadyExistsException)
            {
                LogColoredMessage("Name must be unique! Already have animal with same name.", true);
            }
            catch (Exceptions.AnimalInvalidTypeException)
            {
                LogColoredMessage("Invalid type of animal! User help command for details.", true);
            }
            catch (Exception ex)
            {
                LogColoredMessage("Ooops, something was wrong: " + ex.Message, true);
            }
        }

        private void Feed(string[] args)
        {
            if (args.Length != 2)
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                zoo.FeedAnimal(args[1]);
                LogColoredMessage("Animal was successfully fed.");
            }
            catch (Exceptions.AnimalNotFoundException)
            {
                LogColoredMessage("Animal not found.", true);
            }
            catch (Exception ex)
            {
                LogColoredMessage("Ooops, something was wrong: " + ex.Message, true);
            }

        }

        private void Heal(string[] args)
        {
            if (args.Length != 2)
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                zoo.HealAnimal(args[1]);
                LogColoredMessage("Animal was successfully cured.");
            }
            catch (Exceptions.AnimalNotFoundException)
            {
                LogColoredMessage("Animal not found.", true);
            }
            catch (Exception ex)
            {
                LogColoredMessage("Ooops, something was wrong: " + ex.Message, true);
            }
        }

        private void Remove(string[] args)
        {
            if (args.Length != 2)
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                bool result = zoo.RemoveAnimal(args[1]);
                if (result)
                {
                    LogColoredMessage("Animal was successfully removed.");
                }
            }
            catch (Exceptions.AnimalNotFoundException)
            {
                LogColoredMessage("Animal not found.", true);
            }
            catch (Exception ex)
            {
                LogColoredMessage("Ooops, something was wrong: " + ex.Message, true);
            }
        }
    }
}
