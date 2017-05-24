using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Bear : Animal
    {
        public Bear(string Name) : base(Name)
        {
            maxHP = 6;
            this.HP = maxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Growl. Growl. Growl!");
        }
    }
}
