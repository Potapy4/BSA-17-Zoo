using ConsoleApp.Animal;
using AnimalStates;

namespace AnimalAbstract
{
    abstract class Animal: IVoice
    {
        protected int maxHP;

        public string Name { get; protected set; }
        public int HP { get; set; }        
        public AnimalState State { get; set; }

        public Animal(string Name)
        {
            this.Name = Name;
            State = AnimalState.Well_Fed;
        }

        public abstract void Voice();

        public void Eat()
        {
            this.State = AnimalState.Well_Fed;
        }

        public void Heal()
        {
            if(HP < maxHP)
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
