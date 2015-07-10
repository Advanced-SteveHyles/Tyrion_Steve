using System.Collections.Generic;

namespace ResharperOnly
{
    public interface IPowercounter
    {
        Powercounter SearchItems(IEnumerable<string> thingsToSearch );
        Powercounter SearchCriteria( string searchCriteria);
        Powercounter Search();
        int GetResult();
    }
}