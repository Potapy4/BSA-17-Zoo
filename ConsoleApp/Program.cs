using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            AnimalAbstract.Animal animal = new AnimalConcrete.Elephant("Вася");
            animal.Voice();
            Console.WriteLine(animal.Name);
            Console.WriteLine(animal.HP);
        }
    }
}
