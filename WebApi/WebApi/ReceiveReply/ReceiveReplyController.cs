using Domain.Invitations.UseCases.ReplyInvite;
using Domain.Interfaces;
using Domain.Invitations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.ReceiveReply
{
    [Route("events/{eventId}/invitations")]
    public class ReceiveReplyController : Controller
    {
        public IUseCase<ReplyDTO> _useCase { get; set; }


        public ReceiveReplyController(IUseCase<ReplyDTO> useCase)
        {
            _useCase = useCase;
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult ReceiveReply(Guid id, bool answer, string FirstName, string LastName)
        {
            var replyDTO = new ReplyDTO(id, answer);
            _useCase.Execute(replyDTO);
            throw new NotImplementedException();
        }
    }
}