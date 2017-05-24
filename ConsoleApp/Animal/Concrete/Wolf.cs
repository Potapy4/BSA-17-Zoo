using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Wolf : Animal
    {
        public Wolf(string Name) : base(Name)
        {
            maxHP = 4;
            this.HP = maxHP;
        }
    }
}
