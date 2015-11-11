using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.DTO;
using ExpenseTracker.Repository.Factories;
using ExpenseGroup = ExpenseTracker.Repository.Entities.ExpenseGroup;

namespace ExpenseTracker.API.Controllers
{
    public class MappersToDto
    {
        private readonly ExpenseGroupFactory _expenseGroupFactory;
        private readonly ExpenseFactory _expenseFactory;

        public MappersToDto(ExpenseGroupFactory expenseGroupFactory, ExpenseFactory expenseFactory)
        {
            _expenseGroupFactory = expenseGroupFactory;
            _expenseFactory = expenseFactory;
        }

        public IEnumerable<Expense> MapExpenses(IQueryable<Repository.Entities.Expense> expenses)
        {
            return expenses.ToList().Select(exp => _expenseFactory.CreateExpense(exp));
        }

        public DTO.ExpenseGroup MapEntitiyToDtoModel(ExpenseGroup expenseGroup)
        {
            return _expenseGroupFactory.CreateExpenseGroup(expenseGroup);
        }

        public IEnumerable<DTO.ExpenseGroup> MapEntitiesToDtoModels(IEnumerable<ExpenseGroup> expenseGroups)
        {
            return expenseGroups.ToList().Select(eg => _expenseGroupFactory.CreateExpenseGroup(eg));
        }
    }
}