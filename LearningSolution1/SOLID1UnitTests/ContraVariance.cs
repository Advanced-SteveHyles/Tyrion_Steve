using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID1.L;
using Xunit;

namespace SOLID1UnitTests
{
    public class ContraVariance
    {

        [Fact]
        public void UserCanBeComparedWithEntityComparer()
        {
            SubtypeCovariance.IEqualityComparer<User> entityComparer = new EntityEqualityComparer();
            var user1 = new User();
            var user2 = new User();

            entityComparer.Equals(user1, user2).Should().BeFalse();

        }

    }
}
