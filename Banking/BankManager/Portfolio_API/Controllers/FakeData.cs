using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using PortfolioManager.DTO;
using Portfolio_API.Controllers.Entities;
using Portfolio_API.Helpers;

namespace Portfolio_API.Controllers
{    
    internal class FakeData
    {
        public static List<PortfolioEnt> Portfolios { get; } = new List<PortfolioEnt>
        {
            {
                new PortfolioEnt
                {
                    Id = 1,
                    Name = "Portfolio 1"
                }
            },
            {
                new PortfolioEnt
                {
                    Id = 2,
                    Name = "Portfolio 1"
                }
            }
        };

        public List<AccountEnt> Accounts { get; } = new List<AccountEnt>
        {
            new AccountEnt
            {
                Id = 1,
                Name="Account 1"
            },
            new AccountEnt
            {
                Id = 2,
                Name="Account 2"
            },
            new AccountEnt
            {
                Id = 3,
                Name="Account 3"
            },
        };

        public static Entities.PortfolioEnt GetPortfolioWithAccounts(int id)
        {
            throw new System.NotImplementedException();
        }

        public static Entities.PortfolioEnt GetPortfolio(int id)
        {
            return Portfolios.SingleOrDefault(p => p.Id == id);
        }

        public static object CreateDataShapedObject(Entities.AccountEnt accountEnt, List<string> lstOfFields)
        {
            return string.Empty;
        }


        public static object CreateDataShapedObject(Entities.PortfolioEnt portfolioEnt, List<string> lstOfFields)
        { 
           // work with a new instance, as we'll manipulate this list in this method
            List<string> lstOfFieldsToWorkWith = new List<string>(lstOfFields);

            if (!lstOfFieldsToWorkWith.Any())
            {
                return portfolioEnt;
            }
            else
            {

                // does it include any expense-related field?
                var lstOfAccountFields = lstOfFieldsToWorkWith.Where(f => f.Contains("accounts")).ToList();

    // if one of those fields is "expenses", we need to ensure the FULL expense is returned.  If
    // it's only subfields, only those subfields have to be returned.

    bool returnPartialAccounts = lstOfAccountFields.Any() && !lstOfAccountFields.Contains("accounts");

                // if we don't want to return the full expense, we need to know which fields
                if (returnPartialAccounts)
                {
                    // remove all expense-related fields from the list of fields,
                    // as we will use the CreateDateShapedObject function in ExpenseFactory
                    // for that.

                    lstOfFieldsToWorkWith.RemoveRange(lstOfAccountFields);
                    lstOfAccountFields = lstOfAccountFields.Select(f => f.Substring(f.IndexOf(".") + 1)).ToList();

}
                else
                {
                    // we shouldn't return a partial expense, but the consumer might still have
                    // asked for a subfield together with the main field, ie: expense,expense.id.  We 
                    // need to remove those subfields in that case.
                    
                    lstOfAccountFields.Remove("accounts");
                    lstOfFieldsToWorkWith.RemoveRange(lstOfAccountFields);
                }

                // create a new ExpandoObject & dynamically create the properties for this object

                // if we have an expense

                ExpandoObject objectToReturn = new ExpandoObject();
                foreach (var field in lstOfFieldsToWorkWith)
	            {
                    // need to include public and instance, b/c specifying a binding flag overwrites the
                    // already-existing binding flags.

                    var fieldValue = portfolioEnt.GetType()
                        .GetProperty(field, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
                        .GetValue(portfolioEnt, null);
               
                    // add the field to the ExpandoObject
                     ((IDictionary<String, Object>)objectToReturn).Add(field, fieldValue);
	            }

                if (returnPartialAccounts)
                {
                    // add a list of accounts, and in that, add all those accounts
                    List<object> accounts = new List<object>();
                    foreach (var account in portfolioEnt.Accounts)
                    {
                        accounts.Add(CreateDataShapedObject(account, lstOfAccountFields));
                    }

                    ((IDictionary<String, Object>)objectToReturn).Add("accounts", accounts);
                }
                

                return objectToReturn;          
            }
        }


        public IEnumerable<PortfolioDto> MapEntitiesToDtoModelsSorted(Entities.PortfolioEnt portfolioEnt  , string sort, int statusId, string userId)
        {
            //Uses Dynamic linq
            return Portfolios
                //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
                //.Where(eg => (userId == null || eg.UserId == userId))
                //.ApplySort(sort)
                .ToList()
                .Select(p => CreatePortfolio(p)
                );
        }


        public IEnumerable<object> MapEntitiesToDtoModelsSortedShaped(IQueryable<Entities.PortfolioEnt> portfolio, string sort, int statusId, string userId, List<string> fields)
        {
            //Uses Dynamic linq
            return portfolio
                //.Where(eg => (statusId == DomainMappers.AllStatusus || eg.ExpenseGroupStatusId == statusId))
                //.Where(eg => (userId == null || eg.UserId == userId))
                //.ApplySort(sort)
                .ToList()
                .Select(eg => CreateDataShapedObject(eg, fields)
                );
        }

        public PortfolioDto CreatePortfolio(Entities.PortfolioEnt portfolioEnt)
        {
            return new PortfolioDto()
            {
                Id = portfolioEnt.Id,
                Name = portfolioEnt.Name,
                //UserId = portfolio.UserId,
                Accounts = portfolioEnt.Accounts.Select(e => CreateAccount(e)).ToList()
            };
        }


        public AccountDto CreateAccount(Entities.AccountEnt accountEnt)
        {
            return new AccountDto()
            {
                Id = -100,
                Name = accountEnt.Name,                
            };
        }



    }


    namespace Entities
    {
        public class PortfolioEnt
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public virtual ICollection<AccountEnt> Accounts { get; set; }
        }


        public class AccountEnt
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}