using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Elephant : Proboscidea
    {
        public override void Voice()
        {
            Console.WriteLine("Pawoo. Pawoo. Pawoo!");
        }
    }
}
