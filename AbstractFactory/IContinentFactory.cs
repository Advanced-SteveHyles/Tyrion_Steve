using System.IO;
using AbstractFactory.AnimalFactoryInterfaces;

namespace AbstractFactory
{
    internal interface IContinentFactory 
    {
        IHerbivore CreateHerbivore();
        ICarnivore CreateCarnivore();
    }
}