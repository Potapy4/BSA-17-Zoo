using System;

namespace ConsoleApp.Animal.Concrete
{
    class Tiger : Abstract.Animal
    {
        public Tiger(string Name) : base(Name)
        {
            MaxHP = 4;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Moar. Moar. Moar!");
        }
    }
}
