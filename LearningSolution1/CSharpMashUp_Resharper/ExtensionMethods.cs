using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMashUp_Resharper
{
    public static class ExtensionMethods
    {
        public static string DoThis(this String str)
        {
            return "Extension Method";
        }

        public static int DoThis(this int  theInt)
        {
            return theInt+2;
        }

        
       public void test()
        {
            var s = "";
            s.DoThis();

            var i = 0;
            i.DoThis();
        }
    }
}
