using System;
using DebtsModel.GraphQLDTO;

namespace DebtsModel.DTO
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string PersonSurname { get; set; }
        public string PersonTitle { get; set; }
        public string PersonName { get; set; }
        public string OrgName { get; set; }
        public bool IsPerson { get; set; }
        public string Name => IsPerson ? $"{PersonTitle} {PersonName} {PersonSurname}" : OrgName;
    }
}