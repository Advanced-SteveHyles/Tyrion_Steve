using System.Collections.Generic;
using DebtsModel.DTO;

namespace DebtsModel.DataAccess
{
    public class ResourceDatasource
    {
        private string _connectionString;

        public ResourceDatasource(string _connectionString)
        {
            this._connectionString = _connectionString;
        }

        public List<Resource> GetAllResources()
        {
            return new List<Resource>()
            {
                new Resource() {Name = "Iron"},
                new Resource() {Name = "Silicon"},
                new Resource() {Name = "Coballt"},
                new Resource() {Name = "Copper"}
            };
        }
    }


    public class ResourceMapDatasource
    {
        private string _connectionString;

        public ResourceMapDatasource(string _connectionString)
        {
            this._connectionString = _connectionString;
        }

        public List<Resource> GetResourcesForPlanet(string name)
        {
            return new List<Resource>()
            {
                new Resource() {Name = "Iron"},
                new Resource() {Name = "Silicon"},
                new Resource() {Name = "Coballt"},
                new Resource() {Name = "Copper"}
            };
        }
    }

}