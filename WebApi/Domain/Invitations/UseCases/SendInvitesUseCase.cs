using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Domain.Invitations.UseCases
{
    public class SendInvitesUseCase
    {
        private readonly DbContext _context;
        private readonly IInvitationFactory _invitationsFactory;

        public SendInvitesUseCase(DbContext context, IInvitationFactory invitationsFactory)
        {
            _context = context;
            _invitationsFactory = invitationsFactory;
        }

        public void Execute(List<string> invitations, Guid eventId)
        {
            invitations.ForEach((invitation) =>
            {
                _context.Add(_invitationsFactory.CreateInvite(invitation, eventId));
            });
            _context.SaveChanges();
        }
    }
}
