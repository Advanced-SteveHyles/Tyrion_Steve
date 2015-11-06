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
            _repository = new ExpenseTrackerEFRepository(new ExpenseTrackerContext());
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


        public IHttpActionResult Get(int id)
        {
            try
            {
                var expenseGroup = _repository.GetExpenseGroup(id);

                return expenseGroup == null ? (IHttpActionResult)NotFound() : Ok(MapEntitiyToDtoModel(expenseGroup));
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [HttpPost]
        public IHttpActionResult Post([FromBody] DTO.ExpenseGroup expenseGroup)
        {
            try
            {
                if (expenseGroup == null)
                {
                    return BadRequest();
                }

                var entityExpenseGroup = _expenseGroupFactory.CreateExpenseGroup(expenseGroup);
                if (entityExpenseGroup == null)
                {
                    return BadRequest();
                }

                /*
                {
                    "userId": "https://expensetrackeridsrv3/embedded_1",
                    "title": "STV",
                    "description": "STV",
                    "expenseGroupStatusId": 1,
                }
                */

                var result = _repository.InsertExpenseGroup(entityExpenseGroup);
                if (result.Status == RepositoryActionStatus.Created)
                {
                    var dtoExpenseGroup = MapEntitiyToDtoModel(result.Entity);
                    return Created(Request.RequestUri + "/" + dtoExpenseGroup.Id, dtoExpenseGroup);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception)
            {

                return InternalServerError();
            }
        }


        private DTO.ExpenseGroup MapEntitiyToDtoModel(ExpenseGroup expenseGroup)
        {
            return _expenseGroupFactory.CreateExpenseGroup(expenseGroup);
        }


        private IEnumerable<DTO.ExpenseGroup> MapEntitiesToDtoModels(IEnumerable<ExpenseGroup> expenseGroups)
        {
            return expenseGroups.ToList().Select(eg => _expenseGroupFactory.CreateExpenseGroup(eg));
        }
    }
}
