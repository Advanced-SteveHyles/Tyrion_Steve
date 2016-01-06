//    /// <summary>
//    /// The 'ConcreteFactory1' class
//    /// </summary>
//    class AfricaFactory : ContinentFactory
//    {
//        public override Herbivore CreateHerbivore()
//        {
//            return new Wildebeest();
//        }
//        public override Carnivore CreateCarnivore()
//        {
//            return new Lion();
//        }
//    }

//    /// <summary>
//    /// The 'ConcreteFactory2' class
//    /// </summary>
//    class AmericaFactory : ContinentFactory
//    {
//        public override Herbivore CreateHerbivore()
//        {
//            return new Bison();
//        }
//        public override Carnivore CreateCarnivore()
//        {
//            return new Wolf();
//        }
//    }


//    /// <summary>
//    /// The 'Client' class 
//    /// </summary>
//    class AnimalWorld
//    {
//        private Herbivore _herbivore;
//        private Carnivore _carnivore;

//        // Constructor
//        public AnimalWorld(ContinentFactory factory)
//        {
//            _carnivore = factory.CreateCarnivore();
//            _herbivore = factory.CreateHerbivore();
//        }

//        public void RunFoodChain()
//        {
//            _carnivore.Eat(_herbivore);
//        }
//    }
//}



