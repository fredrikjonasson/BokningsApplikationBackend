using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Invitations.UseCases
{
    public class SendInvitesUseCase : IUseCase<InvitationInput>
    {
        private readonly DbContext _context;
        private readonly IInvitationFactory _invitationsFactory;

        public SendInvitesUseCase(DbContext context, IInvitationFactory invitationsFactory)
        {
            _context = context;
            _invitationsFactory = invitationsFactory;
        }

        public void Execute(InvitationInput input)
        {
            input.Emails.ForEach((email) =>
            {
                _context.Add(_invitationsFactory.CreateInvite(email, input.EventId));
            });
            _context.SaveChanges();
        }
    }
}
