using StateAbsract;

namespace StateConcrete
{
    class Dead : State
    {
        public override void ChangeState(AnimalAbstract.Animal animal)
        {
            // Do nothing because it's final state
        }
    }
}
