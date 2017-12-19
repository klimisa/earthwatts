using System;
using System.Threading.Tasks;
using EarthWatts.Domain;
using EarthWatts.Repository;

namespace EarthWatts.Services
{
    public class ProjectService
    {
        private readonly UserRepository _userRepository;
        private readonly ProjectRepository _projectRepository;

        public ProjectService() : this(new UserRepository(), new ProjectRepository())
        {

        }

        public ProjectService(UserRepository userRepository, ProjectRepository projectRepository)
        {
            _userRepository = userRepository;
            _projectRepository = projectRepository;
        }

        public async Task<Response> CreateProject(int createdBy, string projectTitle, string projectDescription)
        {
            var response = new Response();

            try
            {
                var user = await _userRepository.GetByIdAsync(createdBy);
                if (user == null)
                {
                    throw new Exception("User do not exist.");
                }

                var project = new Project
                {
                    CreatedBy = createdBy,
                    ProjectTitle = projectTitle,
                    ProjectDescription = projectDescription,
                    DateCreated = DateTime.Now
                };

                await _projectRepository.AddAsync(project);
                response.Success = true;
                return response;
            }
            catch (Exception e)
            {
                response.Success = false;
                response.Errors.Add(e.Message);
                return response;
            }
        }
    }
}