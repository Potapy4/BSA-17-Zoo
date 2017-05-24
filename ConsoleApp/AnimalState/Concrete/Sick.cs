using StateAbsract;

namespace StateConcrete
{
    class Sick : State
    {
        public override void ChangeState(AnimalAbstract.Animal animal)
        {
            animal.State = new Dead();
        }
    }
}
