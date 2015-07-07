using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMashUp_Resharper
{
    public class FirstImplementor :  FirstInterface , ISecondInterface
    {
        protected override void UpdateCounterN()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class FirstInterface : IThirdInterface
    {
        public int Counter { get; set; }

        protected abstract void UpdateCounterN();

        protected virtual void UpdateCounterTwice(int incrementor)
        {
            Counter += incrementor;
            Counter += incrementor;            
        }

        protected virtual void UpdateCounterThrice(int incrementor)
        {
            Counter += incrementor;
            Counter += incrementor;
            Counter += incrementor;
        }
    }

    public interface IThirdInterface : IFourthInterface
    {

    }

    public interface IFourthInterface
    {
        int Counter { get; set; }
    }

    public interface ISecondInterface
    {
    }
}
