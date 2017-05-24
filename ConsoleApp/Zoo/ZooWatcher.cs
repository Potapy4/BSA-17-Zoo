using System;
using System.Collections.Generic;
using System.Timers;

namespace ConsoleApp.Zoo
{
    class ZooWatcher
    {
        private List<AnimalAbstract.Animal> animals;        
        private Timer timer;
        private static Random rand;
        private const int countAnimalsForTimer = 2;

        public bool isAllDead { get; private set; }

        public ZooWatcher(List<AnimalAbstract.Animal> animals)
        {
            this.animals = animals;

            rand = new Random();

            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(RandomChangeState);
            timer.Interval = 5000;
            timer.Start();
        }

        private int RandomIndexAnimal()
        {
            return rand.Next(0, animals.Count);
        }

        private void SomeOneAlive()
        {
            if (animals.Count == 0) // No animals
            {
                isAllDead = false;
                return;
            }

            for (int i = 0, count = animals.Count; i < count; i++)
            {
                if (animals[i].State != AnimalStates.AnimalState.Dead) // If someone not dead
                {
                    isAllDead = false;
                    return;
                }
            }

            isAllDead = true;
        }

        private void RandomChangeState(object sender, ElapsedEventArgs e)
        {
            if (animals.Count >= countAnimalsForTimer) // A minimum value for start
            {
                SomeOneAlive();

                if (isAllDead)
                {
                    timer.Stop();
                }

                int index = RandomIndexAnimal();
                // Console.WriteLine(string.Format("A: {0} | HP: {1} | ST: {2}", animals[index].Name, animals[index].HP, animals[index].State.ToString())); // Debug info

                animals[index].UpdateState();
            }
        }
    }
}
