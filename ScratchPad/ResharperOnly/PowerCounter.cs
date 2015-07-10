using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResharperOnly
{
    public class Powercounter : IPowercounter
    {
        private IEnumerable<string> _thingsToSearch;
        private string _searchCriteria;
        private IEnumerable<string> _results;


        public Powercounter SearchItems(IEnumerable<String> thingsToSearch )
        {
            this._thingsToSearch = thingsToSearch;
            return this;
        }

        public Powercounter SearchCriteria( string searchCriteria)
        {
            this._searchCriteria = searchCriteria;
            
            return this;
        }

        public Powercounter Search()
        {
            this._results = _thingsToSearch.Where(f => f.Equals(_searchCriteria));

            return this;
        }

public        int GetResult()
        {
            return _results.Count();
        }
        
    }
}
