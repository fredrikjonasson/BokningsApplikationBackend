using Domain.Interfaces;
using Domain.Invitations.UseCases;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.UseCases.SendInvitations
{
    [ApiController]
    [Route("events/{eventId}/invitations")]
    public class SendInvitationController : ControllerBase
    {
        private readonly IUseCase<InvitationInput> _invitationUseCase;

        public SendInvitationController(IUseCase<InvitationInput> invitationUseCase)
        {
            _invitationUseCase = invitationUseCase;
        }

        [HttpPost]
        public ActionResult SendInvitations(Guid eventId, InvitationRequest request)
        {
            _invitationUseCase.Execute(new InvitationInput(request.Emails, eventId));
            return Ok();
        }
    }
}
