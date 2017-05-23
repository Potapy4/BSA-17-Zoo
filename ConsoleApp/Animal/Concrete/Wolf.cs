using System;

namespace ConsoleApp.Animal.Concrete
{
    class Wolf : Abstract.Animal
    {
        public Wolf(string Name) : base(Name)
        {
            MaxHP = 4;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Ahwoooooooooo!");
        }
    }
}
