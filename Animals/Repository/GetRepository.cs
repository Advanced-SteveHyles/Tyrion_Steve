using System.Collections.Generic;

namespace Repository
{
    public class GetRepository
    {
        public List<string> GetAnimals()                 
        {
            return new List<string> { "Cats", "Dogs", "Mice" };
        }    
    }
}