using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Elephant : Animal
    {
        public Elephant(string Name) : base(Name)
        {
            MaxHP = 7;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Pawoo. Pawoo. Pawoo!");
        }
    }
}
