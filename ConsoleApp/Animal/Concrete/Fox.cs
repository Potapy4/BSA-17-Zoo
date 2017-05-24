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
    }
}
