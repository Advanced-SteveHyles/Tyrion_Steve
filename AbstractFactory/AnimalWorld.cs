using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstractFactory.AnimalFactoryInterfaces;

namespace AbstractFactory
{
    class AnimalWorld
    {
        public int Carnvivors { get; private set; }
        public int Herbivors { get; private set; }
        private readonly IHerbivore _herbivore;
        private readonly ICarnivore _carnivore;

        // Constructor
        public AnimalWorld(IContinentFactory factory)
        {
            _carnivore = factory.CreateCarnivore();
            _herbivore = factory.CreateHerbivore();
        }

        public void AddCarvivors(int addedCarnvivors)
        {
            Carnvivors += addedCarnvivors;
        }

        public void AddHerbivors(int addedHerbivors)
        {
            Herbivors += addedHerbivors;
        }


        public void RunFoodChain(int days)
        {
            for (var day = 0; day < days; day++)
            {
                if (Carnvivors > 0 && Herbivors > 0)
                {
                    _carnivore.Eat(_herbivore);
                    Herbivors--;
                }

                if (Carnvivors > Herbivors)
                {
                    Carnvivors += 1;
                }
                else if (Herbivors > Carnvivors)
                {
                    Herbivors += 1;
                }                
            }
        }
    }
}