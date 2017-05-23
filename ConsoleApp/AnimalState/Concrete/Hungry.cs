using StateAbsract;

namespace StateConcrete
{
    class Hungry : State
    {
        public override void ChangeState(AnimalAbstract.Animal animal)
        {
            animal.State = new Sick();
        }
    }
}
