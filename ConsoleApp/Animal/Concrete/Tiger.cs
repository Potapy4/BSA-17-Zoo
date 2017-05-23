using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Tiger : Felidae
    {
        public override void Voice()
        {
            Console.WriteLine("Moar. Moar. Moar!");
        }
    }
}
