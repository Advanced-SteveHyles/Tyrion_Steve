using AbstractFactory.AnimalFactoryInterfaces;
using AbstractFactory.ConcreteAnimals;

namespace AbstractFactory.Tests
{
    internal class AmericaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Bison();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
}