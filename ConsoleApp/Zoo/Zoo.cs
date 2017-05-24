using System.Collections.Generic;
using Exceptions;
using System.Timers;
using System;
using AnimalStates;

namespace ConsoleApp.Zoo
{
    class Zoo : IZoo
    {
        private List<AnimalAbstract.Animal> animals;        
        private static Random rand;
        private Timer timer;

        public bool isAllDead { get; private set; }

        private const int countAnimalsForTimer = 2;

        public Zoo()
        {
            animals = new List<AnimalAbstract.Animal>();
            rand = new Random();

            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(RandomChangeState);
            timer.Interval = 250;
            timer.Start();
        }

        private int FindAnimalByName(string name)
        {
            return animals.FindIndex(x => x.Name == name);
        }

        private int RandomIndexAnimal()
        {
            return rand.Next(0, animals.Count);
        }

        public void SomeOneAlive()
        {
            if (animals.Count == 0) // No animals
            {
                isAllDead = false;
                return;
            }

            for (int i = 0, count = animals.Count; i < count; i++)
            {
                if (animals[i].State != AnimalState.Dead) // If someone not dead
                {
                    isAllDead = false;
                    return;
                }
            }

            isAllDead = true;
        }

        private void RandomChangeState(object sender, ElapsedEventArgs e)
        {
            if (animals.Count > countAnimalsForTimer) // A minimum value for start
            {
                SomeOneAlive();

                if (isAllDead)
                {
                    timer.Stop();
                }

                int index = RandomIndexAnimal();
                Console.WriteLine(string.Format("A: {0} | HP: {1} | ST: {2}", animals[index].Name, animals[index].HP, animals[index].State.ToString()));

                animals[index].UpdateState();
            }
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
    }
}
