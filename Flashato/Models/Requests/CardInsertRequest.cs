using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flashato.Models.Requests
{
    public class CardInsertRequest
    {
        [Required]
        [MaxLength(500)]
        public string Front { get; set; }

        [Required]
        [MaxLength(500)]
        public string Back { get; set; }

        [Required]
        public int DeckId { get; set; }
    }
}