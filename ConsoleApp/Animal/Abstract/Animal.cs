using ConsoleApp.AnimalState.Abstract;

namespace ConsoleApp.Animal.Abstract
{
    abstract class Animal: IVoice
    {
        protected int MaxHP;

        public string Name { get; protected set; }
        public int HP { get; set; }
        public State State { get; set; }

        public Animal(string Name)
        {
            this.Name = Name;
            State = new AnimalState.Concrete.Well_Fed();
        }

        public abstract void Voice();
    }
}
