using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Bear : Ursidae
    {
        public override void Voice()
        {
            Console.WriteLine("Growl. Growl. Growl!");
        }
    }
}
