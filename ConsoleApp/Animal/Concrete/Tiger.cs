using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Tiger : Felidae
    {
        public Tiger(string Name) : base(Name)
        {
            this.HP = 4;
        }

        public override void Voice()
        {
            Console.WriteLine("Moar. Moar. Moar!");
        }
    }
}
