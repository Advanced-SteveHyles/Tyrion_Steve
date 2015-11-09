using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class GetRepository
    {
        private Dictionary<int, string> _animals;

        public GetRepository()
        {
            _animals = new Dictionary<int, string>()
            {
                {0, "Dog" },
                {1, "Horse" },
                {2, "Mouse" },
                {3, "Cat" }
            };
        }

        public Dictionary<int, string> GetAnimals()                 
        {
            return _animals;
        }

        public string GetAnimal(int id)
        {
            if (_animals.ContainsKey(id))
            {
                return _animals[id];
            }

            return null;
        }
    }
}