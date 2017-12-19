using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI;
using EarthWatts.Api.Models;
using EarthWatts.Domain;
using EarthWatts.Services;

namespace EarthWatts.Api.Controllers
{
    [RoutePrefix("api/earthwatts")]
    public class EartWattsController : ApiController
    {
        private readonly UserService _userService;
        private readonly ProjectService _projectService;

        private List<string> Errors
        {
            get
            {
                return ModelState.Values.SelectMany(m => m.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
            }
        }

        public EartWattsController() : this(new UserService(), new ProjectService())
        {

        }

        public EartWattsController(UserService userService, ProjectService projectService)
        {
            _userService = userService;
            _projectService = projectService;
        }

        #region User
        [HttpPost]
        [Route("registerUser")]
        public async Task<HttpResponseMessage> RegisterUser(RegisterUserView request)
        {
            var responseView = new ResponseView();

            if (request == null || !ModelState.IsValid)
            {
                responseView.Success = false;
                responseView.Errors =  Errors;
                return Request.CreateResponse(HttpStatusCode.OK, responseView);
            }

            var response = await _userService.RegisterUser(request.FirstName, request.LastName, request.EmailAddress, request.Password);

            responseView.Success = response.Success;
            responseView.Errors = response.Errors;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPost]
        [Route("loginUser")]
        public async Task<HttpResponseMessage> LoginUser(LoginUserView request)
        {
            var responseView = new ResponseView();

            if (request == null || !ModelState.IsValid)
            {
                responseView.Success = false;
                responseView.Errors = Errors;
                return Request.CreateResponse(HttpStatusCode.OK, responseView);
            }

            var response = await _userService.LoginUser(request.EmailAddress, request.Password);

            responseView.Success = response.Success;
            responseView.Errors = response.Errors;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        #endregion

        #region Project
        [HttpPost]
        [Route("createproject")]
        public async Task<HttpResponseMessage> CreateProject(CreateProjectView request)
        {
            var responseView = new ResponseView();

            if (request == null || !ModelState.IsValid)
            {
                responseView.Success = false;
                responseView.Errors = Errors;
                return Request.CreateResponse(HttpStatusCode.OK, responseView);
            }

            var response = await _projectService.CreateProject(request.CreatedBy, request.ProjectTitle, request.ProjectDescription);

            responseView.Success = response.Success;
            responseView.Errors = response.Errors;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
        #endregion
    }
}
