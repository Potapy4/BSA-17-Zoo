using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Tiger : Animal
    {
        public Tiger(string Name) : base(Name)
        {
            maxHP = 4;
            this.HP = maxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Moar. Moar. Moar!");
        }
    }
}
