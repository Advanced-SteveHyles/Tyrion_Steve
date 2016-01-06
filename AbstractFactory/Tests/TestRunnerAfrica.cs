using Xunit;

namespace AbstractFactory.Tests
{
    public  class TestRunnerAfrica
    {

        [Fact]
        void TestAfrica()
        {
            // Create and run the African animal world
            IContinentFactory africa = new AfricaFactory();
            AnimalWorld world = new AnimalWorld(africa);
            world.RunFoodChain(1);
            
        }

     

     
    }
}