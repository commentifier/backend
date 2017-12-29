using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Commentifier.Models;
using Commentifier.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Commentifier.Controllers
{
    [Route("api/[controller]/[action]")]
    public class InvitationsController : Controller
    {
        private IInvitationsRepository _invitationsRepository;
        public InvitationsController(IInvitationsRepository invitationsRepository) => _invitationsRepository = invitationsRepository;

        [HttpGet]
        [ActionName("AddEmail")]
        public IActionResult Add(string email)
        {
            Request.HttpContext.Response.Headers.Add("AMP-Access-Control-Allow-Source-Origin", "http://localhost");
            Invitation invitation = new Invitation
            {
                Email = email
            };

            var response = _invitationsRepository.AddWithValidation(invitation);
            return Json(new { response });
        }
    }
}
