using System;

namespace ConsoleApp.Animal.Concrete
{
    class Bear : Abstract.Animal
    {
        public Bear(string Name) : base(Name)
        {
            MaxHP = 6;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Growl. Growl. Growl!");
        }
    }
}
