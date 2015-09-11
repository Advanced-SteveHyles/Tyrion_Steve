using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID1.L
{
    class CoVariance
    {
        public void TryOne()
        {
            var userRepository = new UserRepository();

            var x = userRepository.GetByID(new Guid());
            var dob = x.DateOfBirth;
        }

    }

    public class Entity { public Guid ID { get; private set; } public string Name { get; private set; } }

    public class User : Entity { public string EmailAddress { get; private set; } public DateTime DateOfBirth { get; private set; } }


    public class EntityRepository { public virtual Entity GetByID(Guid id) { return new Entity(); } }


    //public class UserRepository : EntityRepository { public override User GetByID( Guid id) { return new User(); } }

    public interface IEntityRepository<TEntity> where TEntity : Entity { TEntity GetByID(Guid id); }

    public class UserRepository : IEntityRepository<User>
    { public User GetByID(Guid id) { return new User(); } }


}
