using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Fox : Animal
    {
        public Fox(string Name) : base(Name)
        {
            MaxHP = 3;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("What does the fox say?");
        }
    }
}
