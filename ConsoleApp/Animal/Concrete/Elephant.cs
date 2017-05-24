using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Elephant : Animal
    {
        public Elephant(string Name) : base(Name)
        {
            maxHP = 7;
            this.HP = maxHP;
        }
    }
}
