using System.Collections.Generic;
using Exceptions;
using System.Timers;
using System;

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
            if(animals.Count == 0) // No animals
            {
                isAllDead = false;
                return;
            }

            for (int i = 0, count = animals.Count; i < count; i++)
            {
                if (!(animals[i].State is StateConcrete.Dead)) // If someone not dead
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
                Console.WriteLine(string.Format("A: {0} | HP: {1} | ST: {2}",animals[index].Name, animals[index].HP, animals[index].State.ToString()));

                if (animals[index].State is StateConcrete.Sick && animals[index].HP > 0)
                {
                    --animals[index].HP;
                }
                else
                {                    
                    animals[index].UpdateState();
                }
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
                switch (type)
                {
                    case "FOX":
                    case "fox":
                        animals.Add(new AnimalConcrete.Fox(name));
                        break;
                    case "WOLF":
                    case "wolf":
                        animals.Add(new AnimalConcrete.Wolf(name));
                        break;
                    case "BEAR":
                    case "bear":
                        animals.Add(new AnimalConcrete.Bear(name));
                        break;
                    case "ELEPHANT":
                    case "elephant":
                        animals.Add(new AnimalConcrete.Elephant(name));
                        break;
                    case "LION":
                    case "lion":
                        animals.Add(new AnimalConcrete.Lion(name));
                        break;
                    case "TIGER":
                    case "tiger":
                        animals.Add(new AnimalConcrete.Tiger(name));
                        break;
                    default:
                        throw new AnimalInvalidTypeException();
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

            if (index >= 0 && animals[index].State is StateConcrete.Dead)
            {
                animals.RemoveAt(index);
                return true;
            }
            else if(index == -1)
            {
                throw new AnimalNotFoundException();
            }

            return false;
        }
    }
}
