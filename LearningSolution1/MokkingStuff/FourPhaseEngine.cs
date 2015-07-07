using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MokkingStuff
{
    public class FourPhaseEngine
    {
        private ICommand _phase1;
        private ICommand _phase2;
        private ICommand _phase3;
        private ICommand _phase4;
        

        public FourPhaseEngine SetPhase1(ICommand phase1)
        {
            this._phase1 = phase1;

            return this;
        }

        public FourPhaseEngine SetPhase2(ICommand phase2)
        {
            this._phase2 = phase2;

            return this;
        }

        public FourPhaseEngine SetPhase3(ICommand phase3)
        {
            this._phase3 = phase3;

            return this;
        }
        public FourPhaseEngine SetPhase4(ICommand phase4)
        {
            this._phase4 = phase4;

            return this;
        }


        public void PerformRun()
        {
            this._phase1.Execute();

            this._phase2.Execute();

            this._phase3.Execute();

            this._phase4.Execute();
        }
    }

    internal class Phase4 : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    internal class Phase3 :ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    internal class Phase2 : ICommand
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }

    internal class Phase1 : ICommand
    {
        public  void Execute()
        {
            throw new NotImplementedException();
        }
    }


    public interface ICommand
    {
        void Execute();
    }

}
