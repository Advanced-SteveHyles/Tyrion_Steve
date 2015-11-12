using System.Collections.Generic;
using System.Linq;
using EntityCollection = ExpenseTracker.Repository.Factories;
using ExpenseTracker.API.Helpers;

using DTO = ExpenseTracker.DTO;
using Entities = ExpenseTracker.Repository.Entities;

namespace ExpenseTracker.API.Controllers
{
    public class MappersToDto
    {
        private readonly EntityCollection.ExpenseGroupFactory _expenseGroupFactory;
        private readonly EntityCollection.ExpenseFactory _expenseFactory;

        public MappersToDto(EntityCollection.ExpenseGroupFactory expenseGroupFactory, EntityCollection.ExpenseFactory expenseFactory)
        {
            _expenseGroupFactory = expenseGroupFactory;
            _expenseFactory = expenseFactory;
        }

        public IEnumerable<DTO.Expense> MapExpenses(IQueryable<Entities.Expense> expenses)
        {
            return expenses.ToList().Select(exp => _expenseFactory.CreateExpense(exp));
        }

        public DTO.ExpenseGroup MapEntitiyToDtoModel(Entities.ExpenseGroup expenseGroup)
        {
            return _expenseGroupFactory.CreateExpenseGroup(expenseGroup);
        }

        public IEnumerable<DTO.ExpenseGroup> MapEntitiesToDtoModels(IEnumerable<Entities.ExpenseGroup> expenseGroups)
        {
            return expenseGroups.ToList().Select(eg => _expenseGroupFactory.CreateExpenseGroup(eg));
        }

        public IEnumerable<DTO.ExpenseGroup> MapEntitiesToDtoModelsSorted(IQueryable<Entities.ExpenseGroup> expenseGroups, string sort, int statusId)
        {
            //Uses Dynamic linq
            return expenseGroups
                .Where(eg=> (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
                .ApplySort(sort)
                .ToList()
                .Select(eg => _expenseGroupFactory.CreateExpenseGroup(eg)                
                );
        }
    }
}