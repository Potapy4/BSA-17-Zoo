using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.AnimalState.Concrete
{
    class Sick : Abstract.State
    {
        public override void ChangeState(Animal.Abstract.Animal animal)
        {
            animal.State = new Dead();
        }
    }
}
