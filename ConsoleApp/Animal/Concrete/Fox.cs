using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Fox : Canidae
    {
        public Fox(string Name) : base(Name)
        {
            this.HP = 3;
        }

        public override void Voice()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
