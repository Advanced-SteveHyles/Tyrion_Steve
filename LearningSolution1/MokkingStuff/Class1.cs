using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MokkingStuff
{


    public class GetName
    {
        public  string GetNameFromTextFile(string textfile)
        {
            var fileText = System.IO.File.ReadAllText(textfile);
            
            return fileText;
        }

        public string GetNameFromInjectedSource(INameSupplier nameSupplier)
        {
            var fileText = nameSupplier.GetName();

            return fileText;
        }
    }
}
