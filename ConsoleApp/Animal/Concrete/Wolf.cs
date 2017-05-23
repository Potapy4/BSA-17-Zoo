using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Wolf : Animal
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
