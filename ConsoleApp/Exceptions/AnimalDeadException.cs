using System;

namespace Exceptions
{
    class AnimalDeadException: Exception
    {
        public AnimalDeadException(string msg): base(msg) { }
    }
}
