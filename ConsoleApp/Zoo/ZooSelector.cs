using System.Collections.Generic;
using System.Linq;
using System;

namespace ConsoleApp.Zoo
{
    class ZooSelector
    {
        private List<AnimalAbstract.Animal> animals;

        public ZooSelector(List<AnimalAbstract.Animal> animals)
        {
            this.animals = animals;
        }

        private AnimalStates.AnimalState GetState(string state)
        {
            AnimalStates.AnimalState _state;

            switch (state.ToLower())
            {
                case "well fed":
                    _state = AnimalStates.AnimalState.Well_Fed;
                    break;
                case "hungry":
                    _state = AnimalStates.AnimalState.Hungry;
                    break;
                case "sick":
                    _state = AnimalStates.AnimalState.Sick;
                    break;
                case "dead":
                    _state = AnimalStates.AnimalState.Dead;
                    break;
                default:
                    throw new Exceptions.AnimalInvalidTypeException();
            }

            return _state;
        }

        private void FormattedShow(AnimalAbstract.Animal animal)
        {
            Console.WriteLine("Name: {0} | Type: {1} | HP: {2} | State {3}", animal.Name, animal.GetType().Name, animal.HP, animal.State);
        }

        public void AnimalsByType(string type)
        {
            string formatted = type.ToLower();
            formatted = char.ToUpper(formatted[0]) + formatted.Substring(1);

            animals.Where(x => x.GetType().Name == formatted).ToList().ForEach(x => FormattedShow(x));
        }

        public void AnimalsByState(string state)
        {
            AnimalStates.AnimalState _state;

            try
            {
                _state = GetState(state);
            }
            catch (Exceptions.AnimalInvalidTypeException ex)
            {
                throw ex;
            }

            animals.Where(x => x.State == _state).ToList().ForEach(x => FormattedShow(x));
        }

        public void SickTigers()
        {
            animals.OfType<AnimalConcrete.Tiger>().ToList().Where(x => x.State == AnimalStates.AnimalState.Sick).ToList().ForEach(x => FormattedShow(x));
        }

        public void ElephantByName(string name)
        {
            string type = "Elephant";

            AnimalAbstract.Animal animal = animals.FirstOrDefault(x => x.GetType().Name == type && x.Name == name);

            if (animal == null)
            {
                Console.WriteLine("Nothing found.");
                return;
            }

            FormattedShow(animal);
        }

        public void AllHungryAnimals()
        {
            animals.Where(x => x.State == AnimalStates.AnimalState.Hungry).ToList().ForEach(x => Console.WriteLine("The {0} is hungry!", x.Name));
        }

        public void FirstHealthyByGroup()
        {
            animals.GroupBy(x => x.GetType().Name).Select(x => new
            {
                Group = x.Key,
                Animal = x.First(y => y.HP == y.MaxHP)
            }).ToList().ForEach(x =>
            {
                Console.WriteLine("Group: {0}", x.Group);
                FormattedShow(x.Animal);
            });
        }

        public void DeadAnimalsByType()
        {
            animals.GroupBy(x => x.GetType().Name).Select(x => new
            {
                Group = x.Key,
                Count = x.Where(y => y.State == AnimalStates.AnimalState.Dead).Count()
            }).ToList().ForEach(x => Console.WriteLine("Group: {0} | Count: {1}", x.Group, x.Count));
        }

        public void BearsAndWolfsByHP()
        {
            animals.Where(x => (x.GetType() == typeof(AnimalConcrete.Bear) || x.GetType() == typeof(AnimalConcrete.Wolf)) && x.HP > 3).ToList().ForEach(x => FormattedShow(x));
        }

        public void MaxAndMinHP()
        {
            /*
            var res = animals.Select(x => new
            {
                Min = animals.First(y => y.HP == animals.Min(z => z.HP)),
                Max = animals.First(y => y.HP == animals.Max(z => z.HP))
            }).First();*/ // It's work but I think not good solution

            var sorted = animals.OrderBy(x => x.HP).ToList();
            var res = new
            {
                Min = sorted.First(),
                Max = sorted.Last()
            };

            Console.WriteLine("Min HP: {0} | HP: {1} || Max HP: {2} | HP: {3}", res.Min.Name, res.Min.HP, res.Max.Name, res.Max.HP);
        }

        public void AvgHP()
        {
            Console.WriteLine("Avg HP: {0}", animals.Average(x => x.HP));
        }
    }
}
