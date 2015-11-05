using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Entities;
using ExpenseTracker.Repository.Factories;

namespace ExpenseTracker.API.Controllers
{
    public class ExpenseGroupsController : ApiController
    {                
        private readonly IExpenseTrackerRepository _repository;
        private readonly ExpenseGroupFactory _expenseGroupFactory = new ExpenseGroupFactory();
        

        public ExpenseGroupsController()
        {
            _repository = new ExpenseTrackerEFRepository(new ExpenseTrackerContext ());
        }

        public ExpenseGroupsController(IExpenseTrackerRepository repository)
        {
            _repository = repository;
        }

        public IHttpActionResult Get()
        {
            try
            {
                var expenseGroups = _repository.GetExpenseGroups();

                 return Ok(MapEntitiesToDtoModels(expenseGroups));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
            
        }

        private IEnumerable<DTO.ExpenseGroup> MapEntitiesToDtoModels(IEnumerable<ExpenseGroup> expenseGroups)
        {
            return expenseGroups.ToList().Select(eg => _expenseGroupFactory.CreateExpenseGroup(eg));
        }
    }                                                       
}
