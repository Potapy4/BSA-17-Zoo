namespace ConsoleApp.Animal
{
    static class AnimalFabric
    {
       public static AnimalAbstract.Animal GetAnimal(string name, string type)
        {
            switch (type.ToLower())
            {
                case "fox":
                   return new AnimalConcrete.Fox(name);                   
                case "wolf":
                    return new AnimalConcrete.Wolf(name);                    
                case "bear":
                    return new AnimalConcrete.Bear(name);                    
                case "elephant":
                    return new AnimalConcrete.Elephant(name);                   
                case "lion":
                    return new AnimalConcrete.Lion(name);                    
                case "tiger":
                    return new AnimalConcrete.Tiger(name);                   
                default:
                    throw new Exceptions.AnimalInvalidTypeException();
            }
        }
    }
}
