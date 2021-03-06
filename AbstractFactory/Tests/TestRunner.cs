﻿using System;
using Xunit;

namespace AbstractFactory.Tests
{
    public class TestRunnerAmerica
    {
        AnimalWorld _world;

        public TestRunnerAmerica()
        {
            IContinentFactory america = new AmericaFactory();
            
            _world = new AnimalWorld(america);
        }

        [Fact]
        void WhenThereAreNoCarnivorsAndNoPairsOfHerbivorsThenThePopulationStagnates()
        {
            // Create and run the American animal world
           
            _world.AddHerbivors(1);
            Assert.Equal(1, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(1, _world.Herbivors);
        }

        [Fact]
        void WhenThereAreNoCarnivorsAndAtLeastAPairsOfHerbivorsThenThePopulationGrows()
        {
            // Create and run the American animal world

            _world.AddHerbivors(2);
            Assert.Equal(2, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(3, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(4, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(6, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(9, _world.Herbivors);
        }


        [Fact]
        void WhenThereAreNoHerbivorsThePopulationFalls()
        {
            _world.AddCarvivors(1);
            Assert.Equal(1, _world.Carnvivors);

            _world.RunFoodChain(1);
            Assert.Equal(0, _world.Carnvivors);

        }

        [Fact]
        void WhenThereAreTheSameNumberOfAnimalsThePopulationIsDestroyed()
        {
            _world.AddCarvivors(1);
            _world.AddHerbivors(1);

            Assert.Equal(1, _world.Carnvivors);
            Assert.Equal(1, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(1, _world.Carnvivors);
            Assert.Equal(0, _world.Herbivors);

            _world.RunFoodChain(1);
            Assert.Equal(0, _world.Herbivors);
        }

    }
}
