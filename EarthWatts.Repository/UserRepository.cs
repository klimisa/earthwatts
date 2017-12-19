using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EarthWatts.Domain;

namespace EarthWatts.Repository
{
    public class UserRepository: Repository<User>
    {
        public UserRepository() : base(new EarthWattsContext())
        {

        }

        public Task<User> GetByEmailAddressAsync(string emailAddress)
        {
            return Context.Set<User>().SingleOrDefaultAsync(x => x.EmailAddress == emailAddress);
        }
    }
}
