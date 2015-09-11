using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID1.L
{
    class Contravariance
    {
        public interface IEqualityComparer < in TEntity > where TEntity : Entity { bool Equals( TEntity left, TEntity right); }

        public class EntityEqualityComparer : IEqualityComparer < Entity > { public bool Equals( Entity left, Entity right) { return left.ID == right.ID; } }


    }
}
