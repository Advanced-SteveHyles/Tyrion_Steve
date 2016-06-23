using DebtsModel.DTO;
using GraphQL.Types;

namespace DebtsModel.GraphQLDTO
{
    public class ContactType : ObjectGraphType
    {
        public ContactType()
        {
            Name = "Contact";
            Description = "A contact - person or organisation";
            
            Field<StringGraphType>("name", "The name of a contact.");

            IsTypeOf = value => value is Contact;
        }
    }
}