using System.Collections.Generic;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class PlanetsDatasource
    {
        private string _connectionString;

        public PlanetsDatasource(string _connectionString)
        {
            this._connectionString = _connectionString;
        }

        public List<Planet> GetAllPlanets()
        {
            return new List<Planet>()
            {
                new Planet() {Name = "Aestus"},
                new Planet() {Name = "Akua"},
                new Planet() {Name = "Ningues"},
                new Planet() {Name = "Omicron"}
            };
        }
    }
}
