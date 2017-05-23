using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp.Animal.Abstract;

namespace ConsoleApp.Zoo
{
    class Zoo: IZoo
    {
        private List<Animal.Abstract.Animal> animals;

        /* TODO
        private int FindAnimalByName(string name)
        {
            //return animals.FindIndex(x => x.Name == name);
        }
        */

        public void AddAnimal(string name, Animal.Abstract.Animal type)
        {
            throw new NotImplementedException();
        }

        public void FeedAnimal(string name)
        {
            throw new NotImplementedException();
        }

        public void HealAnimal(string name)
        {
            
        }

        public void RemoveAnimal(string name)
        {
            throw new NotImplementedException();
        }
    }
}
