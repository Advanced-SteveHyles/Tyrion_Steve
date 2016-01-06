using System;
using System.Collections.Generic;
using AbstractFactory;
using AbstractFactory.AnimalFactoryInterfaces;

namespace AbstractFactory.ConcreteAnimals
{
    class Wolf : ICarnivore
    {
        public List<string> MealsEaten => new List<string>();

        public void Eat(IHerbivore h)
        {
            MealsEaten.Add(this.GetType().Name + " eats " + h.GetType().Name);
        }
    }
}