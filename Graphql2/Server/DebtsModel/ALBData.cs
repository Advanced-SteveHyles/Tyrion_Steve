using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebtsModel.DataAccess;
using DebtsModel.DTO;
using DebtsModel.GraphQLDTO;

namespace DebtsModel
{
    public class ALBData
    {
        private readonly string _connectionString;
        private readonly string _fieldsApiUrl;
        private readonly APICredentials _apiCredentials;

        public ALBData(string connectionString, string fieldsApiUrl, APICredentials apiCredentials)
        {
            _connectionString = connectionString;
            _fieldsApiUrl = fieldsApiUrl;
            _apiCredentials = apiCredentials;
        }

        public Task<Matter> GetMatterByReferenceAsync(string reference)
        {
            var dataSource = new MatterDataSource(_connectionString);
            return Task.FromResult(dataSource.FindByReference(reference).SingleOrDefault());
        }

        public Task<Client> FindClientAsync(string id)
        {
            var dataSource = new ClientDataSource(_connectionString);
            return Task.FromResult(dataSource.FindByMemOrgId(id));
        }

        public Task<Debt> GetDebtForMatter(Matter source, List<string> fqnList)
        {
            var dataSource = new DebtDataSource(_fieldsApiUrl, _apiCredentials);
            return Task.FromResult(dataSource.FindDebtByMatterId(source.Id, fqnList));
        }

        public Task<List<Matter>> GetMattersForClient(Client client, string matterReference)
        {
            var dataSource = new MatterDataSource(_connectionString);
            return Task.FromResult(dataSource.FindMatters(client.Id, matterReference));
        }

        public Task<Contact> GetContactForMatter(Matter matter, string role)
        {
            var dataSource = new ContactDataSource(_connectionString);
            return Task.FromResult(dataSource.FindContact(matter.Id, role));
        }

        public Task<List<UserTask>> GetUserTasksForMatter(Matter matter)
        {
            var datasource = new UserTaskDataSource(_connectionString);
            return Task.FromResult((datasource.FindUserTasks(matter.Id)));
        }
        public Task<List<Milestone>> GetMilestonesForMatter(Matter matter)
        {
            var datasource = new MilestoneDataSource(_connectionString);
            return Task.FromResult((datasource.FindMilestones(matter.Id)));
        }

        public Task<List<Milestone>>  GetUserTasksForMatterMilestone(Matter matter)
        {
            var datasource = new MilestoneDataSource(_connectionString);
            
            return Task.FromResult(datasource.FindMilestonesWithActions(matter.Id));
        }

        public Task<Earner> GetFeeEarnerForMatter(Matter matter)
        {
            var datasource = new EarnerDataSource(_connectionString);
            return Task.FromResult(datasource.FindByMemberId(matter.FeeEarnerId));
        }

        public Task<Earner> GetSupervisorForMatter(Matter matter)
        {
            var datasource = new EarnerDataSource(_connectionString);
            return Task.FromResult(datasource.FindByMemberId(matter.SupervisorId));
        }

        public Task<Address> GetAddressForEarner(Earner earner)
        {
            var datasource = new AddressDataSource(_connectionString);
            const int primaryAddressTypeId = 1;
            return Task.FromResult(datasource.FindAddressByMemberId(earner.Id, primaryAddressTypeId));
        }

        public Task<AdditionalAddressElement> GetUrlForEarner(Earner earner)
        {
            var datasource = new AdditionalAddressElementDataSource(_connectionString);
            const int urlTypeId = 9;
            return Task.FromResult(datasource.GetAdditionalAddressElement(earner.Id, urlTypeId));
        }

        public Task<List<Planet>>  GetPlanets()
        {
            var datasource = new PlanetsDatasource(_connectionString);
            return Task.FromResult(datasource.GetAllPlanets());            
        }

        public Task<List<Resource>> GetResources()
        {
            var datasource = new ResourceDatasource(_connectionString);
            return Task.FromResult(datasource.GetAllResources());
        }


        public Task<List<Resource>> GetResourcesForPlanet(Planet planet)
        {
            var datasource = new ResourceMapDatasource(_connectionString);
            return Task.FromResult(datasource.GetResourcesForPlanet(planet.Name));
        }
    }
}
