using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Lion : Felidae
    {
        public override void Voice()
        {
            Console.WriteLine("Roar. Roar. Roar!");
        }
    }
}
