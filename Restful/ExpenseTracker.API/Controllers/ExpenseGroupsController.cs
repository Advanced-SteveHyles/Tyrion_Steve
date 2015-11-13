using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Routing;
using ExpenseTracker.Repository;
using ExpenseTracker.Repository.Entities;
using ExpenseTracker.Repository.Factories;
using Marvin.JsonPatch;
using Expense = ExpenseTracker.DTO.Expense;

namespace ExpenseTracker.API.Controllers
{
    [RoutePrefix("api")] //All routes have implicit API in them
    public class ExpenseGroupsController : ApiController
    {
        private readonly ExpenseTrackerEFRepository _repository;
        private readonly MappersToDto _mappersToDto;

        const int MaxPageSize = 10;

        public ExpenseGroupsController()
        {
            _repository = new ExpenseTrackerEFRepository(new Repository.Entities.ExpenseTrackerContext());
            _mappersToDto = new MappersToDto(new ExpenseGroupFactory(), new ExpenseFactory());
        }

        //// Get without sort
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        var expenseGroups = _repository.GetExpenseGroups();

        //        return Ok(_mappersToDto.MapEntitiesToDtoModels(expenseGroups));
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        // Get with sort
        //public IHttpActionResult Get(string sort = "id") //This is added to the URI as a querystring
        //{
        //    try
        //    {
        //        var expenseGroups = _repository.GetExpenseGroups();

        //        return Ok(_mappersToDto.MapEntitiesToDtoModelsSorted(expenseGroups, sort));
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        // Get with sort and Filtering
        //public IHttpActionResult Get(string sort = "id", string status = null, string userid = null) //This is added to the URI as a querystring
        //{
        //    try
        //    {
        //        var statusId = DomainMappers.MapStatusToId(status);

        //        var expenseGroups = _repository.GetExpenseGroups();

        //        return Ok(_mappersToDto.MapEntitiesToDtoModelsSorted(expenseGroups, sort, statusId, userid));
        //    }
        //    catch (Exception)
        //    {
        //        return InternalServerError();
        //    }
        //}

        //Get with sort, filter and paging
        [Route("expensegroups", Name = "ExpenseGroupsList")]
        public IHttpActionResult Get(string sort = "id", string status = null, string userId = null,
            int page = 1, int pageSize = 5) //This is added to the URI as a querystring
        {
            try
            {
                var statusId = DomainMappers.MapStatusToId(status);

                var expenseGroups = _repository.GetExpenseGroups();

                var data = _mappersToDto.MapEntitiesToDtoModelsSorted(expenseGroups, sort, statusId, userId);

                if (pageSize > MaxPageSize)
                {
                    pageSize = MaxPageSize;
                }

                var totalCount = data.Count();
                var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

                var urlHelper = new UrlHelper(Request);
                var previousLink = page > 1 ? urlHelper.Link("ExpenseGroupsList",
                    new
                    {
                        page = page - 1,
                        pageSize = pageSize,
                        sort = sort,
                        status = status,
                        userId = userId
                    }) : string.Empty;

                var nextLink = page < totalPages ? urlHelper.Link("ExpenseGroupsList",
                    new
                    {
                        page = page + 1,
                        pageSize = pageSize,
                        sort = sort,
                        status = status,
                        userId = userId
                    }) : string.Empty;


                var paginationHeader = new
                {
                    currentPage = page,
                    pageSize = pageSize,
                    totalCount = totalCount,
                    totalPages = totalPages,

                    status = status,
                    userId = userId,

                    previousPageLink = previousLink,
                    nextPageLink = nextLink
                };

                HttpContext.Current.Response.Headers.Add("x-Pagination",
                    Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));


                return Ok(
                    data
                    .Skip(pageSize * (page-1))
                    .Take(pageSize)                    
                     );
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

                return expenseGroup == null ? (IHttpActionResult)NotFound() : Ok(_mappersToDto.MapEntitiyToDtoModel(expenseGroup));
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

                var entityExpenseGroup = new ExpenseGroupFactory().CreateExpenseGroup(expenseGroup);
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
                    var dtoExpenseGroup = _mappersToDto.MapEntitiyToDtoModel(result.Entity);
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

                var entityExpenseGroup = new ExpenseGroupFactory().CreateExpenseGroup(expenseGroup);
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
                    var updatedExpenseGrouup = _mappersToDto.MapEntitiyToDtoModel(result.Entity);
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
            //  {"op" : "replace" , "path": "/title", "value": "XX"}
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

                var expenseGroupFactory = new ExpenseGroupFactory();
                var patchedExpenseGroupDTO = expenseGroupFactory.CreateExpenseGroup(entityExpenseGroup);
                expenseGroupPatchDocument.ApplyTo(patchedExpenseGroupDTO);

                var expenseGroupEntity = expenseGroupFactory.CreateExpenseGroup(patchedExpenseGroupDTO);

                var result = _repository.UpdateExpenseGroup(expenseGroupEntity);
                if (result.Status == RepositoryActionStatus.Updated)
                {
                    var returnExpenseGroupDto = _mappersToDto.MapEntitiyToDtoModel(result.Entity);
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

        public IHttpActionResult Delete(int id)
        {

            try
            {
                var result = _repository.DeleteExpenseGroup(id);
                if (result.Status == RepositoryActionStatus.Deleted)
                {
                    return StatusCode(HttpStatusCode.NoContent);
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
    }

    internal static class DomainMappers
    {
        public static int AllStatusus { get; } = -1;

        public static int MapStatusToId(string status)
        {
            if (status == null) return AllStatusus;
            switch (status.ToLower())
            {
                case "open":
                    return 1;
                case "confirmed":
                    return 2;
                case "processed":
                    return 3;
                default:
                    return AllStatusus;
            }
        }
    }
}
