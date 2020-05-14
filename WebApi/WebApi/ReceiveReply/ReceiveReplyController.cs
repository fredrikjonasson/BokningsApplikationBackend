using Domain.Interfaces;
using Domain.Invitations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.ReceiveReply
{
    [Route("events/{eventId}/invitations")]
    public class ReceiveReplyController : Controller
    {
        public IUseCase<IInvitation> _useCase { get; set; }

        public ReceiveReplyController(IUseCase<IInvitation> useCase)
        {
            _useCase = useCase;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ReceiveReply(Guid id, bool answer)
        {
            IInvitation invitation = new Invitation();
            invitation.Id = id;

            invitation.InvitationStatus = answer ? InvitationStatus.Accepted : InvitationStatus.Rejected;
            
            _useCase.Execute(invitation);
            throw new NotImplementedException();
        }
    }
}