using System.Collections.Generic;
using System.Linq;
using DTO;

namespace WebApplication1.Controllers
{
    public class Mappers
    {
        internal IEnumerable<AnimalDto> MapEntityToDto(List<string> animals)
        {

            var animalsDtos = new List<AnimalDto>();

            animalsDtos.AddRange(animals.Select<string, AnimalDto>(a => MapEntityToDto(a)));

            return animalsDtos;
        }

        private AnimalDto MapEntityToDto ( string animal)
        {
            return new AnimalDto { Type = animal};
        }
    }
}