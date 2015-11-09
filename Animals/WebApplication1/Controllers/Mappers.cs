using System.Collections.Generic;
using System.Linq;
using DTO;

namespace WebApplication1.Controllers
{
    public class Mappers
    {
        internal IEnumerable<AnimalDto> MapEntityToDto(Dictionary<int, string> animals)
        {
            return animals.Select(animal => MapEntityToDto(animal.Value)).ToList();
        }

        public AnimalDto MapEntityToDto (string animalType)
        {
            return new AnimalDto { Type = animalType };
        }
    }
}