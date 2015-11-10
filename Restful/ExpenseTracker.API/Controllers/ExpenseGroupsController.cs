using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Entities;
using ExpenseTracker.Repository.Factories;
using Marvin.JsonPatch;

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

        public IHttpActionResult Put(int id, [FromBody] DTO.ExpenseGroup expenseGroup)
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

                var result = _repository.UpdateExpenseGroup(entityExpenseGroup);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var updatedExpenseGrouup = MapEntitiyToDtoModel(result.Entity);
                    return Ok(updatedExpenseGrouup);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
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


        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody] JsonPatchDocument<DTO.ExpenseGroup> expenseGroupPatchDocument)
        {
            //Patch nuget marvin.jsonpatch
            //[
            //  {"op" : "copy" , "from": "/title", "path": "/description"},
            //  {"op" : "replace" , "path": "/title", "value": XX"}
            //]

            try
            {
                if (expenseGroupPatchDocument == null)
                {
                    return BadRequest();
                }

                var entityExpenseGroup = _repository.GetExpenseGroup(id);
                if (entityExpenseGroup == null)
                {
                    return NotFound();
                }

                var patchedExpenseGroupDTO = _expenseGroupFactory.CreateExpenseGroup(entityExpenseGroup);
                expenseGroupPatchDocument.ApplyTo(patchedExpenseGroupDTO);

                var expenseGroupEntity = _expenseGroupFactory.CreateExpenseGroup(patchedExpenseGroupDTO);

                var result = _repository.UpdateExpenseGroup(expenseGroupEntity);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var returnExpenseGroupDto = MapEntitiyToDtoModel(result.Entity);
                    return Ok(returnExpenseGroupDto);
                }
                else if (result.Status == RepositoryActionStatus.NotFound)
                {
                    return NotFound();
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
