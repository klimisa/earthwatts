using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EarthWatts.Repository
{
    public class EarthWattsInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EarthWattsContext>
    {
        protected override void Seed(EarthWattsContext context)
        {
        }
    }
}
