﻿using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Lion : Animal
    {
        public Lion(string Name) : base(Name)
        {
            maxHP = 5;
            this.HP = maxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Roar. Roar. Roar!");
        }
    }
}
