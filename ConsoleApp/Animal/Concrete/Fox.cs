using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Fox : Canidae
    {
        public override void Voice()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
