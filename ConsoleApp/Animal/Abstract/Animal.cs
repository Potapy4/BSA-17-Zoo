using ConsoleApp.AnimalState.Abstract;

namespace ConsoleApp.Animal.Abstract
{
    abstract class Animal: IVoice
    {
        public string Name { get; protected set; }
        public int HP { get; protected set; }
        public State State { get; set; }

        public Animal()
        {
            State = new AnimalState.Concrete.Well_Fed();
        }

        public abstract void Voice();
    }
}
