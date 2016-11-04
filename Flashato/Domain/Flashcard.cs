using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashato.Domain
{
    public class Flashcard
    {
        public int Id { get; set; }

        public string Front { get; set; }

        public string Back { get; set; }

        public string UserId { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

    }
}