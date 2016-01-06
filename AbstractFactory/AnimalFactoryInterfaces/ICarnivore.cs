using System.Collections.Generic;

namespace AbstractFactory.AnimalFactoryInterfaces
{
    interface ICarnivore
    {
        List<string> MealsEaten { get; }

        void Eat(IHerbivore h);
    }
}