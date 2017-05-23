using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Zoo
{
    interface IZoo
    {
        void AddAnimal(string Name, AnimalAbstract.Animal Type);
        void FeedAnimal(string Name);
        void HealAnimal(string Name);
        void RemoveAnimal(string Name);
    }
}
