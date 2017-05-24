using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Fox : Animal
    {
        public Fox(string Name) : base(Name)
        {
            maxHP = 3;
            this.HP = maxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
