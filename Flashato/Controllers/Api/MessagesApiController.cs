using Flashato.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Flashato.Controllers.Api
{
    [RoutePrefix("api/messages")]
    public class MessagesApiController : ApiController
    {
        private IMessageServices _messageServices;

        public MessagesApiController(IMessageServices messageServices)
        {
            _messageServices = messageServices;
        }

        [Route("share"),HttpPost]
        public void shareDeck(string recipient)
        {
            _messageServices.SendDeck(recipient);

        }
    }
}
