using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Wolf : Canidae
    {
        public Wolf(string Name) : base(Name)
        {
            this.HP = 4;
        }

        public override void Voice()
        {
            Console.WriteLine("Ahwoooooooooo!");
        }
    }
}
