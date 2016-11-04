using Flashato.Domain;
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
    [RoutePrefix("api/flashcards")]
    public class FlashcardApiController : ApiController
    {

        //private IFlashcardServices _flashcardServices;

        //public FlashcardApiController(IFlashcardServices flashcardServices)
        //{
        //    _flashcardServices = flashcardServices;
        //}

        [Route, HttpPost]
        public HttpResponseMessage Insert(CardInsertRequest card)
        {
            if (!ModelState.IsValid && card != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            FlashcardServices service = new FlashcardServices();
            int id = service.Insert(card);

            int response = id;

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(CardUpdateRequest card)
        {
            if (!ModelState.IsValid && card != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            FlashcardServices service = new FlashcardServices();
            int id = service.Update(card);

            int response = id;
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            FlashcardServices service = new FlashcardServices();
            int cardId = service.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK, cardId);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            FlashcardServices service = new FlashcardServices();
            Flashcard card = service.GetById(id);

            return Request.CreateResponse(HttpStatusCode.OK, card);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetAll()
        {
            FlashcardServices service = new FlashcardServices();
            List<Flashcard> deck = service.GetAllCards();

            return Request.CreateResponse(HttpStatusCode.OK, deck);
        }
    }
}
