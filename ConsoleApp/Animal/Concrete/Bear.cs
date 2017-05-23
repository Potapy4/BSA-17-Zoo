using System;
using AnimalAbstract;

namespace AnimalConcrete
{
    class Bear : Animal
    {
        public Bear(string Name) : base(Name)
        {
            MaxHP = 6;
            this.HP = MaxHP;
        }

        public override void Voice()
        {
            Console.WriteLine("Growl. Growl. Growl!");
        }
    }
}
