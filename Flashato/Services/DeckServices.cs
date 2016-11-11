using Flashato.Models.Requests;
using Flashato.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flashato.Services
{
    public class DeckServices
    {
        private IUserService _userService;

        public DeckServices(IUserService userService)
        {
            _userService = userService;
        }

        public Insert(DeckInsertRequest model)
        {
            string user = _userService.GetCurrentUserId();
        }

    }
}