using System.Collections.Generic;
using Exceptions;
using AnimalStates;

namespace ConsoleApp.Zoo
{
    class Zoo : IZoo
    {
        private List<AnimalAbstract.Animal> animals;
        public ZooWatcher watcher;

        public Zoo()
        {
            animals = new List<AnimalAbstract.Animal>();
            watcher = new ZooWatcher(animals);
        }

        private int FindAnimalByName(string name)
        {
            return animals.FindIndex(x => x.Name == name);
        }

        public void AddAnimal(string name, string type)
        {
            int index = FindAnimalByName(name);

            if (index >= 0)
            {
                throw new AnimalAlreadyExistsException();
            }
            else
            {
                try
                {
                    animals.Add(Animal.AnimalFabric.GetAnimal(name, type));
                }
                catch (AnimalInvalidTypeException ex)
                {
                    throw ex;
                }
            }
        }

        public void FeedAnimal(string name)
        {
            int index = FindAnimalByName(name);

            if (index >= 0)
            {
                animals[index].Eat();
            }
            else
            {
                throw new AnimalNotFoundException();
            }

        }

        public void HealAnimal(string name)
        {
            int index = FindAnimalByName(name);

            if (index >= 0)
            {
                animals[index].Heal();
            }
            else
            {
                throw new AnimalNotFoundException();
            }
        }

        public bool RemoveAnimal(string name)
        {
            int index = FindAnimalByName(name);

            if (index >= 0 && animals[index].State == AnimalState.Dead)
            {
                animals.RemoveAt(index);
                return true;
            }
            else if (index == -1)
            {
                throw new AnimalNotFoundException();
            }

            return false;
        }

        public List<AnimalAbstract.Animal> GetAnimals()
        {
            return animals;
        }
    }
}
