using System;

namespace ConsoleApp
{
    class Menu
    {
        private static readonly Lazy<Menu> lazy = new Lazy<Menu>(() => new Menu());
        private Zoo.Zoo zoo;
        private Zoo.ZooSelector selector;

        public static Menu Instance { get { return lazy.Value; } }

        private Menu()
        {
            zoo = new Zoo.Zoo();
            selector = new Zoo.ZooSelector(zoo.GetAnimals());
        }

        public void WaitUserCommand()
        {
            while (/*!zoo.watcher.isAllDead*/ true)
            {
                Console.WriteLine("Enter a command: ");
                string command = Console.ReadLine();

                //if (!zoo.watcher.isAllDead) // Additional check when we type smth
                {
                    ParseCommand(command);
                }
            }

           // LogColoredMessage("All animals in the zoo are dead.", true);
        }

        private void ParseCommand(string command)
        {
            string[] args = command.Split(' ');

            switch (args[0].ToLower())
            {
                case "help":
                    HelpCommand();
                    break;
                case "add":
                    Add(args);
                    break;
                case "feed":
                    Feed(args);
                    break;
                case "heal":
                    Heal(args);
                    break;
                case "remove":
                    Remove(args);
                    break;
                case "list":
                    List();
                    break;
                case "info":
                    Info(args);
                    break;
                case "linq":
                    Linq(args);
                    break;
                default:
                    LogColoredMessage("Command not found!", true);
                    break;
            }
        }

        private void HelpCommand()
        {
            Console.Write("\nUsage:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" <command>");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" <params>\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Commands:");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("add <Animal Name> <Animal Type>");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("feed <Animal Name>");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("heal <Animal Name>");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("remove <Animal Name>");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("info <Animal Name>");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("list\n");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*Animal types: lion | tiger | fox | wolf | elephant | bear\n");

            Console.ResetColor();
        }

        private void LogColoredMessage(string msg, bool isError = false)
        {
            Console.ForegroundColor = isError ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void Add(string[] args)
        {
            if (args.Length != 3 || args[1] == "")
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                zoo.AddAnimal(args[1], args[2]);
                LogColoredMessage("Animal was successfully added.");
            }
            catch (Exceptions.AnimalAlreadyExistsException)
            {
                LogColoredMessage("Name must be unique! Already have animal with same name.", true);
            }
            catch (Exceptions.AnimalInvalidTypeException)
            {
                LogColoredMessage("Invalid type of animal! Use help command for details.", true);
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
            catch (Exceptions.AnimalDeadException ex)
            {
                LogColoredMessage(ex.Message, true);
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
            catch (Exceptions.AnimalDeadException ex)
            {
                LogColoredMessage(ex.Message, true);
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

        private void List()
        {
            var ls = zoo.GetAnimals();

            if (ls.Count == 0)
            {
                LogColoredMessage("No animals in zoo.", true);
                return;
            }

            Console.WriteLine("Name: \t HP: \t State:");
            foreach (var animal in ls)
            {
                Console.WriteLine("{0} \t {1} \t {2}", animal.Name, animal.HP, animal.State);
            }
        }

        private void Info(string[] args)
        {
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }

            try
            {
                var animal = zoo.GetAnimalByName(args[1]);

                LogColoredMessage("Animal info:");
                Console.WriteLine("Name: {0} | HP: {1} | State: {2}", animal.Name, animal.HP, animal.State);
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

        private void Linq(string[] args)
        {
            /*
            if (args.Length != 2 || string.IsNullOrWhiteSpace(args[1]))
            {
                LogColoredMessage("Invalid args for command. Use help for details.", true);
                return;
            }*/

            int command = 0;
            Int32.TryParse(args[1], out command);

            switch (command)
            {
                case 1:
                    selector.AnimalsByType(args[2]);
                    break;
                case 2:
                    selector.AnimalsByState(args[2]);
                    break;
                case 3:
                    selector.SickTigers();
                    break;
                case 4:
                    selector.ElephantByName(args[2]);
                    break;
                case 5:
                    selector.AllHungryAnimals();
                    break;
                case 6:
                    selector.FirstWellFedByGroup();
                    break;
                case 7:
                    selector.DeadAnimalsByType();
                    break;
                case 8:
                    selector.BearsAndWolfsByHP();
                    break;
                case 9:
                    selector.MaxAndMinHP();
                    break;
                case 10:
                    selector.AvgHP();
                    break;
                default:
                    LogColoredMessage("Command not found!", true);
                    break;
            }
        }
    }
}
