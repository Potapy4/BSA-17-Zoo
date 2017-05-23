using StateAbsract;

namespace StateConcrete
{
    class Dead : State
    {
        public override void ChangeState(AnimalAbstract.Animal animal)
        {
            animal.State = null;
        }
    }
}
