using ConsoleApp.Animal;
using StateAbsract;
using StateConcrete;

namespace AnimalAbstract
{
    abstract class Animal: IVoice
    {
        protected int maxHP;

        public string Name { get; protected set; }
        public int HP { get; set; }        
        public State State { get; set; }

        public Animal(string Name)
        {
            this.Name = Name;            
            State = new Well_Fed();
        }

        public abstract void Voice();

        public void Eat()
        {
            this.State = new Well_Fed();
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
            this.State.ChangeState(this);
        }
    }
}
