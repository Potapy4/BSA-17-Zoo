using StateAbsract;

namespace StateConcrete
{
    class Well_Fed : State
    {
        public override void ChangeState(AnimalAbstract.Animal animal)
        {
            animal.State = new Hungry();
        }
    }
}
