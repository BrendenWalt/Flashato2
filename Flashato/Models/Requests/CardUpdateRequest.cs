using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashato.Models.Requests
{
    public class CardUpdateRequest : CardInsertRequest
    {
        public int Id { get; set; }
    }
}