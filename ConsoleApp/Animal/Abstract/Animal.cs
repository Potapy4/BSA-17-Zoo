using ConsoleApp.Animal;
using AnimalStates;

namespace AnimalAbstract
{
    abstract class Animal
    {
        protected int maxHP;

        public string Name { get; protected set; }
        public int HP { get; protected set; }        
        public int MaxHP { get { return maxHP; } }
        public AnimalState State { get; private set; }

        public Animal(string Name)
        {
            this.Name = Name;
            State = AnimalState.Well_Fed;
        }
        
        public void Eat()
        {
            if(State == AnimalState.Dead)
            {
                throw new Exceptions.AnimalDeadException("An animal can't eat because it's dead.");
            }

            State = AnimalState.Well_Fed;           
        }

        public void Heal()
        {
            if (State == AnimalState.Dead)
            {
                throw new Exceptions.AnimalDeadException("It's impossible to cure a dead animal.");
            }

            if (HP < maxHP)
            {
                ++HP;
            }
        }

        public void UpdateState()
        {
            switch (State)
            {
                case AnimalState.Well_Fed:
                case AnimalState.Hungry:
                    State++;
                    break;
                case AnimalState.Sick:
                    --HP;
                    if(HP <= 0)
                    {
                        State = AnimalState.Dead;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
