using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Lion : Animal
    {
        public Lion(string Name) : base(Name)
        {
            MaxHP = 5;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Roar. Roar. Roar!");
        }
    }
}
