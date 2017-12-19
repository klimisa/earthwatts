using EarthWatts.Domain;

namespace EarthWatts.Repository
{
    public class ProjectRepository: Repository<Project>
    {
        public ProjectRepository() : base(new EarthWattsContext())
        {

        }
    }
}