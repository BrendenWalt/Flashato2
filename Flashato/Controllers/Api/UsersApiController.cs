using Flashato.Models.Requests;
using Flashato.Services;
using Flashato.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flashato.Controllers.Api
{
    [RoutePrefix("api/users")]
    public class UsersApiController : ApiController
    {

        private IUserService _userService;

        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(RegistrationRequest model)
        {

            IdentityResult result = _userService.Register(model);

            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("current"),HttpGet]
        public HttpResponseMessage GetCurrentUser()
        {
            string userId = _userService.GetCurrentUserId();

            return Request.CreateResponse(HttpStatusCode.OK, userId);
        } 

    }
}
