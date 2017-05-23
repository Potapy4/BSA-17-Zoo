using System;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Animal.Concrete
{
    class Bear : Ursidae
    {
        public Bear(string Name) : base(Name)
        {
            this.HP = 6;
        }

        public override void Voice()
        {
            Console.WriteLine("Growl. Growl. Growl!");
        }
    }
}
