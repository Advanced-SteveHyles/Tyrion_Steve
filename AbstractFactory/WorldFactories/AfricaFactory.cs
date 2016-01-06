using AbstractFactory.AnimalFactoryInterfaces;
using AbstractFactory.ConcreteAnimals;

namespace AbstractFactory.Tests
{
    internal class AfricaFactory : IContinentFactory
    {
        public IHerbivore CreateHerbivore()
        {
            return new Wildebeest();
        }

        public ICarnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
}