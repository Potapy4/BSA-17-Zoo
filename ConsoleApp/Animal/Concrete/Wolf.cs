using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Wolf : Canidae
    {
        public override void Voice()
        {
            Console.WriteLine("Ahwoooooooooo!");
        }
    }
}
