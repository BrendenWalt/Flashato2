using Flashato.Models.Requests;
using Flashato.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flashato.Controllers.Api
{
    [RoutePrefix("decks")]
    public class DecksApiController : ApiController
    {

        [Route, HttpPost]
        public HttpResponseMessage Insert(DeckInsertRequest deck)
        {
            if(!ModelState.IsValid && deck != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            DeckServices services = new DeckServices();
            int id = services.Insert();

            return Request.CreateResponse(HttpStatusCode.OK, id);

        }
    }
}
