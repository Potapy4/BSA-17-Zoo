using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Elephant : Proboscidea
    {
        public Elephant(string Name) : base(Name)
        {
            this.HP = 7;
        }

        public override void Voice()
        {
            Console.WriteLine("Pawoo. Pawoo. Pawoo!");
        }
    }
}
