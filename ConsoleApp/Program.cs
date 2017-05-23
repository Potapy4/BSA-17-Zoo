using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            /*
            Zoo.Zoo zoo = new Zoo.Zoo();
            zoo.AddAnimal("Vasya", "Lion");
            zoo.AddAnimal("Alex", "Tiger");
            zoo.AddAnimal("Nik", "Lion");


            while (!zoo.isAllDead())
            {
               
            }

            Console.WriteLine("All dead");
            Console.ReadKey();*/

            Menu menu = Menu.GetInstance();
            menu.WaitUserCommand();


        }
    }
}
