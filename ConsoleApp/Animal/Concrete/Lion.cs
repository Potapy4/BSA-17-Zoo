using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Lion : Felidae
    {
        public Lion(string Name) : base(Name)
        {
            this.HP = 5;
        }

        public override void Voice()
        {
            Console.WriteLine("Roar. Roar. Roar!");
        }
    }
}
