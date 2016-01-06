using System.Collections.Generic;
using AbstractFactory;
using AbstractFactory.AnimalFactoryInterfaces;


namespace AbstractFactory.ConcreteAnimals
{ 
class Lion : ICarnivore
{
    public List<string> MealsEaten { get; }
    public void Eat(IHerbivore h)
    {
        MealsEaten.Add(this.GetType().Name + " eats " + h.GetType().Name);
    }
}
}