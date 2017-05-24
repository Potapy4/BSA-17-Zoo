using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Zoo
{
    interface IZoo
    {
        void AddAnimal(string name, string type);
        void FeedAnimal(string Name);
        void HealAnimal(string Name);
        bool RemoveAnimal(string Name);
    }
}
