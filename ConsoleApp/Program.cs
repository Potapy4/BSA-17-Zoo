using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal.Concrete.Lion animal = new Animal.Concrete.Lion();
            animal.Voice();
            
            if(animal.State is AnimalState.Concrete.Well_Fed)
            {
                Console.WriteLine("ITS WORK");
            }
        }
    }
}
